using BusinessLayer.Interfaces;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LableBusinessLayer: ILableBusinessLayer
    {
        private readonly ILableRepository lableRepository;

        public LableBusinessLayer(ILableRepository lableRepository)
        {
            this.lableRepository = lableRepository;
        }
        public LableEntity AddLable(string lablename, long noteid, long userid)
        {
            try
            {
                return lableRepository.AddLable(lablename, noteid,userid);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public LableEntity DeleteLable(long noteid,long userid)
        {
            try
            {
                return lableRepository.DeleteLable(noteid, userid);
            }
            catch(Exception ex) 
            {
                throw ex;   
            }
        }
        public LableEntity EditAddLable(string Newlablename, long notesid, long userid)

        {
            try
            {
                return lableRepository.EditAddLable(Newlablename, notesid, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public IEnumerable<LableEntity> DisplayLable(long noteid, long userid)
        {
            try
            {
                return lableRepository.DisplayLable(noteid, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
