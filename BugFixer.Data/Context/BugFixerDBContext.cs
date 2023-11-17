using BugFixer.Domain.Models.Questions;
using BugFixer.Domain.Models.Resume;
using BugFixer.Domain.Models.Role;
using BugFixer.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BugFixer.Data.Context
{
    public class BugFixerDBContext : DbContext
    {
        public BugFixerDBContext(DbContextOptions<BugFixerDBContext> options) : base(options)
        {

        }

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Persmissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Follower> Followers { get; set; }

        #endregion

        #region Questions
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TrueAnswer> TrueAnswers { get; set; }
        public DbSet<QuestionRate>? QuestionRates { get; set; }
        #endregion

        #region ResumeSkills
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ResumeSkills> ResumeSkills { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Avoiding loops in database table relationships
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //End Avoiding loops in database table relationships

        }
    }
}


