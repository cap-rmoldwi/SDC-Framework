using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SDC.Schema;
using SDC.WebService.Models;
using SDC.WebService.Services;

namespace SDC.WebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SdcController : ControllerBase
    {
        private readonly ILogger<SdcController> _logger;
        private readonly IValidationService _validationService;

        public SdcController(ILogger<SdcController> logger, IValidationService validationService)
        {
            _logger = logger;
            _validationService = validationService;
        }

        [HttpPost]
        [Route("templates")]
        public ResponseModel<FormDesignType> CreateForm([FromBody] FormCreateModel model)
        {
            return new ResponseModel<FormDesignType>(null, new StatusInfo(true,
                new List<string> { "Message one", "message two" }));
        }

        [HttpGet]
        [Route("templates/{id?}")]
        public IEnumerable<string> GetTemplate()
        {
            return new string[] { "template info 1", "template info 2" };
        }

        [HttpPost]
        [Route("template/validate")]
        public ResponseModel<bool> ValidateTemplate([FromBody] string xmlFile)
        {
            StatusInfo result = _validationService.ValidateXml(xmlFile);
            return new ResponseModel<bool>(result.Success, result);

        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
