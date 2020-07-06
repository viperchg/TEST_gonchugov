using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeProvide;
//using Exchange_new_1;
using Xunit;
using FluentAssertions;
using System.Collections;

namespace ExchangerProviderTests
{
    public class SecondTestDataGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {6.47, 500},
        new object[] {11.25,753},
        new object[] {15.10,1000},
        new object[] {113.23,7500},
        new object[] {152.53,10000},
        new object[] {689.34,45553},
        new object[] {770.43,50000},
        new object[] {1300.0,94363},
        new object[] {1631.75,100000},
        new object[] {6890.60,434000},
    };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
    public class ExchangeProviderTests
    {

        public static IEnumerable<object[]> GetNumbers()
        {

            yield return new object[] { 4.0, 500 };
            yield return new object[] { 3.0, 5000 };
            yield return new object[] { 2.0, 45000 };
            yield return new object[] { 1.0, 50000 };
            yield return new object[] { 0.3, 150000 };
        }

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void GetCommission_EveryCondition_Success(double expected, double actual)
        {
            var Fr = new ExchangeProvider();
            var result = Fr.GetCommission(actual);
            expected.Should().Be(result);
        }


        [Theory]
        [ClassData(typeof(SecondTestDataGenerator))]
        public void Exchange_EveryCondition_Success(double expected, double actual)
        {
            var Exch = new ExchangeProvider();
            var result = Math.Round(Exch.Exchange(actual), 2);
            expected.Should().Be(result);
        }
    }
}
