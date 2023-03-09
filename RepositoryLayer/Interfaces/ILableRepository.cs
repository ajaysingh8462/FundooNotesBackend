using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILableRepository
    {
        public LableEntity AddLable(string lablename, long noteid, long userid);
        public LableEntity DeleteLable(long noteid, long userid);
        public LableEntity EditAddLable(string Newlablename, long notesid, long userid);
        public IEnumerable<LableEntity> DisplayLable(long noteid, long userid);




    }
}
