using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Posts.Queries.GetPostListByUser
{
    public class PostListItemModel
    {
        public string Message { get; set; }
        public string WhenPosted { get; set; }
    }
}
