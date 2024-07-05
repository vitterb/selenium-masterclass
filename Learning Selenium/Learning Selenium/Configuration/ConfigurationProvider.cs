using Microsoft.Extensions.Configuration;

namespace Learning_Selenium.Configuration
{
    internal class ConfigurationProvider
    {
        private static ConfigurationManager configuration;

        public static ConfigurationManager Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationManager();
                    configuration.
                        AddJsonFile("appsettings.local.json", false, false);
                }
                return configuration;
            }
        }
    }
}