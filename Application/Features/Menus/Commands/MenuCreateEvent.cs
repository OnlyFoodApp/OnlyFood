using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Menus.Commands
{
    public class MenuCreateEvent : BaseEvent
    {
        public Menu Menu { get; }


        public MenuCreateEvent(Menu Menu)
        {
            Menu = Menu;
        }
    }
}
