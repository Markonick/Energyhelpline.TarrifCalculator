using System.Threading.Tasks;

namespace Energyhelpline.TariffCalculator.Services
{
    public interface IEmailService
    {
        Task SendEmail(string emailMessage);
    }
}