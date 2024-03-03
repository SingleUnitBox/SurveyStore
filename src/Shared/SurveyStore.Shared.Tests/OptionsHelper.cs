using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Tests
{
    public static class OptionsHelper
    {
        private const string AppSettings = "appsettings.test.json";
        public static TOptions GetOptions<TOptions>(string sectionName) where TOptions : class, new()
        {
            var options = new TOptions();
            var configuration = GetConfigurationRoot();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }

        public static IConfiguration GetConfigurationRoot()
            => new ConfigurationBuilder()
                .AddJsonFile(AppSettings)
                .AddEnvironmentVariables()
                .Build();
    }
}
