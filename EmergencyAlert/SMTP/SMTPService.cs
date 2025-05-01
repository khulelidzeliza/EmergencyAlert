using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Primitives;

namespace EmergencyAlert.SMTP;

public class SMTPService
{
    public  void SendEmail(string to, string subject, string body)
    {
        string senderEmail = "llizi8871@gmail.com";
        string appPassword = "vzcu oqaf nqgf btfw";

        try
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(senderEmail);
            email.To.Add(to);
            email.Subject = subject;
            email.Body = body;
            email.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, appPassword)
            };

            smtpClient.Send(email);
            Console.WriteLine("Email sent.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
    public  string GetVerificationEmailHtml(string code)
    {
        return @"<!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Verification Code</title>
                <style>
                    body {
                        font-family: 'Segoe UI', Tahoma, Arial, sans-serif;
                        line-height: 1.5;
                        color: #333;
                        margin: 0;
                        padding: 0;
                        background-color: #f7f9fc;
                    }
                    .email-container {
                        max-width: 450px;
                        margin: 0 auto;
                        padding: 25px;
                        background-color: #ffffff;
                        border-radius: 12px;
                        box-shadow: 0 5px 15px rgba(0, 0, 0, 0.07);
                    }
                    .header {
                        text-align: center;
                        padding: 15px 0 20px;
                        border-bottom: 2px solid #6a93ff;
                        margin-bottom: 20px;
                    }
                    .header h2 {
                        color: #4169e1;
                        margin: 0;
                        font-size: 24px;
                        font-weight: 600;
                    }
                    .content {
                        padding: 20px 15px;
                        text-align: center;
                        background-color: #fafbff;
                        border-radius: 8px;
                    }
                    .verification-code {
                        font-size: 28px;
                        font-weight: bold;
                        color: #4169e1;
                        letter-spacing: 3px;
                        padding: 15px 20px;
                        background-color: #ffffff;
                        border-radius: 10px;
                        display: inline-block;
                        margin: 15px 0;
                        box-shadow: 0 3px 10px rgba(65, 105, 225, 0.1);
                        border: 1px dashed #6a93ff;
                    }
                    .message {
                        color: #555;
                        font-size: 16px;
                        margin-bottom: 12px;
                    }
                    .footer {
                        font-size: 13px;
                        text-align: center;
                        color: #888;
                        padding-top: 20px;
                        margin-top: 20px;
                        border-top: 1px solid #eee;
                    }
                    .accent {
                        color: #4169e1;
                    }
                </style>
            </head>
            <body>
                <div class=""email-container"">
                    <div class=""header"">
                        <h2>Account Verification</h2>
                    </div>
                    <div class=""content"">
                        <p class=""message"">Thank you for registering! Please use the following code to verify your account:</p>
                        <div class=""verification-code"">" + code + @"</div>
                        <p class=""message""><span class=""accent"">Important:</span> If you didn't request this code, please ignore this email.</p>
                    </div>
                    <div class=""footer"">
                        <p>This is an automated message, please do not reply.</p>
                        <p>&copy; " + DateTime.Now.Year + @" Your Company Name</p>
                    </div>
                </div>
            </body>
            </html>";
    }

    public string getSuccesed(string code)
    {
        return @"<!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Success Notification</title>
            <style>
                body {
                    font-family: 'Segoe UI', Tahoma, Arial, sans-serif;
                    line-height: 1.5;
                    color: #333;
                    margin: 0;
                    padding: 0;
                    background-color: #f7f9fc;
                }
                .email-container {
                    max-width: 450px;
                    margin: 0 auto;
                    padding: 25px;
                    background-color: #ffffff;
                    border-radius: 12px;
                    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.07);
                }
                .header {
                    text-align: center;
                    padding: 15px 0 20px;
                    border-bottom: 2px solid #4caf50;
                    margin-bottom: 20px;
                }
                .header h2 {
                    color: #2e7d32;
                    margin: 0;
                    font-size: 24px;
                    font-weight: 600;
                }
                .content {
                    padding: 20px 15px;
                    text-align: center;
                    background-color: #f8fff8;
                    border-radius: 8px;
                }
                .success-icon {
                    font-size: 48px;
                    color: #4caf50;
                    margin-bottom: 15px;
                }
                .success-message {
                    font-size: 18px;
                    font-weight: bold;
                    color: #2e7d32;
                    margin-bottom: 15px;
                }
                .reference-code {
                    font-size: 20px;
                    font-weight: bold;
                    color: #2e7d32;
                    letter-spacing: 2px;
                    padding: 10px 15px;
                    background-color: #ffffff;
                    border-radius: 8px;
                    display: inline-block;
                    margin: 10px 0;
                    box-shadow: 0 3px 10px rgba(46, 125, 50, 0.1);
                    border: 1px dashed #4caf50;
                }
                .message {
                    color: #555;
                    font-size: 16px;
                    margin-bottom: 12px;
                }
                .footer {
                    font-size: 13px;
                    text-align: center;
                    color: #888;
                    padding-top: 20px;
                    margin-top: 20px;
                    border-top: 1px solid #eee;
                }
                .accent {
                    color: #2e7d32;
                }
                .button {
                    display: inline-block;
                    background-color: #4caf50;
                    color: white;
                    text-decoration: none;
                    padding: 10px 20px;
                    border-radius: 5px;
                    font-weight: bold;
                    margin-top: 15px;
                }
            </style>
        </head>
        <body>
            <div class=""email-container"">
                <div class=""header"">
                    <h2>Success Confirmation</h2>
                </div>
                <div class=""content"">
                    <div class=""success-icon"">✓</div>
                    <p class=""success-message"">Your operation was completed successfully!</p>
                    <p class=""message"">Your confirmation code is:</p>
                    <div class=""reference-code"">" + code + @"</div>
                    <p class=""message"">Please keep this code for your records. You may need it for future reference.</p>
                    <p class=""message""><span class=""accent"">Thank you</span> for using our service!</p>
                    <a href=""#"" class=""button"">Go to Dashboard</a>
                </div>
                <div class=""footer"">
                    <p>This is an automated message, please do not reply.</p>
                    <p>&copy; " + DateTime.Now.Year + @" Your Company Name</p>
                </div>
            </div>
        </body>
        </html>";
    }
}
