using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestDeveloper.Domen;

namespace TestDeveloper.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { 
        }

        public DbSet<KnowledgeTest> KnowledgeTests { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<SingleCaseQuestion> SingleCaseQuestions { get; set; } = null!;
        public DbSet<SingleCaseAnswer> SingleCaseAnswers { get; set; } = null!;
        public DbSet<MultipleCaseQuestion> MultipleCaseQuestions { get; set; } = null!;
        public DbSet<MultipleCaseAnswer> MultipleCaseAnswers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Answer>().ToTable("Answers");
            modelBuilder.Entity<SingleCaseQuestion>().ToTable("SingleCaseQuestions");
            modelBuilder.Entity<SingleCaseAnswer>().ToTable("SingleCaseAnswers");
            modelBuilder.Entity<MultipleCaseQuestion>().ToTable("MultipleCaseQuestions");
            modelBuilder.Entity<MultipleCaseAnswer>().ToTable("MultipleCaseAnswers");
        }
    }
}
