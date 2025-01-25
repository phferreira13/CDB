using cdbApp.Server.Interfaces;

namespace cdbApp.Server.Services;

public class CdbService : ICdbService
{
    private readonly IConfiguration _configuration;

    public CdbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public decimal GetCdi()
    {
        return _configuration.GetValue<decimal>("CdbSettings:Cdi")/100;
    }

    public decimal GetTax(int months)
    {
        return months switch
        {
            <= 6 => 0.225M,
            <= 12 => 0.2M,
            <= 24 => 0.175M,
            > 24 => 0.15M,
        };
    }

    public decimal GetTb()
    {
        return _configuration.GetValue<decimal>("CdbSettings:Tb") / 100;
    }
}
