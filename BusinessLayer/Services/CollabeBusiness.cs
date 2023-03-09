using BusinessLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CollabeBusiness : ICollabeBusiness
    {
        private readonly ICollabeRepository collabeRepository;

        public CollabeBusiness(ICollabeRepository collabeRepository)
        {
            this.collabeRepository = collabeRepository;
        }
        public CollabeEntity AddCollabe(string emailid, long noteid, long userid)
        {
            try
            {
                return collabeRepository.AddCollabe(emailid, noteid, userid);
            }
            catch(Exception ex) 
            {
                throw ex;

            }
        }
        public CollabeEntity CollabeRemove(long noteid, long userid)
        {
            try
            {
                return collabeRepository.CollabeRemove(noteid, userid);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public IEnumerable<CollabeEntity> DisplayCollabe(long noteid, long userid)
        {
            try
            {
                return collabeRepository.DisplayCollabe(noteid, userid);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
