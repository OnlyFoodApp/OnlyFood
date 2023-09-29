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
    public Account Chef { get; }


    public ChefCreatedEvent(Account chef)
    {
        Chef = chef;
    }
    }
}
