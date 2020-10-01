using Oqtane.Models;
using Oqtane.Modules;

namespace PoisnFang.ThirdParty
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "ThirdParty",
            Description = "ThirdParty",
            Version = "1.0.0",
            ServerManagerType = "PoisnFang.ThirdParty.Manager.ThirdPartyManager, PoisnFang.ThirdParty.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "PoisnFang.ThirdParty.Shared.Oqtane"
        };
    }
}
