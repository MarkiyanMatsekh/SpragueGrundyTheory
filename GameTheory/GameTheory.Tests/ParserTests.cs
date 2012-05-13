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
        public void Small()
        {
            var exp = "5";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression(5);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void Big()
        {
            var exp = "5287";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression(5287);

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseSimpleExpression
    {
        [Test]
        public void WithAddition()
        {
            var exp = "n+5";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression(Operation.Plus, 5);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithSubstraction()
        {
            var exp = "n-7";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression(Operation.Minus, 7);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithBiggerNumber()
        {
            var exp = "n-289";
            var res = GameLogicParser.ParseSimpleExpression(exp);
            var expected = new SimpleExpression(Operation.Minus, 289);

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseIteratorExpression
    {
        [Test]
        public void WithSubstractionAndArgAddition()
        {
            var exp = "n-i+3";
            var res = GameLogicParser.ParseIteratorBodyExpression(exp);
            var expected = new IteratorBodyExpression(Operation.Minus, Operation.Plus, 3);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithSubstractionAndArgSubsstraction()
        {
            var exp = "n-i-5";
            var res = GameLogicParser.ParseIteratorBodyExpression(exp);
            var expected = new IteratorBodyExpression(Operation.Minus, Operation.Minus, 5);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithAdditionAndArgAddition()
        {
            var exp = "n+i+2";
            var res = GameLogicParser.ParseIteratorBodyExpression(exp);
            var expected = new IteratorBodyExpression(Operation.Plus, Operation.Plus, 2);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithAdditionAndArgSubstraction()
        {
            var exp = "n+i-8";
            var res = GameLogicParser.ParseIteratorBodyExpression(exp);
            var expected = new IteratorBodyExpression(Operation.Plus, Operation.Minus, 8);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithBiggerNumber()
        {
            var exp = "n-i+8904";
            var res = GameLogicParser.ParseIteratorBodyExpression(exp);
            var expected = new IteratorBodyExpression(Operation.Minus, Operation.Plus, 8904);

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseFullIteratorExpression
    {
        [Test]
        public void WithSimpleRange()
        {
            var exp = "n-i+3,i=1..2";
            var res = GameLogicParser.ParseFullIteratorExpression(exp);
            var expected = new FullIteratorExpression(new IteratorBodyExpression(Operation.Minus, Operation.Plus, 3),
                                                      new SimpleExpression(1), new SimpleExpression(2));

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithVariableInRightPartOfRange()
        {
            var exp = "n-i+3,i=1..n";
            var res = GameLogicParser.ParseFullIteratorExpression(exp);
            var expected = new FullIteratorExpression(new IteratorBodyExpression(Operation.Minus, Operation.Plus, 3),
                                                      new SimpleExpression(1), SimpleExpression.VariableOnly());

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithExpressionInRightPartOfRange()
        {
            var exp = "n-i+3,i=1..n-2";
            var res = GameLogicParser.ParseFullIteratorExpression(exp);
            var expected = new FullIteratorExpression(new IteratorBodyExpression(Operation.Minus, Operation.Plus, 3),
                                          new SimpleExpression(1), new SimpleExpression(Operation.Minus, 2));
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void WithExpressionInBothPartsOfRange()
        {
            var exp = "n-i+3,i=n-3..n-1";
            var res = GameLogicParser.ParseFullIteratorExpression(exp);
            var expected = new FullIteratorExpression(new IteratorBodyExpression(Operation.Minus, Operation.Plus, 3),
                                          new SimpleExpression(Operation.Minus, 3), new SimpleExpression(Operation.Minus, 1));

            Assert.That(res, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class ParseGameSumExpression
    {
        [Test]
        public void With2Games()
        {
            var exp = "i&n-i-1,i=0..n-1";
            var actual = GameLogicParser.ParseGameSumExpression(exp);
            var expected = new GameSumExpression(new List<IteratorBodyExpression>()
                                                     {
                                                         IteratorBodyExpression.IteratorOnly(),
                                                         new IteratorBodyExpression(Operation.Minus, Operation.Minus, 1)
                                                     }, new SimpleExpression(0),
                                                 new SimpleExpression(Operation.Minus, 1));

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void With3Games()
        {
            var exp = "i&n-i-1&i+3,i=0..n-1";
            var actual = GameLogicParser.ParseGameSumExpression(exp);
            var expected = new GameSumExpression(new List<IteratorBodyExpression>()
                                                     {
                                                         IteratorBodyExpression.IteratorOnly(),
                                                         new IteratorBodyExpression(Operation.Minus, Operation.Minus, 1),
                                                         new IteratorBodyExpression(Operation.Plus,3)
                                                     }, new SimpleExpression(0),
                                                 new SimpleExpression(Operation.Minus, 1));

            Assert.That(expected, Is.EqualTo(actual));
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

    [TestFixture]
    public class EvaluatorShould
    {
        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void CrashWhenEvaluatingNoneOperationOfTwoArguments()
        {
            var actual = EvaluatableExpression.EvaluateSimpleOperation(0, Operation.None, 1);
            Assert.That(1, Is.EqualTo(actual));
        }
    }
}
