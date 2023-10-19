using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Payments.Commands.CreatePayment
{
    public class PaymentCreateEvent : BaseEvent
    {
        public Payment Payment { get; }

        public PaymentCreateEvent(Payment payment)
        {
            Payment = payment;
        }
    }
}
