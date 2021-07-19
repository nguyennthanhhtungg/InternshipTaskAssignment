using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

namespace TaskAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValidationSchemaJSONController : ControllerBase
    {
        [HttpGet]
        public string Check([FromQuery] string strJObject, [FromQuery] string strJSchema)
        {
            JObject jObject = JObject.Parse(strJObject);

            JSchema jSchema = JSchema.Parse(strJSchema);

            bool isValid = ValidationSchemaJSON(jObject, jSchema);

            if (isValid == true)
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        private bool ValidationSchemaJSON(JObject jObject , JSchema jSchema)
        {
            return jObject.IsValid(jSchema);
        }
    }
}
