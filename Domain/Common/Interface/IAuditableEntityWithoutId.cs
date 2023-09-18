using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Interface
{
    public interface IAuditableEntityWithoutId
    {
        Guid? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        Guid? ModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
