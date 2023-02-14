using crudSimples.Models;
using Microsoft.EntityFrameworkCore;

namespace crudSimples.Infrastruture
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /************* 01 - forma de realizar a configuração de 1:1 ***************/
            //Com essa configuração eu devo ter a propriedade Id.
            modelBuilder
                .Entity<Cliente>()
                .HasOne(c => c.Endereco)
                .WithOne()
                .HasForeignKey("Endereco");

            /************* 02 - forma de realizar a configuração de 1:1 ************** */
            /// Quando o endereço não tiver uma propriedade Id, criamos abaixo uma propriedade usando "Shadow Property"
            //modelBuilder
            //    .Entity<Endereco>()
            //    .Property<int>("ClienteId"); //"Shadow Property"

            //modelBuilder
            //    .Entity<Endereco>()
            //    .HasKey("ClienteId");

            /************* Configuração para modificar nome da tabela, para as tabelas que não são manipuladas via propriedades DbSet<...>... ***************/
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EntityFrameDB;Trusted_Connection=true;");
}
}
}
