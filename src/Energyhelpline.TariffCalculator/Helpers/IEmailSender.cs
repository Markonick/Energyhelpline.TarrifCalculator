namespace Energyhelpline.TariffCalculator.Helpers
{
    public interface IEmailSender
    {
        void SendEmail(string emailMessage);
    }
}