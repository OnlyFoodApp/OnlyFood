using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certifications.Commands
{
    public class CertificationCreateEvent : BaseEvent
    {
        public Certification Certification { get; }


        public CertificationCreateEvent(Certification Certification)
        {
            Certification = Certification;
        }
    }
}
