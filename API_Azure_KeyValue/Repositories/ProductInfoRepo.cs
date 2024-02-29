using API_Azure_KeyValue.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Azure_KeyValue.Repositories
{
    public class ProductInfoRepo
    {
        IKeyVaultManager mgr;
        EShoppingCodiContext ctx;

        public ProductInfoRepo(IKeyVaultManager mgr, EShoppingCodiContext ctx)
        {
            this.mgr = mgr;
            this.ctx = ctx;

            //var conn = this.mgr.GetSecret("connstr").Result;

            //this.ctx.Database.SetConnectionString(conn);
        }


        public async Task<List<ProductInfo>> GetProducts()
        {
            return await ctx.ProductInfos.ToListAsync();
        }
    }
}
