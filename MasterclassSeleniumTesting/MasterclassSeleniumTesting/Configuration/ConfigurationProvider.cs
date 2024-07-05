using Microsoft.Extensions.Configuration;

namespace MasterclassSeleniumTesting.Configuration
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
                    configuration.AddJsonFile("settings.json", false, false);
                }
                return configuration;
            }
        }
    }
}