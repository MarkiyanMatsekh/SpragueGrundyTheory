using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.UI;
using NUnit.Framework;

namespace GameTheory.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Test1()
        {
            var exp = "1";
            var res = LogicParser.Parse(exp);

            Assert.That(res[0].HasVariable, Is.False);
            Assert.That(res[0].Argument, Is.EqualTo(1));
        }
    }
}
    