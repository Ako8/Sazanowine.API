using System.Net;
using System.Net.Mail;
using System.Web;
using Microsoft.Extensions.Configuration;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendVerificationEmailAsync(string email, string verificationToken)
    {
        var smtpServer = _configuration["EmailSettings:SmtpServer"];
        var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
        var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
        var smtpPassword = _configuration["EmailSettings:SmtpPassword"];

        using var client = new SmtpClient(smtpServer, smtpPort)
        {
            Credentials = new NetworkCredential(smtpUsername, smtpPassword),
            EnableSsl = true
        };

        var encodedToken = HttpUtility.UrlEncode(verificationToken);
        var encodedEmail = HttpUtility.UrlEncode(email);

        var verifyLink = $"{_configuration["AppUrl"]}/verifyEmail?token={encodedToken}&email={encodedEmail}";

        string emailTemplate = $@"
        <!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Verify Your Email</title>
        </head>
        <body style=""font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color: #f8f8f8; border-radius: 5px;"">
                <tr>
                    <td style=""padding: 20px;"">
                        <h1 style=""color: #4a4a4a; text-align: center;"">Verify Your Email Address</h1>
                        <p style=""text-align: center;"">Thank you for signing up! Please click the button below to verify your email address and activate your account.</p>
                        <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                            <tr>
                                <td align=""center"" style=""padding: 20px;"">
                                    <a href=""{verifyLink}"" style=""background-color: #4CAF50; color: white; padding: 12px 20px; text-decoration: none; border-radius: 5px; font-weight: bold;"">Verify Email</a>
                                </td>
                            </tr>
                        </table>
                        <p style=""text-align: center;"">If the button doesn't work, you can also click on the link below:</p>
                        <p style=""text-align: center; word-break: break-all;"">
                            <a href=""{verifyLink}"" style=""color: #1a73e8; text-decoration: none;"">{verifyLink}</a>
                        </p>
                        <p style=""text-align: center; font-size: 0.9em; color: #666;"">If you didn't sign up for this account, you can safely ignore this email.</p>
                    </td>
                </tr>
            </table>
        </body>
        </html>";

        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpUsername),
            Subject = "Verify your email",
            Body = emailTemplate,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email);

        await client.SendMailAsync(mailMessage);

    }
}

public interface IEmailService
{
    Task SendVerificationEmailAsync(string email, string verificationToken);
}