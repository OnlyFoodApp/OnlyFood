using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries
{
    public class GetAllCommentsDto : IMapFrom<Comment>
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public int? DisplayIndex { get; set; }
        public Guid? ParentCommentId { get; set; }
        public byte IsDeleted { get; set; }
        public Account Account { get; set; }

        public byte ISEdited { get; set; }

    }
}
