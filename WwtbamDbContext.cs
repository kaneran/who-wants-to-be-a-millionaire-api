using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using who_wants_to_be_a_millionaire_api.Entities;

namespace who_wants_to_be_a_millionaire_api
{
    public class WwtbamDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public WwtbamDbContext(DbContextOptions<WwtbamDbContext> options) : base(options)
        {

        }


        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Question-Answer relationship
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.Question_ID)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as necessary

            // Configure Question-CorrectAnswer relationship
            //modelBuilder.Entity<Question>()
            //    .HasOne(q => q.CorrectAnswer)
            //    .WithMany()
            //    .HasForeignKey(q => q.Correct_Answer_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
