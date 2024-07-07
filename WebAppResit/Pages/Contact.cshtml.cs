using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppResit.Models;
using System.Net.Mail;

namespace WebAppResit.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactForm Contact { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(Contact.Email),
                    Subject = "New Contact Form Submission",
                    Body = $"Name: {Contact.Username}\nEmail: {Contact.Email}\nMessage: {Contact.Message}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add("Snowcone842313@chester.ac.uk ");
                // need an SMTP server to be able to send an email
                using (var smtpClient = new SmtpClient(""))
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
            
            

            return RedirectToPage("/Index");
        }
    }
}