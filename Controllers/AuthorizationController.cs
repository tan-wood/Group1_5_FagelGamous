using Group1_5_FagelGamous.Data.DTO.Authentication;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data.UnitOfWork;
using Group1_5_FagelGamous.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Group1_5_FagelGamous.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private  IUnitOfWork UOW { get; set; }  
        private ControllerHelper Helper { get; set; }
        public AuthorizationController(IUnitOfWork uow) 
        {
            UOW = uow;
            Helper = new ControllerHelper(UOW);
        }

        [HttpGet("verifyUser")]
        public IActionResult VerifyUser([FromBody] VerifyUserModel u)
        {
            
            try
            {
                //We are expecting that the database will not allow for duplicate emails
                var attemptUser = UOW.Users.Query().Include(x=>x.Role).Single(x=>x.Email == u.Email);
                
                if (attemptUser == null)
                {
                    return BadRequest(new JsonResult("This email does not exist for a current user."));

                }

                //calculate hash for to check password
                string checkHash = CalculateHash(u.Password);

                if(attemptUser.Password != checkHash)
                {
                    return BadRequest(new JsonResult("This password is incorrect"));
                }
                var json = Helper.DeCyclifyYoCode(attemptUser);
                return Ok(json);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editPassword")]
        public IActionResult EditPassword([FromBody] EditUserModel u)
        {
            
            //get user that has submitted the update request
            var userToUpdate = UOW.Users.Query().Include(x => x.Role).Single(x => x.Email == u.Email);
            if (userToUpdate == null) return BadRequest(new JsonResult("This user does not exist"));

            //verify the user has the current password
            if(userToUpdate.Password != u.CurrentPassword) return BadRequest(new JsonResult("The password is not correct"));

            Console.WriteLine(userToUpdate.Role.RoleName);

            //verify that they have access to edit
            if (userToUpdate.Role.RoleName == null) return BadRequest(new JsonResult("You do not have access to edit this"));

            //check to see if the password fits requirements
            if (u.NewPassword.Length! <= 14) return BadRequest(new JsonResult("The password must be atleast 14 characters"));

            //calculate password hash
            userToUpdate.Password = CalculateHash(u.NewPassword);
            
            try
            {
                //send it to db
                UOW.Users.Update(userToUpdate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            UOW.Complete();
            return Ok(new JsonResult("Your password has been updated"));
            

            
        }


        public string CalculateHash(string password)
        {

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            for(var i = 0; i < 1000; i++)
            {
                byte[] hashByte = SHA256.Create().ComputeHash(passwordBytes);
                passwordBytes = hashByte;
            }
            
            string hash = BitConverter.ToString(passwordBytes).Replace("-", "");
            return hash;
        }

        
        
        //TODO: figure out custom 2FA or MFA
    }
}
