using BookingSystem.BusinessLogic.BusinesLogicModels;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(MailRequest mailRequest);

    }
}
