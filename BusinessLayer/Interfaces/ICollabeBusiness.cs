using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICollabeBusiness
    {
        public CollabeEntity AddCollabe(string emailid, long noteid, long userid);
        public CollabeEntity CollabeRemove(long noteid, long userid);
        public IEnumerable<CollabeEntity> DisplayCollabe(long noteid, long userid);

    }
}
