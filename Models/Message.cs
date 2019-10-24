using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalForIt.Models
{
    public class Message
    {
        [Key]
        public int MessageId{get;set;}
        public string MessageContent{get;set;}
        public User MessageCreator{get;set;}
        public int UserId{get;set;}
        public int SpicyMessageLevel{get;set;}
        public List <Response> Responses {get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;



        // This method will rate the message by passing in the created message, then it will check for boring words
        // public int RateMessage(Message MessageBeingRated, int SpicyMessageLevel)
        // {
            // Not sure whether to return a void or an int
        // }
    }

    public class FutureDateAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        // You first may want to unbox "value" here and cast to a DateTime variable!
            if ((DateTime) value < DateTime.Now) {
                return new ValidationResult ("The date entered is not a future date.");
            }
            return ValidationResult.Success;
        }
    }
}