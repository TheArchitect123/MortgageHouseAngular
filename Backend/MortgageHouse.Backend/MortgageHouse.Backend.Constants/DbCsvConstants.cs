using System;
using System.IO;

namespace MortgageHouse.Backend.Constants
{
    public struct DbCsvConstants
    {
        public static string AccessConnectionString = $"Data Source={ConnectionString};";
        public static string ConnectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MortgageHouse\\MortgageHouseDb.csv");
        public static string ConnectionStringDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MortgageHouse");

        public const string MngrSchema = "MortgageHouseSchema";
    }
}
