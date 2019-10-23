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
    public class MessageController : Controller
    {
        private MyContext dbContext;
        public MessageController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("ProfileSetup")]
        public IActionResult Dashboard(int ActId)
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            return View();
        }

        [HttpGet]
        [Route("ManCave")]
        public IActionResult ManCave()
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            return View();
        }

        [HttpGet]
        [Route("SheShack")]
        public IActionResult SheShack()
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            return View();
        }

        [HttpGet]
        [Route("TheField")]
        public IActionResult TheField()
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            return View();
        }

        [HttpPost]
        [Route("ProcessProfileSetup")]
        public IActionResult ProcessProfileSetup()
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            return Redirect("/");
        }

        [HttpPost]
        [Route("ProcessCreateMessage")]
        public IActionResult ProcessCreateMessage(Message NewMessage)
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            NewMessage.UserId = LoggedUserId;
            if (ModelState.IsValid)
            {
                dbContext.Add(NewMessage);
                dbContext.SaveChanges();
                return Redirect("/TheField");
            }
            else
            {
                return View("TheField");
            }
        }

        // [HttpGet]
        // [Route("ProcessReact/{MessageId}")]
        // public IActionResult ProcessJoinAct(int MessageId)
        // {
        //     if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
        //     {
        //         return Redirect("/Login");
        //     }
        //     int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
        //     User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
        //     Association NewReaction = new Association();
        //     NewParticipant.UserId = LoggedUserId;
        //     NewParticipant.MessageId = MessageId;
        //     dbContext.Add(NewParticipant);
        //     dbContext.SaveChanges();
        //     return Redirect("/TheField");
        // }

        // [HttpGet]
        // [Route("ProcessCancelReact/{MessageId}")]
        // public IActionResult ProcessLeaveAct(int MessageId)
        // {
        //     if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
        //     {
        //         return Redirect("/Login");
        //     }
        //     int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
        //     User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
        //     Association Retrieve = dbContext.Associations.FirstOrDefault(a => a.ActId == ActId);
        //     dbContext.Associations.Remove(Retrieve);
        //     dbContext.SaveChanges();
        //     return Redirect("/Dashboard/{ActId}");
        // }





        [HttpGet]
        [Route("Delete/{MessageId}")]
        public IActionResult Delete(int MessageId)
        {
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int? LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            Message DeleteMessage = dbContext.Messages.FirstOrDefault(w => w.MessageId == MessageId);
            if (LoggedUserId == DeleteMessage.UserId)
            {
                dbContext.Messages.Remove(DeleteMessage);
                dbContext.SaveChanges();
                return Redirect("/TheField");
            }
            else
            {
                // logout?
                return Redirect("/Loggingout");
            }
        }
    }
}