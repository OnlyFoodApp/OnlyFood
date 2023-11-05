using Domain.Common;
using Domain.Entities;

namespace Application.Features.Certifications.Commands.DeleteCertification
{
    public class CertificationDeletedEvent : BaseEvent
    {
        public Certification Certification { get; }

        public CertificationDeletedEvent(Certification certification)
        {
            Certification = certification;
        }
    }
}
