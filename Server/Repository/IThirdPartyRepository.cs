using System.Collections.Generic;
using PoisnFang.ThirdParty.Models;

namespace PoisnFang.ThirdParty.Repository
{
    public interface IThirdPartyRepository
    {
        IEnumerable<Models.ThirdParty> GetThirdPartys(int ModuleId);
        Models.ThirdParty GetThirdParty(int ThirdPartyId);
        Models.ThirdParty AddThirdParty(Models.ThirdParty ThirdParty);
        Models.ThirdParty UpdateThirdParty(Models.ThirdParty ThirdParty);
        void DeleteThirdParty(int ThirdPartyId);
    }
}
