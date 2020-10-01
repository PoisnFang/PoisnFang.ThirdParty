using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using PoisnFang.ThirdParty.Models;

namespace PoisnFang.ThirdParty.Services
{
    public class ThirdPartyService : ServiceBase, IThirdPartyService, IService
    {
        private readonly SiteState _siteState;

        public ThirdPartyService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "ThirdParty");

        public async Task<List<Models.ThirdParty>> GetThirdPartysAsync(int ModuleId)
        {
            List<Models.ThirdParty> ThirdPartys = await GetJsonAsync<List<Models.ThirdParty>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return ThirdPartys.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.ThirdParty> GetThirdPartyAsync(int ThirdPartyId, int ModuleId)
        {
            return await GetJsonAsync<Models.ThirdParty>(CreateAuthorizationPolicyUrl($"{Apiurl}/{ThirdPartyId}", ModuleId));
        }

        public async Task<Models.ThirdParty> AddThirdPartyAsync(Models.ThirdParty ThirdParty)
        {
            return await PostJsonAsync<Models.ThirdParty>(CreateAuthorizationPolicyUrl($"{Apiurl}", ThirdParty.ModuleId), ThirdParty);
        }

        public async Task<Models.ThirdParty> UpdateThirdPartyAsync(Models.ThirdParty ThirdParty)
        {
            return await PutJsonAsync<Models.ThirdParty>(CreateAuthorizationPolicyUrl($"{Apiurl}/{ThirdParty.ThirdPartyId}", ThirdParty.ModuleId), ThirdParty);
        }

        public async Task DeleteThirdPartyAsync(int ThirdPartyId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{ThirdPartyId}", ModuleId));
        }
    }
}
