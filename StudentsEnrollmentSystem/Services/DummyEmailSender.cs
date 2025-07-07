

 using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace StudentsEnrollmentSystem.Services 
{ 

public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
            // هنا فقط نحاكي الإرسال بدون فعل حقيقي (تقدر تطبع للإخراج مثلاً)
            Console.WriteLine("📧 Dummy Email Sent!");
            Console.WriteLine($"[DummyEmailSender] Sending Email to: {email}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {htmlMessage}");
        return Task.CompletedTask;
    }
}


    

}