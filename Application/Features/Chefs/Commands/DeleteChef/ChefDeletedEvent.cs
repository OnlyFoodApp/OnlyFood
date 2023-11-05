using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Chef.Commands.DeleteChef
{
    public class ChefDeletedEvent : BaseEvent
    {
    public Domain.Entities.Chef Chef { get; }


    public ChefDeletedEvent(Domain.Entities.Chef chef)
    {
        Chef = chef;
    }
    }
}
