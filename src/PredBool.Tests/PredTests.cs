using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PredBool.Tests
{
    public class PredTests
    {
        [Fact]
        public void Can_assign_a_func_to_a_pred()
        {
            Func<int, bool> f = i => i > 0;
            
            Pred<int> greaterThanZero = f;
            Assert.True(greaterThanZero.Func(1));
        }
        [Fact]
        public void Pred_can_be_created_from_funcs()
        {
            var isOdd = Pred<int>.MakeFrom(i => i%2 != 0);

            Assert.True(isOdd.Func(1));
        }

        [Fact]
        public void Can_access_the_contained_func()
        {
            var isOdd = Pred<int>.MakeFrom(i => i % 2 != 0);
            var isOddDelegate = isOdd.Func;
            Assert.False(isOddDelegate(0));
            Assert.True(isOddDelegate(-1));
        }

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
    }
}
