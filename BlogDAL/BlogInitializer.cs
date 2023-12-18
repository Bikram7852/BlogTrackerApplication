using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class BlogInitializer: DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            
            var admin = new AdminInfo
            {
                EmailId = "admin@example.com",
                Password = "admin123"
            };
            context.AdminInfos.Add(admin);

            context.SaveChanges();
        }
    }
}
