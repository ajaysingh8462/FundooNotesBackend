using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Common;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabeController : ControllerBase
    {
        private readonly ICollabeBusiness collabeBusiness;
        private readonly ILogger<CollabeController> logger;

        public CollabeController(ICollabeBusiness collabeBusiness, ILogger<CollabeController> logger)
        {
            this.collabeBusiness = collabeBusiness;
            this.logger = logger;
        }
        [Authorize]
        [HttpPost]
        [Route("AddCollabe")]
        public IActionResult AddCollabe(string emailid, long noteid)
        {
            try 
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var data = collabeBusiness.AddCollabe(emailid, noteid, userid);
                if (data != null)
                {
                    logger.LogInformation("collaberation successfully");
                    return this.Ok(new ResponseModel<CollabeEntity> { Status = true, Message = "collaberation done Successfully", Data = data });
                }
                else
                {
                    logger.LogWarning("collaberation Failed");
                   return this.BadRequest(new ResponseModel<CollabeEntity> { Status = true, Message = "collaberation UnSuccessfully", Data = data });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("CollabeRemove")]
        public IActionResult CollabeRemove( long noteid)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var data = collabeBusiness.CollabeRemove(noteid, userid);
                if (data != null)
                {
                    logger.LogInformation("Delete successfully");
                    return this.Ok(new ResponseModel<CollabeEntity> { Status = true, Message = "collaberation Remove Successfully", Data = data });
                }
                else
                {
                    logger.LogWarning("Delete Failed");
                    return this.BadRequest(new ResponseModel<CollabeEntity> { Status = true, Message = "collaberation Remove UnSuccessfully", Data = data });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("DisplayCollabe")]

        public IActionResult  DisplayCollabe(long noteid)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var data = collabeBusiness.DisplayCollabe(noteid, userid);
                if (data != null)
                {
                    logger.LogInformation("Display successfully");
                    return this.Ok(new ResponseModel<IEnumerable<CollabeEntity>> { Status = true, Message = "collaberation Display Successfully", Data = data });
                }
                else
                {
                    logger.LogWarning("Display Failed");
                    return this.BadRequest(new ResponseModel<IEnumerable<CollabeEntity>> { Status = true, Message = "collaberation Display UnSuccessfully", Data = data });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        

    }
}
