using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using PoisnFang.ThirdParty.Models;
using PoisnFang.ThirdParty.Repository;

namespace PoisnFang.ThirdParty.Controllers
{
    [Route("{alias}/api/[controller]")]
    public class ThirdPartyController : Controller
    {
        private readonly IThirdPartyRepository _ThirdPartyRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public ThirdPartyController(IThirdPartyRepository ThirdPartyRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _ThirdPartyRepository = ThirdPartyRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = "ViewModule")]
        public IEnumerable<Models.ThirdParty> Get(string moduleid)
        {
            return _ThirdPartyRepository.GetThirdPartys(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ViewModule")]
        public Models.ThirdParty Get(int id)
        {
            Models.ThirdParty ThirdParty = _ThirdPartyRepository.GetThirdParty(id);
            if (ThirdParty != null && ThirdParty.ModuleId != _entityId)
            {
                ThirdParty = null;
            }
            return ThirdParty;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "EditModule")]
        public Models.ThirdParty Post([FromBody] Models.ThirdParty ThirdParty)
        {
            if (ModelState.IsValid && ThirdParty.ModuleId == _entityId)
            {
                ThirdParty = _ThirdPartyRepository.AddThirdParty(ThirdParty);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "ThirdParty Added {ThirdParty}", ThirdParty);
            }
            return ThirdParty;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "EditModule")]
        public Models.ThirdParty Put(int id, [FromBody] Models.ThirdParty ThirdParty)
        {
            if (ModelState.IsValid && ThirdParty.ModuleId == _entityId)
            {
                ThirdParty = _ThirdPartyRepository.UpdateThirdParty(ThirdParty);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "ThirdParty Updated {ThirdParty}", ThirdParty);
            }
            return ThirdParty;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "EditModule")]
        public void Delete(int id)
        {
            Models.ThirdParty ThirdParty = _ThirdPartyRepository.GetThirdParty(id);
            if (ThirdParty != null && ThirdParty.ModuleId == _entityId)
            {
                _ThirdPartyRepository.DeleteThirdParty(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "ThirdParty Deleted {ThirdPartyId}", id);
            }
        }
    }
}
