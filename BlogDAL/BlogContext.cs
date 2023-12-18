using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class BlogContext:DbContext
    {
        public BlogContext() : base("BlogContext")
        {
            Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; }
        public virtual DbSet<EmpInfo> EmpInfos { get; set; }
        public virtual DbSet<BlogInfo> BlogInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationship between EmpInfo and BlogInfo
            modelBuilder.Entity<BlogInfo>()
                        .HasRequired(b => b.Employee)
                        .WithMany(e => e.Blogs)
                        .HasForeignKey(b => b.EmpEmailId);

            // Additional configurations can be added here

            base.OnModelCreating(modelBuilder);
        }
    }
}
