using Domain.Common;
using Domain.Entities;


namespace Application.Features.Certifications.Commands.UpdateCertifications
{
    public class CertificationUpdatedEvent : BaseEvent
    {
        public Certification Certification { get; }


        public CertificationUpdatedEvent(Certification certification)
        {
            Certification = certification;
        }
    }
}
