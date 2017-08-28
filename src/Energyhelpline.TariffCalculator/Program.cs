using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Energyhelpline.TariffCalculator.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Energyhelpline.TariffCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var serviceProvider = Bootstrapper.ConfigureServices();

            var ui = serviceProvider.GetService<IUserInterface>();

            try
            {
                ui.PopulateQuote();
                ui.EmailQuote();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }
    }
}
