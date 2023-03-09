using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;
using UserModel = CommonLayer.UserModel;
namespace BusinessLayer.Interfaces
{
    public interface IUserBusiness
    {
        public UserEntity UserRegistration(UserRegistrationModel userRegistrationModel);
        public string loginAuthentication(UserModel userModel);
        public string ForgetPassword(GetForgetPassword getForgetPassword);
        public bool ResetPassword(string emailid, string password, string confirmpassword);
        public List<UserEntity> GetAllUser();


    }
}
