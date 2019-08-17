using System;
using Microsoft.EntityFrameworkCore;

namespace loggerapi.Models
{
    public class LoggerApiContext : DbContext
    {
        public LoggerApiContext(DbContextOptions<LoggerApiContext> options) : base(options)
        {
        }

        public DbSet<LogDocument> LogDocuments { get; set; }
    }
}
