using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;
using RepositoryLayer.FundooDBcontext;
using CommonLayer;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LableController : ControllerBase
    {
        private readonly ILableBusinessLayer lableBusinessLayer;

        public LableController(ILableBusinessLayer lableBusinessLayer)
        {
            this.lableBusinessLayer = lableBusinessLayer;
        }
        [Authorize]
        [HttpPost]
        [Route("AddLable")]
        public IActionResult AddLable(string lablename, long noteid)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var result = lableBusinessLayer.AddLable(lablename,noteid,userid);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<LableEntity> { Status = true, Message = "Lable Add Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<LableEntity> { Status = false, Message = "UnSuccessfull", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteLable")]
        public IActionResult DeleteLable(long noteid)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var result = lableBusinessLayer.DeleteLable(noteid, userid);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<LableEntity> { Status = true, Message = "Lable Delete Successfully", Data = result });
                }
                else {
                    return this.BadRequest(new ResponseModel<LableEntity> { Status = false, Message = "UnSuccessfull", Data = result });
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
                    
        }
        [Authorize]
        [HttpPut]
        [Route("EditAddLable")]
        public IActionResult EditAddLable(string Newlablename, long notesid)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var result = lableBusinessLayer.EditAddLable(Newlablename, notesid ,userid);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<LableEntity> { Status = true, Message = "Lable Update Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<LableEntity> { Status = false, Message = "UnSuccessfull", Data = result });
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        [Authorize]
        [HttpGet]
        [Route("DisplayLable")]

        public IActionResult DisplayLable(long noteid)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var result = lableBusinessLayer.DisplayLable(noteid, userid);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<LableEntity>> { Status = true, Message = "Lable Display Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<IEnumerable<LableEntity>> { Status = false, Message = "UnSuccessfull", Data = result });
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }



    }
}
