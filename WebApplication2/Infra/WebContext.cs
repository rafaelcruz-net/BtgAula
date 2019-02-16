using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Dominio;

namespace WebApplication2.Infra
{
    public class WebContext : DbContext
    {
        public WebContext() :base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("TblCliente");
            modelBuilder.Entity<Cliente>().HasKey(x => x.Id);
            modelBuilder.Entity<Cliente>().Property(x => x.Id).HasColumnName("nr_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Cliente>().Property(x => x.Agencia).HasColumnName("str_agencia").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Conta).HasColumnName("str_conta").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.CPF).HasColumnName("nr_cpf").HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Estado).HasColumnName("str_estado").HasMaxLength(30).IsOptional();
            modelBuilder.Entity<Cliente>().Property(x => x.Nome).HasColumnName("nm_nome").HasMaxLength(50).IsRequired();
        }
    }
}