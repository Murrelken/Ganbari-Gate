using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Xamarin.Forms;

namespace GanbariGate.MobileAppService.Data
{
    public class GanbariGateContextFactory : IDesignTimeDbContextFactory<GanbariGateContext>
    {
        public GanbariGateContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GanbariGateContext>();
            builder.UseSqlServer(
                "Server=.;Initial Catalog=GanbariGate;Persist Security Info=False;Integrated Security=True;MultipleActiveResultSets=False;Connection Timeout=180;");

            return new GanbariGateContext(builder.Options);
        }
    }
}