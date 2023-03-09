using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ILableBusinessLayer
    {
        public LableEntity AddLable(string lablename, long noteid, long userid);
        public LableEntity DeleteLable(long noteid, long userid);
        public LableEntity EditAddLable(string Newlablename, long notesid, long userid);
        public IEnumerable<LableEntity> DisplayLable(long noteid, long userid);


    }
}
