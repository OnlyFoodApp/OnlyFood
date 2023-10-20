using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Orders.Queries.BaseEarning;
using Application.Features.Orders.Queries.GetEarningDataOfCustomerBaseOnOrder;
using Application.Features.Orders.Queries.GetEarningDataOfProductBaseOnOrder;
using Application.Features.Orders.Queries.GetEarningDataOfSalesBaseOnOrder;

namespace Application.Features.Orders.Queries.GetEarningDataBaseOnOrder
{
    public class GetEarningDataBaseOnOrderDto
    {


        public GetEarningDataOfCustomerBaseOnOrderDto Customer { get; set; }
        public GetEarningDataOfProductBaseOnOrderDto Product { get; set; }
        public GetEarningDataOfSalesBaseOnOrderDto Sales { get; set; }

        public GetEarningDataBaseOnOrderDto()
        {
            Customer = new GetEarningDataOfCustomerBaseOnOrderDto();
            Product = new GetEarningDataOfProductBaseOnOrderDto();
            Sales = new GetEarningDataOfSalesBaseOnOrderDto();
        }
    }
}
