using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Queries.GetCommemtByPostId
{
    public class GetCommemtByPostIdDto : IMapFrom<Comment>, IMapFrom<Account>
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public int? DisplayIndex { get; set; }
        public Guid? ParentCommentId { get; set; }
        public byte IsDeleted { get; set; }
        public string Username { get; set; }
        public byte ISEdited { get; set; }
    }
}
