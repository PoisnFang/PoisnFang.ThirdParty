using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using PoisnFang.ThirdParty.Models;

namespace PoisnFang.ThirdParty.Repository
{
    public class ThirdPartyRepository : IThirdPartyRepository, IService
    {
        private readonly ThirdPartyContext _db;

        public ThirdPartyRepository(ThirdPartyContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.ThirdParty> GetThirdPartys(int ModuleId)
        {
            return _db.ThirdParty.Where(item => item.ModuleId == ModuleId);
        }

        public Models.ThirdParty GetThirdParty(int ThirdPartyId)
        {
            return _db.ThirdParty.Find(ThirdPartyId);
        }

        public Models.ThirdParty AddThirdParty(Models.ThirdParty ThirdParty)
        {
            _db.ThirdParty.Add(ThirdParty);
            _db.SaveChanges();
            return ThirdParty;
        }

        public Models.ThirdParty UpdateThirdParty(Models.ThirdParty ThirdParty)
        {
            _db.Entry(ThirdParty).State = EntityState.Modified;
            _db.SaveChanges();
            return ThirdParty;
        }

        public void DeleteThirdParty(int ThirdPartyId)
        {
            Models.ThirdParty ThirdParty = _db.ThirdParty.Find(ThirdPartyId);
            _db.ThirdParty.Remove(ThirdParty);
            _db.SaveChanges();
        }
    }
}
