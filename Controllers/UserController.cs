using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoalForIt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace GoalForIt.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static User GetObjectFromJson(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(User) : JsonConvert.DeserializeObject<User>(value);
        }
    }
    public class UserController : Controller
    {
        private MyContext dbContext;
        public UserController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult RedirectRoute()
        {
            return Redirect("/Registration");
        }

        [HttpGet]
        [Route("Registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("ProcessRegistration")]
        public IActionResult ProcessRegistration(User NewUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == NewUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Registration");
                }
                var Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                dbContext.Users.Add(NewUser);
                dbContext.SaveChanges();
                User UserInDB = dbContext.Users.FirstOrDefault(u => u.Email == NewUser.Email);
                User LoggedId = UserInDB;
                HttpContext.Session.SetObjectAsJson("LoggedUserEmail", LoggedId);
                return RedirectToAction("ProfileSetup");
            }
            return View("Registration");
        }

        [HttpPost]
        [Route("ProcessLogin")]
        public IActionResult ProcessLogin(LoginUser LoggingUser)
        {
            if(ModelState.IsValid)
            {
                User UserInDB = dbContext.Users.FirstOrDefault(u => u.Email == LoggingUser.LoginEmail);
                var LoginHasher = new PasswordHasher<LoginUser>();
                if(UserInDB == null)
                {
                    ModelState.AddModelError("LoginEmail", "Email or Password is Invalid!");
                    return View("Login");
                }
                else if(LoginHasher.VerifyHashedPassword(LoggingUser, UserInDB.Password, LoggingUser.LoginPassword) == PasswordVerificationResult.Success)
                {
                    User LoggedId = UserInDB;
                    HttpContext.Session.SetObjectAsJson("LoggedUserEmail", LoggedId);
                    return RedirectToAction("ProfileSetup");
                }
                else
                {
                    ModelState.AddModelError("LoginEmail", "Email or Password is Invalid!");
                    return View("Login");
                }
            }
            return View("Login");
        }

        [HttpPost]
        [Route("LoggingOut")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        [HttpPost]
        [Route("Delete/{MessageId}")]
        public IActionResult Delete()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}