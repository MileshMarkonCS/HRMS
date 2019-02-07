using Microsoft.EntityFrameworkCore;
using ModelCore.FA.BK;
using ModelCore.FA.BK.Master;
using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using ModelCore.Security.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        // Misc
        public DbSet<SQLResult> DBResult { get; set; }
        public DbSet<IDModel> IDModel { get; set; }

        // Common
        public DbSet<SelectDdl> SelectDdl { get; set; }

        // User
        public DbSet<SignInUserProfile> SignInUserProfile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        // Regional
        public DbSet<CountryIndex> CountryIndex { get; set; }
        public DbSet<StateIndex> StateIndex { get; set; }
        public DbSet<CityIndex> CityIndex { get; set; }

        // Menus
        public DbSet<SpMenus> SpMenus { get; set; }
        // Screen Rights
        public DbSet<ScreenRight> GetScreenRights { get; set; }

        // Bank
        public DbSet<BankIndex> BankIndex { get; set; }

        // Page Events
        public DbSet<PageSortEntry> PageSortEntry { get; set; }

        // Ledger
        public DbSet<LedgerIndex> LedgerIndex { get; set; }
        public DbSet<LedgerEntry> LedgerEntry { get; set; }

        // Currency
        public DbSet<CurrencyIndex> CurrencyIndex { get; set; }
        public DbSet<CurrencyEntry> CurrencyEntry { get; set; }
    }
}
