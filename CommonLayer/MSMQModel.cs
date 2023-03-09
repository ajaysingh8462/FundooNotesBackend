using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer
{
    public class MSMQModel
    {
        MessageQueue messageQueue = new MessageQueue();
        private string recieverEmailAddr;
        private string recieverName;
        public void sendDatatoQueue(string Token,string emailid,string name)
        { 
            recieverEmailAddr= emailid;
            recieverName= name;
            messageQueue.Path = @".\private$\Token";
            try
            {
                if (!MessageQueue.Exists(messageQueue.Path))
                {
                    MessageQueue.Create(messageQueue.Path);
                }
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                messageQueue.Send(Token);
                messageQueue.BeginReceive();
                messageQueue.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var meg = messageQueue.EndReceive(e.AsyncResult);
                string Token = meg.Body.ToString();
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("ajaysingh84625@gmail.com", "silxiwohcabinmmw"),


                };
                mailMessage.From = new MailAddress("ajaysingh84625@gmail.com");
                mailMessage.To.Add(new MailAddress(recieverEmailAddr));
                string mailBody= $"<!DOCTYPE html>" +
                    $"< html > "+
                    $"<body>" +
                    $"<H1>Dear <b>(recieverName)</b></H1>\n" +
                    $"<h3>For Reseting Password The Below Link Is Issued</h3>" +
                    $"<h3>Please click Below link to reset Your Password</h3>" +
                    $"<a href='https://localhost:44396/ResetPassword/{Token}'>click</a>" +
                $"<h3>This Token Will Be Valid For Next 15 min</h3>" +
                    "</body>" +
                    $"</html>";
                mailMessage.Body = mailBody;
                mailMessage.IsBodyHtml= true;
                mailMessage.Subject = "Fundoo Notes Password Reset Link";
                smtpClient.Send(mailMessage);


            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        


    }
}
