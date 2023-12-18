using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class BlogInfoRepository
    {
        private BlogContext context;

        public BlogInfoRepository()
        {
            this.context = new BlogContext();
        }

        public void SaveBlogInfo(BlogInfo blogInfo)
        {
            context.BlogInfos.Add(blogInfo);
            context.SaveChanges();
        }

        public void UpdateBlogInfo(BlogInfo blogInfo)
        {
            context.Entry(blogInfo).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteBlogInfo(int blogId)
        {
            var blogToDelete = context.BlogInfos.Find(blogId);
            if (blogToDelete != null)
            {
                context.BlogInfos.Remove(blogToDelete);
                context.SaveChanges();
            }
        }

        public List<BlogInfo> GetAllBlogInfo()
        {
            return context.BlogInfos.ToList();
        }

        public BlogInfo GetBlogInfoById(int blogId)
        {
            return context.BlogInfos.Find(blogId);
        }
    }
}
