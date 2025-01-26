using Xunit;
using server.tests.Factories;
using cdbApp.Server.Models;
using server.tests.Shared;

namespace server.tests.Models
{
    public class CdbTests
    {        

        [Fact]
        public void Cdb_ShouldCalculateFinalValueCorrectly()
        {
            // Arrange
            var cdb = CdbFactory.CreateCdb(1000, 12, 0.15M, 0.02M, 0.2M);
            decimal expectedFinalValue = CalcFunctions.CalculateFinalValue(cdb.InitialValue, cdb.Months, 0.15M, 0.02M);

            // Act
            var finalValue = cdb.FinalValue;

            // Assert
            Assert.Equal(expectedFinalValue, finalValue);
        }

        [Fact]
        public void Cdb_ShouldCalculateFinalValueWithTaxCorrectly()
        {
            // Arrange
            var cdb = CdbFactory.CreateCdb(1000, 12, 0.15M, 0.02M, 0.2M);
            decimal expectedFinalValue = CalcFunctions.CalculateFinalValue(cdb.InitialValue, cdb.Months, 0.15M, 0.02M);
            decimal expectedFinalValueWithTax = CalcFunctions.CalculateFinalValueWithTax(expectedFinalValue, 0.2M);

            // Act
            var finalValueWithTax = cdb.FinalValueWithTax;

            // Assert
            Assert.Equal(expectedFinalValueWithTax, finalValueWithTax);
        }

        [Fact]
        public void Cdb_ShouldHaveCorrectInitialValue()
        {
            // Arrange
            var initialValue = 2000M;
            var cdb = CdbFactory.CreateCdb(initialValue, null, null, null, null);

            // Act & Assert
            Assert.Equal(initialValue, cdb.InitialValue);
        }

        [Fact]
        public void Cdb_ShouldHaveCorrectMonths()
        {
            // Arrange
            var months = 24;
            var cdb = CdbFactory.CreateCdb(null, months, null, null, null);

            // Act & Assert
            Assert.Equal(months, cdb.Months);
        }
    }
}
