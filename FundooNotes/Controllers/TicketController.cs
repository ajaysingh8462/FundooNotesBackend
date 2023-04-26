using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using CommonLayer;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;
        private readonly IBus bus;

        public TicketController(IUserBusiness userBusiness,IBus bus)
        {
            this.userBusiness = userBusiness;
            this.bus = bus;
        }

        [HttpPost("ForgetPassword")]

        public async Task<IActionResult> GetTicketForPass(GetForgetPassword getForgetPassword)
        {
            try
            {
                if (getForgetPassword.EmailId != null)
                {
                    var token = userBusiness.ForgetPassword(getForgetPassword);
                    if (!string.IsNullOrEmpty(token))
                    {
                        var ticket = userBusiness.GetTicketForPass(getForgetPassword, token);
                        Uri uri = new Uri("rabbitmq://localhost/getTicketQueue");
                        var endPoint = await bus.GetSendEndpoint(uri);
                        return Ok(new { success = true, message = "Email Sent Successfully" });
                    }
                    else
                    {
                        return BadRequest(new { success = true, message = "Email Sent Successfully" });
                    }
                }
                else
                {
                    return BadRequest(new { success = true, message = "There is Some Issue" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
   
}
