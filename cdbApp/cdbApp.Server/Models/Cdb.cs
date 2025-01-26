namespace cdbApp.Server.Models;

public class Cdb
{
    public decimal InitialValue { get; private set; }
    public int Months { get; private set; }
    public decimal FinalValue { get; private set; }
    public decimal FinalValueWithTax { get; private set; }

    public Cdb(decimal initialValue, int months, decimal tb, decimal cdi, decimal tax)
    {
        if (initialValue <= 0 || months <= 0)
        {
            throw new ArgumentException("Initial value and months must be greater than 0");
        }
        InitialValue = initialValue;
        Months = months;
        FinalValue = CalculateFinalValue(tb, cdi);
        FinalValueWithTax = CalculateFinalValueWithTax(FinalValue, tax);
    }

    private decimal CalculateFinalValue(decimal tb, decimal cdi)
    {
        decimal finalValue = InitialValue;

        for (int i = 0; i < Months; i++)
        {
            finalValue *= (1 + (cdi * tb));
        }
        return finalValue;
    }

    private decimal CalculateFinalValueWithTax(decimal finalValue, decimal tax)
    {
        var grossProfit = finalValue - InitialValue;
        return finalValue - (grossProfit * tax);
    }
}
