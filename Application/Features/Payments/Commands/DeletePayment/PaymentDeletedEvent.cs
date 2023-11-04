using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Commands.DeletePayment
{
    
    public class PaymentDeletedEvent : BaseEvent
    {
        public Payment Payment { get; }

        public PaymentDeletedEvent(Payment payment)
        {
            Payment = payment;
        }
    }
}
