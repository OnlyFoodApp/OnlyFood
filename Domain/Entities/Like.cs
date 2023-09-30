using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Like : BaseAuditableEntity
    {

        public Guid PostId { get; set; }

        public Guid AccountId { get; set; }
        public Post Post { get; set; }
        public Account Account { get; set; }
    }
}
