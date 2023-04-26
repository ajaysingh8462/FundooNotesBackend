using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.EntityFrameworkCore.Update;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UserModel = CommonLayer.UserModel;

namespace BusinessLayer.Services
{
    public class UserBusiness: IUserBusiness
    {
        private readonly IUserRepository userRepository;
        

        public UserBusiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }
       

        public UserEntity UserRegistration(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                return userRepository.UserRegistration(userRegistrationModel);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public string loginAuthentication(UserModel userModel)
        {
            try
            {
                return userRepository.loginAuthentication(userModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ForgetPassword(GetForgetPassword getForgetPassword)
        {
            try
            {
                return userRepository.ForgetPassword(getForgetPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ResetPassword(string emailid, string password, string confirmpassword)
        {
            try
            {
                return userRepository.ResetPassword(emailid,password,confirmpassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<UserEntity> GetAllUser()
        {
            try
            {
                return userRepository.GetAllUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserTicket GetTicketForPass(GetForgetPassword getForgetPassword, string token)
        {
            try 
            {
                return userRepository.GetTicketForPass(getForgetPassword, token);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

    }
}
