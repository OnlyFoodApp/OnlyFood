using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Orders.Queries.GetEarningDataOfCustomerBaseOnOrder
{
    public class GetEarningDataOfCustomerBaseOnOrderDto 
    {
        public float TotalAmount { get; set; }
        public string Title { get; set; }
    }
}
