namespace cdbApp.Server.Interfaces;

public interface ICdbService
{
    decimal GetTax(int months);
    decimal GetTb();
    decimal GetCdi();
}
