using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CLHBankApp.Models.CLHBankAppContext
{
    public class CLHBankAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;port=3306;Database=CLHBankApp;Uid=root;Pwd=1234");
        }
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Transaction> Transactions { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Address> Addresses { get; set; } 
        

    }
}