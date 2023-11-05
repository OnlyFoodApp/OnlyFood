using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Menus.Commands.UpdateMenu
{
    
    public class MenuUpdatedEvent : BaseEvent
    {
        public Menu Menu { get; }


        public MenuUpdatedEvent(Menu menu)
        {
            Menu = menu;
        }
    }
}
