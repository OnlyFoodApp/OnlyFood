using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Accounts.Queries.GetAccountsWithPagination;
using FluentValidation;

namespace Application.Features.Chef.Querries.GetChefsWithPagination
{
    public class GetChefsWithPaginationValidator : AbstractValidator<GetChefsWithPaginationQuery>
    {
        public GetChefsWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
