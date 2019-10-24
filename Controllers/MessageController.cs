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
        public IActionResult ProfileSetup(int ActId)
        {
<<<<<<< HEAD
            // if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            // {
            //     return Redirect("/Login");
            // }
            // int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            // User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
=======
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            List<Message> connection = dbContext.Messages
            .ToList();
            ViewBag.Play = 544;
            foreach(Message m in connection)
            {
                if(m.Responses.Count == 5)
                {
                    ViewBag.Play += 15;
                }
                if(m.Responses.Count == 20)
                {
                    ViewBag.Play += 30;
                }
                if(m.Responses.Count > 30)
                {
                    ViewBag.Play += 60;
                }
                else
                {
                    ViewBag.Play -= 10;
                }

                
            }
            List <Response> contact = dbContext.Response.ToList();
            foreach(Response r in contact)
            {
                string[] strArray; 
                strArray = new string [] {"love","age","sexy","date","sex","meet","future","zodiac","name","kids","like"};
                foreach(string i in strArray)
                {
                    if(r.ResponseContent.Contains("i") == true)
                    {
                        ViewBag.Play += 2;
                    }
                    else
                    {
                        ViewBag.Play -= 1;
                    }
                }
                
            }
            foreach(Response r in contact)
            {
                string[] strArray2; 
                strArray2 = new string [] {"hate","ugly","money","ex","girlfriend","boyfriend","broke","bye","bitch","crazy","i'm criminal"};
                foreach(string i in strArray2)
                {
                    if(r.ResponseContent.Contains("i") == true)
                    {
                        ViewBag.Play -= 5;
                    }
                    else
                    {
                        ViewBag.Play += 5;
                    }
                }
                
            }
>>>>>>> 3801f3d541c5e7b463d25ca1198c7823f120637b
            return View();
        }

        [HttpGet]
        [Route("ManCave")]
        public IActionResult ManCave()
        {
            // if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            // {
            //     return Redirect("/Login");
            // }
            // int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            // User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
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
<<<<<<< HEAD
            // if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            // {
            //     return Redirect("/Login");
            // }
            // int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            // User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
=======
            if (HttpContext.Session.GetObjectFromJson("LoggedUserEmail") == null)
            {
                return Redirect("/Login");
            }
            int LoggedUserId = HttpContext.Session.GetObjectFromJson("LoggedUserEmail").UserId;
            User LoggedUser = HttpContext.Session.GetObjectFromJson("LoggedUserEmail");
            
            List<Message> connection = dbContext.Messages
            .Include(w=> w.Responses)
            .ToList();
            ViewBag.Connections = connection;
            ViewBag.Play = 50;
         
>>>>>>> 3801f3d541c5e7b463d25ca1198c7823f120637b
            return View();
        }

        [HttpPost]
        [Route("ProcessProfileSetup")]
        public IActionResult ProcessProfileSetup(Message NewMessage)
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


// ViewBag.loggedIn = (int)LoggedIn;
            
//             List<Motion> allMotions = dbContext.Motion.OrderBy(t=> t.Date)
//             .Include(i=> i.Creator)
//             .Include(w => w.GuestAttending)
//             .ThenInclude(u=> u.Guest)
//             .ToList();
//             foreach(Motion i in allMotions)
//             {
//                 DateTime done = i.Date;
//                 System.Console.WriteLine($"################### {done}");
//                 System.Console.WriteLine(DateTime.Now);
//                 if(done < DateTime.Now)
//                 {
//                     dbContext.Motion.Remove(i);
//                 }
//             }
//             dbContext.SaveChanges();
//             return View(allMotions);