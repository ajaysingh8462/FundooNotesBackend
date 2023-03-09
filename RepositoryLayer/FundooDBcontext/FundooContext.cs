using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.FundooDBcontext
{
    public class FundooContext :DbContext
    {
        public FundooContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<NotesEntity> NotesTable { get; set; }
        public DbSet<LableEntity> LableTable { get; set; }
        public DbSet<CollabeEntity> CollabeTable { get; set; }
    }
}
