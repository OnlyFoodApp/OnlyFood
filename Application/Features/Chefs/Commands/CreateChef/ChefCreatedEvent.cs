using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Chef.Commands.CreateChef
{
    public class ChefCreatedEvent : BaseEvent
    {
    public Domain.Entities.Chef Chef { get; }


    public ChefCreatedEvent(Domain.Entities.Chef chef)
    {
        Chef = chef;
    }
    }
}
