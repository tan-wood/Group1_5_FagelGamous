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
        public IActionResult VerifyUser([FromBody] VerifyUserDTO u)
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


        [HttpGet("getAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = UOW.Roles.GetAll().ToArray();
            return Ok(roles);
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = UOW.Users.GetAll().ToArray();
            return Ok(users);
        }

        [HttpPut("editPassword")]
        public IActionResult EditPassword([FromBody] ChangeUserPasswordDTO u)
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

        [HttpPut("editUser")]
        public IActionResult EditUser([FromBody] EditUserDTO e)
        {
            
            try
            {
                //gets the "admin user"
                var adminUser = UOW.Users.Query().Include(x => x.Role).Single(x => x.Email == e.AdminEmail);

                //if they do not have the administrator role, then they cannot perform this function.
                if (adminUser.Role.RoleName != "Administrator") return BadRequest(new JsonResult("This user is not authorized to perform this function"));
            }
            catch
            {
                // if the admin user doesnt exist, tell them
                return BadRequest(new JsonResult("Admin does not exist"));
            }
           
            // if they are authorized, then continue
            // get the current user's information
            var currentUserInfo = UOW.Users.GetById(e.UserId);

            if (currentUserInfo == null) return BadRequest(new JsonResult("This user does not exist"));

            //update this object
            currentUserInfo.RoleId = e.UserRoleId;
            currentUserInfo.FirstName = e.UserFirstName;
            currentUserInfo.Email = e.UserEmail;

            // try to update it
            try
            {
                UOW.Users.Update(currentUserInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            UOW.Complete();
            var json = Helper.DeCyclifyYoCode(currentUserInfo);
            return Ok(json);
            
        }

        /// <summary>
        /// If they have access to this button, they can use it. but if not they wont. Would be done with session cookie
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] NewUserDTO u)
        {

            //check to see if the password fits requirements
            if (u.TempPassword.Length! <= 14) return BadRequest(new JsonResult("The password must be atleast 14 characters"));

            //generate hash for password
            string hash = CalculateHash(u.TempPassword);
            User newUser = new(u.FirstName, u.Email, hash, u.RoleId);

            try
            {
                UOW.Users.Add(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            UOW.Complete();
            return Ok(newUser);
        }

        [HttpPost("createRole")]
        public IActionResult CreateRole([FromBody] CreateRoleDTO r)
        {
            Role newRole = new(r.NewRoleName);
            try
            {
                UOW.Roles.Add(newRole);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            UOW.Complete();
            return Ok(newRole);
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

        
        //TODO: figure out how to pass a token to the logged in admin so they can pass that back
        //TODO: figure out custom 2FA or MFA
       
        

    }
}
