using CommonLayer;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRepository
    {
        public NotesEntity AddNotes(NoteRequestModel noteRequestModel, long userid);
        public IEnumerable<NotesEntity> ShowNotes(long userid);
        public NotesEntity DeleteNotes(long notesid, long userid);
        public NotesEntity EditNotes(NoteRequestModel noteRequestModel, long notesid, long userid);
        public bool Archive(long notesid, long userid);
        public bool PinNotes(long notesid, long userid);
        public bool TrashNotes(long notesid, long userid);
        public bool Color(long notesid, string color, long userid);
        public string UpdateImage(long notesid, long userid, IFormFile imgage);
        public List<NotesEntity> DisplayAllNotes();

    }
}
