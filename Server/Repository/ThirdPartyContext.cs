using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using PoisnFang.ThirdParty.Models;

namespace PoisnFang.ThirdParty.Repository
{
    public class ThirdPartyContext : DBContextBase, IService
    {
        public virtual DbSet<Models.ThirdParty> ThirdParty { get; set; }

        public ThirdPartyContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
