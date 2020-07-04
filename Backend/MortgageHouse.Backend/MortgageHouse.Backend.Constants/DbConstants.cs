using System;
using System.IO;

namespace MortgageHouse.Backend.Constants
{
    public struct DbConstants
    {
        public static string ConnectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create), "MortgageHouse\\MortgageHouseDb.csv");
        public static string ConnectionStringDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create), "MortgageHouse");

        public const string MngrSchema = "MortgageHouseSchema";
    }
}
