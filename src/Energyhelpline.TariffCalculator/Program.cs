using System;
using System.Text;
using Energyhelpline.TariffCalculator.Models;
using Energyhelpline.TariffCalculator.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Energyhelpline.TariffCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var serviceProvider = Bootstrapper.ConfigureServices();
                var ui = serviceProvider.GetService<IUserInterface>();

                var input = PrepareInput();
                ui.ValidateInput(input);
                ui.PopulateQuote(input.GasUsage, input.ElectricityUsage, input.StartingDate);
                ui.EmailQuote();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }

        private static InputModel PrepareInput()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var configuration = Bootstrapper.GetConfiguration();

            var quoteSettings = configuration.GetSection("quoteSettings");

            return new InputModel
            {
                GasUsage = quoteSettings.GetValue<int>("GasUsage"),
                ElectricityUsage = quoteSettings.GetValue<int>("ElectricityUsage"),
                StartingDate = quoteSettings.GetValue<string>("StartingDate")
            };
        }
    }
}
