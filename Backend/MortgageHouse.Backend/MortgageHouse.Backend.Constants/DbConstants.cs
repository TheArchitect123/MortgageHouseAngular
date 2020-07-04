using System;
using System.IO;

namespace MortgageHouse.Backend.Constants
{
    public struct DbConstants
    {
        public static string AccessConnectionString = $"Data Source={ConnectionString};";
        public static string ConnectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MortgageHouse\\MortgageHouseDb.db3");
        public static string ConnectionStringDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MortgageHouse");

        public const string MngrSchema = "MortgageHouseSchema";
    }
}
