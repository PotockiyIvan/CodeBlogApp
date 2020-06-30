using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CodeBlogFitness.dll.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CodeBlogFitness.BL.Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CodeBlogFitness.BL.Controller.FitnessContext";
        }

        protected override void Seed(CodeBlogFitness.BL.Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
