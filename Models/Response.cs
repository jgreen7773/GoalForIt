using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalForIt.Models
{
    public class Response
    {
        [Key]
        public int ResponseId{get;set;}
        public string ResponseContent{get;set;}
        public int UserId{get;set;}
        public User Creator{get;set;}
        public int MessageId{get;set;}
        public Message FirstPlay{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
    }
}