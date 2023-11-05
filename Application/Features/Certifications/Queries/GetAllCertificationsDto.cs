using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certifications.Queries
{
    public class GetAllCertificationsDto : IMapFrom<Certification>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ChefID { get; set; }
        public string IssuingAuthority { get; set; }
        public string CertificationDescription { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string CertificationURL { get; set; }
        public byte IsValid { get; set; }
        
    }
}
