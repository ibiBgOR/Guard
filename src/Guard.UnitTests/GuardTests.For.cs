﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Guard.UnitTests
{
    [TestFixture]
    public partial class GuardTests
    {
        [Test]
        public void For_InvalidInput_ThrowsException()
        {
            var items = new List<int>();
            bool Predicate() => !items.Any();
            var exception = new Exception("error message");

            Should.Throw<Exception>(() => Guard.For(Predicate, exception));
        }

        [Test]
        public void For_InvalidInputNullException_ThrowsException()
        {
            var items = new List<int>();
            bool Predicate() => !items.Any();
            Exception exception = null;

            Should.Throw<ArgumentNullException>(() => Guard.For(Predicate, exception));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(2, 0)]
        public void For_ValidInput_DoesNotThrowException(int input, int threshold)
        {
            var items = new List<int> {1};
            bool Predicate() => !items.Any();
            var exception = new Exception("error message");

            Should.NotThrow(() => Guard.For(Predicate, exception));
        }
    }
}