using System.Collections.Generic;
using System.Threading.Tasks;
using PoisnFang.ThirdParty.Models;

namespace PoisnFang.ThirdParty.Services
{
    public interface IThirdPartyService 
    {
        Task<List<Models.ThirdParty>> GetThirdPartysAsync(int ModuleId);

        Task<Models.ThirdParty> GetThirdPartyAsync(int ThirdPartyId, int ModuleId);

        Task<Models.ThirdParty> AddThirdPartyAsync(Models.ThirdParty ThirdParty);

        Task<Models.ThirdParty> UpdateThirdPartyAsync(Models.ThirdParty ThirdParty);

        Task DeleteThirdPartyAsync(int ThirdPartyId, int ModuleId);
    }
}
