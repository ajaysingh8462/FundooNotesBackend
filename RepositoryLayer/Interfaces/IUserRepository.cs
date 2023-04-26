using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UserModel = CommonLayer.UserModel;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity UserRegistration(UserRegistrationModel userRegistrationModel);


        public string loginAuthentication(UserModel userModel);
        public string ForgetPassword(GetForgetPassword getForgetPassword);
        public bool ResetPassword(string emailid, string password, string confirmpassword);
        public List<UserEntity> GetAllUser();
        public UserTicket GetTicketForPass(GetForgetPassword getForgetPassword, string token);

    }
    
}
