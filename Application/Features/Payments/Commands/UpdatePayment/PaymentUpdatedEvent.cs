using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Payments.Commands.UpdatePayment
{
    public class PaymentUpdatedEvent : BaseEvent
    {
        public Payment Payment { get; }

        public PaymentUpdatedEvent(Payment payment)
        {
            Payment = payment;
        }
    }
}
