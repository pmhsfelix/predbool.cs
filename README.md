predbool.cs
===========

C# library of Boolean operators for predicates

        [Fact]
        public void Can_use_boolean_operators_on_preds()
        {
            var isOdd = Pred<int>.MakeFrom(i => i%2 != 0);
            var isLowerThan10 = Pred<int>.MakeFrom(i => i < 10);
            var isOddAndLowerThan10 = isOdd && isLowerThan10;

            Assert.Equal(5, Enumerable.Range(0,20).Count(isOddAndLowerThan10));
            Assert.Equal(15, Enumerable.Range(0, 20).Count(!isOddAndLowerThan10));

            Assert.True(isOddAndLowerThan10.Func(1));
            Assert.False(isOddAndLowerThan10.Func(2));
            Assert.False(isOddAndLowerThan10.Func(11));
            Assert.False(isOddAndLowerThan10.Func(12));
        }

See the tests for more usage examples.
