using Microsoft.EntityFrameworkCore;
using PaelytDocumentInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paelyt_Data_System.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<PersonalImage> PersonalImages { get; set; }
    }
}
