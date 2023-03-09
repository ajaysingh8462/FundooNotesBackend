using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesBusiness notesBusiness;
        private readonly IDistributedCache distributedCache;

        public NotesController(INotesBusiness notesBusiness, IDistributedCache distributedCache)
        {
            this.notesBusiness = notesBusiness;
            this.distributedCache = distributedCache;
        }
        [Authorize]
        [HttpPost]
        [Route("AddNotes")]
        public IActionResult AddNotes(NoteRequestModel noteRequestModel)
        {
            try
            {
                long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
                var result = notesBusiness.AddNotes(noteRequestModel, userid);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<NotesEntity> { Status = true, Message = "Notes Add Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<NotesEntity> { Status = false, Message = "UnSuccessfull", Data = result });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("ShowNotes")]


        public IActionResult ShowNotes()
        {
            long userid = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "userid").Value);
            var result = notesBusiness.ShowNotes(userid);
            if (result != null)
            {
                return this.Ok(new ResponseModel<IEnumerable<NotesEntity>> { Status = true, Message = "Notes Add Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new ResponseModel<IEnumerable<NotesEntity>> { Status = false, Message = "UnSuccessfull", Data = result }); ;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteNotes")]
        public IActionResult DeleteNotes(long notesid)
        {
            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.DeleteNotes(notesid, userid);
            if (output != null)
            {
                return this.Ok(new ResponseModel<NotesEntity> { Status = true, Message = "Notes Delete Successfully" });
            }
            else
            {
                return this.BadRequest(new ResponseModel<NotesEntity> { Status = false, Message = "UnSuccessfull" });
            }

        }
        [Authorize]
        [HttpPut]
        [Route("EditNotes")]
        public IActionResult EditNotes(NoteRequestModel noteRequestModel, long notesid)
        {
            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.EditNotes(noteRequestModel, notesid, userid);
            if (output != null)
            {
                return this.Ok(new ResponseModel<NotesEntity> { Status = true, Message = "Notes Update Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<NotesEntity> { Status = false, Message = "UnSuccessfull", Data = output });
            }

        }
        [Authorize]
        [HttpPut]
        [Route("Archive")]
        public IActionResult Archive(long notesid)
        {
            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.Archive(notesid, userid);
            if (output != null)
            {
                return this.Ok(new ResponseModel<bool> { Status = true, Message = "Notes Add to Archive Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<bool> { Status = false, Message = "UnSuccessfull", Data = output });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("PinNotes")]
        public IActionResult PinNotes(long notesid)
        {
            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.PinNotes(notesid, userid);
            if (output != null)
            {
                return this.Ok(new ResponseModel<bool> { Status = true, Message = "Notes Pined Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<bool> { Status = false, Message = "UnSuccessfull", Data = output });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("TrashNotes")]
        public IActionResult TrashNotes(long notesid)
        {
            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.TrashNotes(notesid, userid);
            if (output != null)
            {
                return this.Ok(new ResponseModel<bool> { Status = true, Message = "Notes Add to Trash Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<bool> { Status = false, Message = "UnSuccessfull", Data = output });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("Color")]
        public IActionResult Color(long notesid, string color)
        {
            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.Color(notesid, color, userid);
            if (output != null)
            {
                return this.Ok(new ResponseModel<bool> { Status = true, Message = "Notes color Change Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<bool> { Status = false, Message = "UnSuccessfull", Data = output });
            }

        }
        [Authorize]
        [HttpPut]
        [Route("UpdateImage")]
        public IActionResult UpdateImage(long notesid, IFormFile imgage)
        {


            long userid = Convert.ToInt64(User.FindFirst(e => e.Type == "userid").Value);
            var output = notesBusiness.UpdateImage(notesid, userid, imgage);
            if (output != null)
            {
                return this.Ok(new ResponseModel<string> { Status = true, Message = "Notes color Change Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<string> { Status = false, Message = "UnSuccessfull", Data = output });
            }

        }
        [Authorize]
        [HttpGet]
        [Route("DisplayAllNotes")]
        public IActionResult DisplayAllNotes()
        {
            var output = notesBusiness.DisplayAllNotes();
            if (output != null)
            {
                return this.Ok(new ResponseModel<List<NotesEntity>> { Status = true, Message = "Get notes  Successfully", Data = output });
            }
            else
            {
                return this.BadRequest(new ResponseModel<List<NotesEntity>> { Status = false, Message = "UnSuccessfull", Data = output });
            }

        }
        [Authorize]
        [HttpGet]
        [Route("DisplayAllNotesUsingRedis")]
        public async Task<IActionResult> DisplayAllNotesUsingRedis()
        {
            try
            {
                var checkKey = "NotesKey";
                List<NotesEntity> notesList;
                byte[] RedisnotesList = await distributedCache.GetAsync(checkKey);
                if (RedisnotesList != null)
                {
                    var SerializedNoteList = Encoding.UTF8.GetString(RedisnotesList);
                    notesList = JsonConvert.DeserializeObject<List<NotesEntity>>(SerializedNoteList);
                }
                else
                {
                    notesList = (List<NotesEntity>)notesBusiness.DisplayAllNotes();
                    var SerializedNoteList = JsonConvert.SerializeObject(notesList);
                    var redisNotesList = Encoding.UTF8.GetBytes(SerializedNoteList);
                    var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)).SetSlidingExpiration(TimeSpan.FromMinutes(5));
                    await distributedCache.SetAsync(checkKey, redisNotesList, options);

                }
                return Ok(notesList);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }





    }
}

       
            
   