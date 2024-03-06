using API_Azure_KeyValue.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Azure_KeyValue.Repositories
{
    public class ProductInfoRepo
    {
        IKeyVaultStoreManager mgr;
        EShoppingCodiContext ctx;

        public ProductInfoRepo(IKeyVaultStoreManager mgr, EShoppingCodiContext ctx)
        {
            this.mgr = mgr;
            this.ctx = ctx;
        }

        public async Task<List<ProductInfo>> GetProducts()
        {
            return await ctx.ProductInfos.ToListAsync();
        }
    }
}
