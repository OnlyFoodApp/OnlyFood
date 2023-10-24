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
        public Guid AccountId { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public int? DisplayIndex { get; set; }
        public Guid? ParentCommentId { get; set; } = Guid.Empty;
        public virtual Comment ParentComment { get; set; }
        public virtual Post Post { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Comment>? ChildComments { get; set; }
        public byte IsDeleted { get; set; }

        public byte ISEdited { get; set; }

    }
}
