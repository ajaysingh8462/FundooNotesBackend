using RepositoryLayer.Entity;
using RepositoryLayer.FundooDBcontext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public  class CollabeRepository: ICollabeRepository
    {
        private readonly FundooContext fundooContext;

        public CollabeRepository(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        public CollabeEntity AddCollabe(string emailid, long noteid, long userid)
        {
            try
            {
                CollabeEntity collabeEntity = new CollabeEntity();
                collabeEntity.CollabeEmail = emailid;
                collabeEntity.NotesId= noteid;
                collabeEntity.UserId=userid;

                fundooContext.CollabeTable.Add(collabeEntity);
                fundooContext.SaveChanges();
                return collabeEntity;   
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public CollabeEntity CollabeRemove(long noteid, long userid)
        {
            try
            {
                var find=fundooContext.CollabeTable.Where(e=>e.NotesId==noteid&&e.UserId==userid).FirstOrDefault();
                if (find != null)
                {
                    fundooContext.CollabeTable.Remove(find);
                    fundooContext.SaveChanges();
                    return find;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public IEnumerable<CollabeEntity> DisplayCollabe(long noteid, long userid)
        {
            try
            {
                var find = fundooContext.CollabeTable.Where(e => e.NotesId == noteid && e.UserId == userid);
                if(find != null)
                {
                    
                    return find;
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
    }
}
