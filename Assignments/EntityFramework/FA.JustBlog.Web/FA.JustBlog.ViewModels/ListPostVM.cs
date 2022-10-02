using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels
{
    public class ListPostVM
    {
        public IEnumerable<Posts> FiveMostViewedPosts { get; set; } = new List<Posts>();
        public IEnumerable<Posts> FiveLatestPosts { get; set; } = new List<Posts>();
    }
}
