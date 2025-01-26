using cdbApp.Server.Interfaces;
using cdbApp.Server.Services;

namespace cdbApp.Server.Models;

public class Cdb
{
    public decimal InitialValue { get; private set; }
    public int Months { get; private set; }
    public decimal FinalValue { get; private set; }
    public decimal FinalValueWithTax { get; private set; }

    public Cdb(decimal initialValue, int months, decimal tb, decimal cdi, decimal tax)
    {
        InitialValue = initialValue;
        Months = months;
        FinalValue = GetFinalValue(tb, cdi);
        FinalValueWithTax = GetFinalValueWithTax(FinalValue, tax);
    }

    private decimal GetFinalValue(decimal tb, decimal cdi)
    {
        decimal finalValue = InitialValue;

        for (int i = 0; i < Months; i++)
        {
            finalValue *= (1 + (cdi * tb));
        }
        return finalValue;
    }

    private decimal GetFinalValueWithTax(decimal finalValue, decimal tax)
    {
        var grossProfit = finalValue - InitialValue;
        return finalValue - (grossProfit * tax);
    }
}
