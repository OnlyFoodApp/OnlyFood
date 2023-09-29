﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;

namespace Application.Features.Chef.Querries.GetAllChefs
{
    public class GetAllChefsDto : IMapFrom<Domain.Entities.Chef>
    {
        public string Experience { get; set; }
        public string? Awards { get; set; }

        // Navigation Property
        //public virtual Account Account { get; set; }
    }
}