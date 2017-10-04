using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using TheJunction.Models;

namespace TheJunction.Data
{
    public class MyContext : DbContext
    {
        private IConfigurationRoot _config;

        public MyContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<CodeDesc> CodeDesc { get; set; }

        //public DbSet<DailySheet> DailySheets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHandbook> EmployeeHandbooks { get; set; }
        public DbSet<EmployeeHandbookAcceptance> EmployeeHandbookAcceptances { get; set; }
        //public DbSet<Inventory> Inventories { get; set; }
        //public DbSet<PumpPrice> PumpPrices { get; set; }
        //public DbSet<PumpPriceTank> PumpPriceTanks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftTradeRequest> ShiftTradeRequests { get; set; }
        public DbSet<TimeOffRequest> TimeOffRequests { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            if (isWindows)
            {
                optionsBuilder.UseSqlServer(_config["ConnectionStrings:TheJunctionContextConnectionWin"]);
            }
            else if (isMac)
            {
                optionsBuilder.UseSqlServer(_config["ConnectionStrings:TheJunctionContextConnectionOSX"]);
            }
        }
    }
}
