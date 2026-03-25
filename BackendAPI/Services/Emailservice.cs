using MimeKit;
using System.Net;
//using System.Net.Mail;
using MailKit.Net.Smtp;

//Any class that calls this should not depend on other classes but abstractions.
//Making callers use IEmailService will make swapping implementations easier (essentially there are several things you could use to send emails and you'd be able to switch between them simply by changing the service registration code in the Program.cs
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        //sensitive information like this should probably be in Azure Key Vault
        //var smtpClient = new SmtpClient("smtp.gmail.com")
        //{
        //    Port = 587,
        //    Credentials = new NetworkCredential("your@email.com", "password"),
        //    EnableSsl = true,
        //};

        //var message = new MailMessage
        //{
        //    From = new MailAddress("your@email.com"),
        //    Subject = subject,
        //    Body = body,
        //};

        //message.To.Add(toEmail);

        //smtpClient.Send(message);
       
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("FluentAI", "emailaddresshere"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = body };
        //If we plan on creating professional looking emails then we can uncomment this
        //message.Body = new TextPart("html") { Text = body };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("youremailaddress", "generatedpassword");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
