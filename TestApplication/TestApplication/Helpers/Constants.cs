using System.Collections.Generic;

namespace TestApplication.Helpers
{
    public struct Constants
    {
        public static string DefaultProductsPath = "Resources/UpTypes.csv";
        public static string DatabaseName = "Our_PCDB";

        public static List<string> DefaultTables
        {
            get
            {
                var defaults = new List<string>();
                defaults.Add(DefaultProductsPath);
                return defaults;
            }
        } 
    }
}
