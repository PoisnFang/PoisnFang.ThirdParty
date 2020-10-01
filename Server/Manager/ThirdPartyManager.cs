using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using PoisnFang.ThirdParty.Models;
using PoisnFang.ThirdParty.Repository;

namespace PoisnFang.ThirdParty.Manager
{
    public class ThirdPartyManager : IInstallable, IPortable
    {
        private IThirdPartyRepository _ThirdPartyRepository;
        private ISqlRepository _sql;

        public ThirdPartyManager(IThirdPartyRepository ThirdPartyRepository, ISqlRepository sql)
        {
            _ThirdPartyRepository = ThirdPartyRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "PoisnFang.ThirdParty." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "PoisnFang.ThirdParty.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.ThirdParty> ThirdPartys = _ThirdPartyRepository.GetThirdPartys(module.ModuleId).ToList();
            if (ThirdPartys != null)
            {
                content = JsonSerializer.Serialize(ThirdPartys);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.ThirdParty> ThirdPartys = null;
            if (!string.IsNullOrEmpty(content))
            {
                ThirdPartys = JsonSerializer.Deserialize<List<Models.ThirdParty>>(content);
            }
            if (ThirdPartys != null)
            {
                foreach(var ThirdParty in ThirdPartys)
                {
                    _ThirdPartyRepository.AddThirdParty(new Models.ThirdParty { ModuleId = module.ModuleId, Name = ThirdParty.Name });
                }
            }
        }
    }
}