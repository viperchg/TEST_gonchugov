using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeProvide;
namespace Exchanger_new_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите сумму в рублях: ");
            var rubStrValue = Console.ReadLine();
            var rubValue = 0.0;
            if (!double.TryParse(rubStrValue, out rubValue))
            {
                throw new InvalidCastException($"Указанная сумма '{rubStrValue}' не является валидным числом");
            }

            var provider = new ExchangeProvider();
            var result = provider.Exchange(rubValue);

            Console.WriteLine($"Сумма в руб: {rubValue:# ##0.00}| курс: {provider.Cource:# ##0.00}| комиссия: {provider.GetCommission(rubValue):# ##0.00}| cумма в у.е.: {result:# ##0.00}");
        }
    }
    }

