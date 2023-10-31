﻿using BugFixer.Domain.Models.Resume;
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

        #endregion

        public DbSet<Resume> Resumes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
