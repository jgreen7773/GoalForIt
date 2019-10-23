// using System;
// using System.Collections.Generic;
// using Newtonsoft.Json;
// using Microsoft.AspNetCore.Http;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace GoalForIt.Models
// {
//     public class Association
//     {
//         [Key]
//         public int AssociationId{get;set;}
//         public int UserId{get;set;}
//         public int ActId{get;set;}
//         public User AssociatedPoster{get;set;}
//         public Message AssociatedMessage{get;set;}
//         public DateTime CreatedAt{get;set;} = DateTime.Now;
//         public DateTime UpdatedAt{get;set;} = DateTime.Now;
//     }
// }