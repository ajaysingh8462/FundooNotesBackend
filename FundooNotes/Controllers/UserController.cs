using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using UserModel = CommonLayer.UserModel;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;
        private readonly ILogger<UserController> logger;
        public UserController(IUserBusiness userBusiness, ILogger<UserController> logger)
        {
            this.userBusiness = userBusiness;
            this.logger = logger;
        }
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult UserRegister(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                var result = userBusiness.UserRegistration(userRegistrationModel);
                if (result != null)
                {
                    logger.LogInformation("User register suvccessfully");
                    return this.Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register Successfull", Data = result });
                }
                else
                {
                    logger.LogWarning("usser Ragister falied");
                    return this.BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Register UnSuccessfull", Data = result });
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LoginAuthentication(UserModel userModel)
        {
            try
            {
                
                var result1 = userBusiness.loginAuthentication(userModel);
                if (result1 != null)
                {

                    //SetSession(result1);
                    //var Name = HttpContext.Session.GetString("UserName");
                    //var userid = HttpContext.Session.GetInt32("Emailid");
                    logger.LogInformation("User login successfully");
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Log in successfull", Data = result1 });
                }
                else
                {
                    logger.LogWarning("User login Failed");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Log in Failed", Data = result1 });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public void SetSession(UserRegistrationModel userModel)
        //{
        //    HttpContext.Session.SetString("UserName", userModel.FirstName + " " + userModel.LastName);
        //    HttpContext.Session.SetString("Emailid", userModel.EmailId);
        //}
        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(GetForgetPassword getForgetPassword)
        {
            try
            {
                var result1 = userBusiness.ForgetPassword(getForgetPassword);
                if (result1 != null)
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Message send successfully", Data = result1 });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "UnSuccessfull", Data = result1 });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }






        }
        [Authorize]
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string password, string confirmpassword)
        {
            try
            {
                var emailid = User.FindFirst(E => E.Type == "Emailid").Value;
                var result1 = userBusiness.ResetPassword(emailid, password, confirmpassword);
                if (result1 != null)
                {
                    return this.Ok(new ResponseModel<bool> { Status = true, Message = "Password reset successfully", Data = result1 });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<bool> { Status = false, Message = "UnSuccessfull", Data = result1 });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpGet]
        [Route("GetAallUser")]
        public IActionResult GetAallUser()
        {
            try
            {
                var userDetails = userBusiness.GetAllUser();
                if (userDetails != null)
                {
                    return this.Ok(new ResponseModel<List<UserEntity>> { Status = true, Message = "Display all user Successfully", Data = userDetails });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<UserEntity>> { Status = false, Message = "Display all user Unsuccessfully", Data = userDetails });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                    
        }
    }
}

