using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(MailRequest mailRequest);
       
    }
}
