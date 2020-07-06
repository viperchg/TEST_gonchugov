using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProvide
{
    public class ExchangeProvider
    {
        public double Cource => 64.25;

        public double GetCommission(double value)
        {
            if (value < 1000)
            {
                return 4.0;
            }

            if (value < 10000)
            {
                return 3.0;
            }

            if (value < 50000)
            {
                return 2.0;
            }

            if (value < 100000)
            {
                return 1.0;
            }

            return 0.3;
        }

        public double Exchange(double value)
        {
            return (value / Cource) * (1 - GetCommission(value) / 100);
        }
    }
}
