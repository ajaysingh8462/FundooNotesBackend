using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Migrations;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BusinessLayer.Services
{
    public class NotesBusiness: INotesBusiness
    {
        private readonly INotesRepository notesRepository;

        public NotesBusiness(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }
        public NotesEntity AddNotes(NoteRequestModel noteRequestModel, long userid)
        {
            try
            {
                return notesRepository.AddNotes(noteRequestModel,userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<NotesEntity> ShowNotes( long userid)
        {
            try
            {
                return notesRepository.ShowNotes(userid);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public NotesEntity DeleteNotes(long notesid, long userid)
        {
            try
            {
                return notesRepository.DeleteNotes(notesid, userid);

            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public NotesEntity EditNotes(NoteRequestModel noteRequestModel, long notesid, long userid)
        {
            try
            {
                return notesRepository.EditNotes(noteRequestModel, notesid, userid);
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
                return notesRepository.Archive(notesid, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PinNotes(long notesid, long userid)
        {
            try
            {
                return notesRepository.PinNotes(notesid, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool TrashNotes(long notesid, long userid)
        {
            try
            {
                return notesRepository.TrashNotes(notesid, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Color(long notesid, string color, long userid)
        {
            try
            {
                return notesRepository.Color(notesid, color, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateImage(long notesid, long userid, IFormFile imgage)
        {
            try
            {
                return notesRepository.UpdateImage(notesid,userid,imgage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NotesEntity> DisplayAllNotes()
        {
            try
            {
                return notesRepository.DisplayAllNotes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    
}
