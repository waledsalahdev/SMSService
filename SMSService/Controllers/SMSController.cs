using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSService.Dto;
using SMSService.Services;

namespace SMSService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSServices _services;
         
        public SMSController(ISMSServices services)
        {
           _services = services;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(SendDto dto )
        {
            var res = await _services.SendSMS(dto.mobilenumber, dto.Body);
            if (!string.IsNullOrEmpty(res.ErrorMessage))
            {
                return BadRequest(res.ErrorMessage);
            }

            return Ok(res);
         }
    }
}
