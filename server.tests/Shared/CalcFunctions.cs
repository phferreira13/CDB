using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.tests.Shared;
public static class CalcFunctions
{
    public static decimal CalculateFinalValue(decimal initialValue, int months, decimal tb, decimal cdi)
    {
        decimal finalValue = initialValue;
        for (int i = 0; i < months; i++)
        {
            finalValue *= (1 + (cdi * tb));
        }
        return finalValue;
    }

    public static decimal CalculateFinalValueWithTax(decimal finalValue, decimal tax)
    {
        var grossProfit = finalValue - 1000;
        return finalValue - (grossProfit * tax);
    }
}
