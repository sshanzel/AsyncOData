using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncOData.Entities
{
    public sealed class AsyncODataContext : DbContext
    {
        public AsyncODataContext(DbContextOptions options) : base(options)
        {
        }

        public void Seed()
        {
            if (!Posts.Any()) {
                Posts.AddRange(new List<Post> {
                    new Post { Title = "Async", Description = "OData" },
                    new Post { Title = "Test", Description = "OData" },
                    new Post { Title = "Sample", Description = "OData" }
                });
                SaveChanges();
            }

            if (!Tags.Any()) {
                Tags.AddRange(new List<Tag> {
                    new Tag { Title = "asp-core2.2" },
                    new Tag { Title = "odata4.0" },
                    new Tag { Title = "c#" }
                });
                SaveChanges();
            }

            if (!PostTags.Any()) {
                PostTags.AddRange(new List<PostTag> {
                    new PostTag { PostId = 1, TagId = 1 },
                    new PostTag { PostId = 1, TagId = 2 },
                    new PostTag { PostId = 1, TagId = 3 }
                });
                SaveChanges();
            }
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
    }
}
