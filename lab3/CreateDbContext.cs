using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Lab1.Database;

public class DatabaseContextContextFactory : IDesignTimeDbContextFactory<PeopleDb>
{
    public PeopleDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PeopleDb>();
        optionsBuilder.UseSqlServer("Server=tcp:plserwer2.database.windows.net,1433;Initial Catalog=iotdb;Persist Security Info=False;User ID=aburdelski;Password=Adibek1111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        return new PeopleDb(optionsBuilder.Options);
    }
}