using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.UI;
using GameTheory.UI.Parser;
using GameTheory.UI.Parser.Expressions;
using NUnit.Framework;

namespace GameTheory.Tests
{
    [TestFixture]
    public class ParseNumber
    {
        [Test]
        public void ParseSmallNumber()
        {
            var exp = "5";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression() { Argument = 5, HasVariable = false, Operation = Operation.None };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void ParseBigNumber()
        {
            var exp = "5287";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression() { Argument = 5287, HasVariable = false, Operation = Operation.None };

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseSimpleEquation
    {
        [Test]
        public void WithAddition()
        {
            var exp = "n+5";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression() { Argument = 5, Operation = Operation.Plus, HasVariable = true };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithSubstraction()
        {
            var exp = "n-7";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression() { Argument = 7, Operation = Operation.Minus, HasVariable = true };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithBiggerNumber()
        {
            var exp = "n-289";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression() { Argument = 289, Operation = Operation.Minus, HasVariable = true };

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseEquationWithIterator
    {
        [Test]
        public void WithSubstractionAndArgAddition()
        {
            var exp = "n-i+3";
            var res = GameLogicParser.ParseExpressionWithIterator(exp);
            var expected = new ExpressionWithIterator
                               {
                                   HasVariable = true,
                                   OperationOnIterator = Operation.Minus,
                                   Operation = Operation.Plus,
                                   Argument = 3
                               };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithSubstractionAndArgSubsstraction()
        {
            var exp = "n-i-5";
            var res = GameLogicParser.ParseExpressionWithIterator(exp);
            var expected = new ExpressionWithIterator
                               {
                                   HasVariable = true,
                                   OperationOnIterator = Operation.Minus,
                                   Operation = Operation.Minus,
                                   Argument = 5
                               };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithAdditionAndArgAddition()
        {
            var exp = "n+i+2";
            var res = GameLogicParser.ParseExpressionWithIterator(exp);
            var expected = new ExpressionWithIterator
                               {
                                   HasVariable = true,
                                   OperationOnIterator = Operation.Plus,
                                   Operation = Operation.Plus,
                                   Argument = 2
                               };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithAdditionAndArgSubstraction()
        {
            var exp = "n+i-8";
            var res = GameLogicParser.ParseExpressionWithIterator(exp);
            var expected = new ExpressionWithIterator
                               {
                                   HasVariable = true,
                                   OperationOnIterator = Operation.Plus,
                                   Operation = Operation.Minus,
                                   Argument = 8
                               };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithBiggerNumber()
        {
            var exp = "n-i+8904";
            var res = GameLogicParser.ParseExpressionWithIterator(exp);
            var expected = new ExpressionWithIterator
                               {
                                   HasVariable = true,
                                   OperationOnIterator = Operation.Minus,
                                   Operation = Operation.Plus,
                                   Argument = 8904
                               };

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseFullEquationWithIterator
    {
        [Test]
        public void WithSimpleRange()
        {
            var exp = "n-i+3,i=1..2";
            var res = GameLogicParser.ParseFullExpressionWithIterator(exp);
            var expected = new FullExpressionWithIterator
            {
                HasVariable = true,
                OperationOnIterator = Operation.Minus,
                Operation = Operation.Plus,
                Argument = 3,
                IterateFrom = new SimpleExpression()
                {
                    Argument = 1,
                    HasVariable = false,
                    Operation = Operation.None
                },
                IterateTo = new SimpleExpression()
                {
                    Argument = 2,
                    HasVariable = false,
                    Operation = Operation.None
                }
            };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithVariableInRightPartOfRange()
        {
            var exp = "n-i+3,i=1..n";
            var res = GameLogicParser.ParseFullExpressionWithIterator(exp);
            var expected = new FullExpressionWithIterator
            {
                HasVariable = true,
                OperationOnIterator = Operation.Minus,
                Operation = Operation.Plus,
                Argument = 3,
                IterateFrom = new SimpleExpression()
                {
                    Argument = 1,
                    HasVariable = false,
                    Operation = Operation.None
                },
                IterateTo = new SimpleExpression()
                {
                    HasVariable = true,
                    Operation = Operation.None
                }
            };

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithExpressionInRightPartOfRange()
        {
            var exp = "n-i+3,i=1..n-2";
            var res = GameLogicParser.ParseFullExpressionWithIterator(exp);
            var expected = new FullExpressionWithIterator
                               {
                                   HasVariable = true,
                                   OperationOnIterator = Operation.Minus,
                                   Operation = Operation.Plus,
                                   Argument = 3,
                                   IterateFrom = new SimpleExpression()
                                                     {
                                                         Argument = 1,
                                                         HasVariable = false,
                                                         Operation = Operation.None
                                                     },
                                   IterateTo = new SimpleExpression()
                                                   {
                                                       HasVariable = true,
                                                       Operation = Operation.Minus,
                                                       Argument = 2
                                                   }
                               };
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithExpressionInBothPartsOfRange()
        {
            var exp = "n-i+3,i=n-3..n-1";
            var res = GameLogicParser.ParseFullExpressionWithIterator(exp);
            var expected = new FullExpressionWithIterator
            {
                HasVariable = true,
                OperationOnIterator = Operation.Minus,
                Operation = Operation.Plus,
                Argument = 3,
                IterateFrom = new SimpleExpression()
                {
                    HasVariable = true,
                    Operation = Operation.Minus,
                    Argument = 3
                },
                IterateTo = new SimpleExpression()
                {
                    HasVariable = true,
                    Operation = Operation.Minus,
                    Argument = 1
                }
            };

            Assert.That(res, Is.EqualTo(expected));
        }

    }

    [TestFixture]
    public class ParserShouldNot
    {
        [Test, ExpectedException(typeof(ArgumentException))]
        public void NotParseEquationWithIteratorWithoutFirstPart()
        {
            var exp = "i=1-8";
            GameLogicParser.ParseSingleTransition(exp);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void NotParseEquationWithIteratorWithoutSecondPart()
        {
            var exp = "n+i-8";
            GameLogicParser.ParseSingleTransition(exp);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void NotParseSomeShit()
        {
            var exp = "some shit";
            GameLogicParser.ParseSingleTransition(exp);
        }
    }
}
