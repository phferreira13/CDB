using Bogus;
using cdbApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.tests.Factories;
public static class CdbFactory
{
    public static Cdb CreateCdb(decimal? initialValue, int? months, decimal? tb, decimal? cdi, decimal? tax)
    {
        var faker = new Faker("pt_BR");
        return new Cdb(
            initialValue ?? faker.Finance.Amount(), 
            months ?? faker.Random.Int(1, 60), 
            tb ?? faker.Random.Decimal(0.1M, 0.2M), 
            cdi ?? faker.Random.Decimal(0.01M, 0.02M), 
            tax ?? faker.Random.Decimal(0.1M, 0.3M));
    }
}
