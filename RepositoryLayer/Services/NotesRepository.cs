using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooDBcontext;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRepository : INotesRepository
    {
        private readonly FundooContext fundoocontext;
        private IConfiguration configuration;

        public NotesRepository(FundooContext fundoocontext, IConfiguration configuration)
        {
            this.fundoocontext = fundoocontext;
            this.configuration = configuration;


        }
        public NotesEntity AddNotes(NoteRequestModel noteRequestModel, long userid)
        {

            try
            {
                NotesEntity notesEntity = new NotesEntity();
                notesEntity.Title = noteRequestModel.Title;
                notesEntity.Description = noteRequestModel.Description;
                notesEntity.Reminder = noteRequestModel.Reminder;
                notesEntity.Color = noteRequestModel.Color;
                notesEntity.Image = noteRequestModel.Image;
                notesEntity.Archive = noteRequestModel.Archive;
                notesEntity.PinNotes = noteRequestModel.PinNotes;
                notesEntity.Trash = noteRequestModel.Trash;
                notesEntity.Created = noteRequestModel.Created;
                notesEntity.Modified = noteRequestModel.Modified;
                notesEntity.UserId = userid;

                fundoocontext.NotesTable.Add(notesEntity);
                fundoocontext.SaveChanges();
                return notesEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //GET, DELETE,UPDATE
        public IEnumerable<NotesEntity> ShowNotes(long userid)
        {
            try
            {
                var getnotes = fundoocontext.NotesTable.Where(e => e.UserId == userid);
                if (getnotes != null)
                {
                    return getnotes;
                }
                else
                {
                    return null;
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NotesEntity DeleteNotes(long notesid, long userid)
        {


            try
            {
                var FindNotes = fundoocontext.NotesTable.Where(e => e.NotesId == notesid).FirstOrDefault();

                if (FindNotes != null)
                {
                    fundoocontext.Remove(FindNotes);
                    fundoocontext.SaveChanges();
                    return FindNotes;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public NotesEntity EditNotes(NoteRequestModel noteRequestModel, long notesid, long userid)
        {
            try
            {
                NotesEntity findNoteid = fundoocontext.NotesTable.Where(E => E.NotesId == notesid).FirstOrDefault();
                if (findNoteid != null)
                {
                    findNoteid.Title = noteRequestModel.Title;
                    findNoteid.Description = noteRequestModel.Description;
                    findNoteid.Color = noteRequestModel.Color;
                    findNoteid.Image = noteRequestModel.Image;
                    findNoteid.Archive = noteRequestModel.Archive;
                    findNoteid.PinNotes = noteRequestModel.PinNotes;
                    findNoteid.Trash = noteRequestModel.Trash;
                    findNoteid.Modified = noteRequestModel.Modified;
                    fundoocontext.NotesTable.Update(findNoteid);
                    fundoocontext.SaveChanges();
                    return findNoteid;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Archive(long notesid, long userid)
        {
            try
            {
                var findUserid = fundoocontext.NotesTable.Where(e => e.UserId == userid);
                if (findUserid != null)
                {
                    var findNotesid = fundoocontext.NotesTable.Where(x => x.NotesId == notesid).FirstOrDefault();
                    if (findNotesid.Archive == false)
                    {
                        findNotesid.Archive = true;
                        fundoocontext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool PinNotes(long notesid, long userid)
        {
            try
            {
                var findUserid = fundoocontext.NotesTable.Where(e => e.UserId == userid);
                if (findUserid != null)
                {
                    var findNotesid = fundoocontext.NotesTable.Where(x => x.NotesId == notesid).FirstOrDefault();
                    if (findNotesid.PinNotes == false)
                    {
                        findNotesid.PinNotes = true;
                        fundoocontext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public bool TrashNotes(long notesid, long userid)
        {
            var findUserid = fundoocontext.NotesTable.Where(e => e.UserId == userid);
            if (findUserid != null)
            {
                var findNotesid = fundoocontext.NotesTable.Where(x => x.NotesId == notesid).FirstOrDefault();
                if (findNotesid.Trash == false)
                {
                    findNotesid.Trash = true;
                    fundoocontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Color(long notesid, string color, long userid)
        {
            try
            {
                var findUserid = fundoocontext.NotesTable.Where(e => e.UserId == userid);
                if (findUserid != null)
                {
                    var findNotesid = fundoocontext.NotesTable.Where(x => x.NotesId == notesid).FirstOrDefault();
                    if (findNotesid.Color != null)
                    {
                        findNotesid.Color = color;
                        fundoocontext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public string UpdateImage(long notesid, long userid, IFormFile imgage)
        {
            try
            {
                var findUser = fundoocontext.NotesTable.FirstOrDefault(e => e.UserId == userid && e.UserId == userid);
                if (findUser != null)
                {
                    Account account = new Account(
                    this.configuration["CloudinarySettings:CloudName"],
                    this.configuration["CloudinarySettings:APIKey"],
                    this.configuration["CloudinarySettings:APISecret"]);

                    Cloudinary cloudinary = new Cloudinary(account);
                    var UploaadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(imgage.FileName, imgage.OpenReadStream()),
                    };
                    var UpdateResult = cloudinary.Upload(UploaadParams);
                    string imagePath = UpdateResult.Url.ToString();

                    findUser.Image = imagePath;
                    fundoocontext.SaveChanges();
                    return ("image Uploaded cb");

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<NotesEntity> DisplayAllNotes()
        {
            try
            {

                var getnotes = fundoocontext.NotesTable.ToList();
                if(getnotes!=null)
                {
                    return getnotes;

                }
                return null;
               
                

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
            

}

    

