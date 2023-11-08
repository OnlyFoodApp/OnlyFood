using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Queries.GetPostByAccountId
{
    public class GetPostByAccountIdDto : IMapFrom<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AccountID { get; set; }
        public int DisplayIndex { get; set; }
        public string MediaURLs { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }
        public Account Account { get; set; }
    }
}
