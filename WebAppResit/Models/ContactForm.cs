using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAppResit.Models;

public class ContactForm
{
        [Key,Required] public int ContactNo { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Message { get; set; }
    
}