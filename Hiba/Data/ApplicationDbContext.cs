using Hiba.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Pages { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<News> News { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CooperationAndPartners> CooperationAndPartners { get; set; }
        public DbSet<AddToYourInformation> AddToYourInformation { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }
        public DbSet<LectureWorkshop> LectureWorkshops { get; set; }
    }
}
