using Microsoft.EntityFrameworkCore;
using MvcCoreEFProcedures.Models;

namespace MvcCoreEFProcedures.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            :base(options) { }
        public DbSet<Enfermo> Enfermos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
