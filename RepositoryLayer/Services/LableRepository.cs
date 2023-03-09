using RepositoryLayer.Entity;
using RepositoryLayer.FundooDBcontext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class LableRepository : ILableRepository
    {
        private readonly FundooContext fundooContext;
        
        public LableRepository(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
          

        }
        public LableEntity AddLable(string lablename, long noteid, long userid)
        {
            try
            {
                LableEntity lableEntity = new LableEntity();
                lableEntity.LableName =lablename;
                lableEntity.NotesId = noteid;
                lableEntity.UserId = userid;

                fundooContext.LableTable.Add(lableEntity);
                fundooContext.SaveChanges();
                return lableEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public LableEntity DeleteLable(long noteid, long userid)
        {
            try
            {
                var findLable = fundooContext.LableTable.Where(e => e.NotesId == noteid).FirstOrDefault();
                if (findLable != null)
                {
                    fundooContext.LableTable.Remove(findLable);
                    fundooContext.SaveChanges();
                    return findLable;
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
        public LableEntity EditAddLable(string Newlablename, long notesid, long userid)
        {
            try
            {
                LableEntity findLbableid = fundooContext.LableTable.Where(e => e.NotesId == notesid).FirstOrDefault();
                if(findLbableid!=null)
                {
                    findLbableid.LableName= Newlablename;
                    fundooContext.LableTable.Update(findLbableid);
                    fundooContext.SaveChanges();
                    return findLbableid;

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
        public IEnumerable<LableEntity> DisplayLable(long noteid ,long userid)
        {
            try
            {
                var FindNotesId = fundooContext.LableTable.Where(e => e.NotesId == noteid);
                if (FindNotesId != null)
                {
                    return FindNotesId;

                }
                else { return null; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
