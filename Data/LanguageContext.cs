using Microsoft.EntityFrameworkCore;
using restful_crud_asp.net.Models;

namespace restful_crud_asp.Data
{
    public class LanguageContext : DbContext
    {
        public LanguageContext(DbContextOptions<LanguageContext> options) : base(options)
        {

        }

        public DbSet<Language>? Language {get; set;}
    }
}