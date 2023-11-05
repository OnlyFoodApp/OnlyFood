using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Menus.Commands.DeleteMenu
{
   
    public class MenuDeletedEvent : BaseEvent
    {
        public Menu Menu { get; }


        public MenuDeletedEvent(Menu menu)
        {
            Menu = menu;
        }
    }
}
