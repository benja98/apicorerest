using apicorerestsv.models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using MySQL.EntityFrameworkCore.Extensions;


namespace apicorerestsv
{

    public class AplicationDbContext: DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }

        public AplicationDbContext()
        { 
        
        }
        public AplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=ABMComentarios;Uid=root;Pwd=123456", ServerVersion.Create(new Version(1, 0, 0), ServerType.MySql));

            }


            //optionsBuilder.UseMySql(ServerVersion.AutoDetect("Server=localhost;Database=ABMComentarios;Uid=root;Pwd=Pa$$w0rd"));
           
        }
    }
}
