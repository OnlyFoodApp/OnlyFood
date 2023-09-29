using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Chef.Querries.GetChefsWithPagination
{
    public class GetChefsWithPaginationDto
    {
        public string Experience { get; set; }
        public string? Awards { get; set; }

        // Navigation Property
        public virtual Account Account { get; set; }
    }
}
