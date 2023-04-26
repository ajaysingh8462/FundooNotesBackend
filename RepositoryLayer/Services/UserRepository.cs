using CommonLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooDBcontext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UserModel = CommonLayer.UserModel;

namespace RepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly FundooContext fundoocontext;
        private readonly IConfiguration configuration;


        public UserRepository(FundooContext fundoocontext, IConfiguration configuration)
        {
            this.fundoocontext = fundoocontext;
            this.configuration = configuration;
        }
        public UserEntity UserRegistration(UserRegistrationModel userRegistrationModel)
        {

            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userRegistrationModel.FirstName;
                userEntity.LastName = userRegistrationModel.LastName;
                userEntity.EmailId = userRegistrationModel.EmailId;
                userEntity.Password = PasswordEncryption(userRegistrationModel.Password);
                fundoocontext.UserTable.Add(userEntity);
                fundoocontext.SaveChanges();
                return userEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string PasswordEncryption(string password)
        {
            var encryption = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encryption);
        }
        //log in and Genrate token
        public string loginAuthentication(UserModel userModel)
        {
            var currentUser = fundoocontext.UserTable.FirstOrDefault(x => x.EmailId == userModel.EmailId && x.Password == PasswordEncryption(userModel.Password));
            if (currentUser != null)
            {
                return GenerateToken(currentUser.UserId, userModel.EmailId);
            }
            else
            {
                return null;
            }
        }
        private string GenerateToken(long userid, string Emailid)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismysecrettokenkey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Emailid", Emailid),
                new Claim("userid",userid.ToString())
            };
            var token = new JwtSecurityToken(
                issuer:configuration["Jwt:Issuer"],
                audience:configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public string ForgetPassword(GetForgetPassword getForgetPassword)
        {
            try
            {


                var userDetails = fundoocontext.UserTable.Where(u => u.EmailId == getForgetPassword.EmailId).FirstOrDefault();
                if (userDetails != null)
                {
                    var token = GenerateToken(userDetails.UserId, userDetails.EmailId);
                    new MSMQModel().sendDatatoQueue(token, userDetails.EmailId, userDetails.FirstName);
                    return token;


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
        public bool ResetPassword(string emailid,string password ,string confirmpassword)
        {
            try
            {
                

                if (password.Equals(confirmpassword))
                {
                    var userDetails = fundoocontext.UserTable.Where(u => u.EmailId == emailid).FirstOrDefault();
                    userDetails.Password = PasswordEncryption(confirmpassword);
                    fundoocontext.SaveChanges();
                    return true;

                }
                else
                    return false;
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
                var getUser = fundoocontext.UserTable.ToList();
                return getUser;
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
                var user = fundoocontext.UserTable.Where(u => u.EmailId == getForgetPassword.EmailId).FirstOrDefault();

                if (user != null)
                {
                    UserTicket ticket = new UserTicket
                    {

                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        emailId = user.EmailId,
                        Token = token,
                        issueAt = DateTime.Now

                    };
                    return ticket;  

                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }







    }



}
