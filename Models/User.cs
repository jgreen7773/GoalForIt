using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalForIt.Models
{
    public class User
    {
        [Key]
        public int UserId{get;set;}
        [Required]
        public string Name{get;set;}
        public string Gender{get;set;}
        [Required]
        [EmailAddress]
        public string Email{get;set;}
        [DataType(DataType.Password)]
        [Required]
        public string Password{get;set;}
        [NotMapped]
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword{get;set;}
        [NotMapped]
        public List<Message> MessageToUser{get;set;}
        public List <Response> MessageFromUser{get;set;}
        public int FiestinessLevel{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;



        // This method will rate the users total messages to determine their 'fiestiness' level or later compare which user 'wins' the football game
        // public int UserFiestiness()
        // {
            // Not sure whether to return a void or an int
        // }
    }

    public class LoginUser
    {
        [NotMapped]
        public string LoginEmail{get;set;}
        [NotMapped]
        public string LoginPassword{get;set;}
    }
}

