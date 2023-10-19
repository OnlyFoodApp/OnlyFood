using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsDto : IMapFrom<Payment>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public byte IsActived { get; set; }
        public Guid CreateBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
