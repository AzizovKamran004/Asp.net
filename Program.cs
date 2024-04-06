using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] toMails = {"kamran.azizov004@gmail.com", "kamran.azizov314@gmail.com", "kamran.azizov414@gmail.com"};

            string FromMail = "thedotnetchannelsender22@gmail.com";
            string FromPassword = "lgioehkvchemfkrw";


            // CREATE NEW MAIL
            MailMessage message = new MailMessage();
            message.From = new MailAddress(FromMail);
            message.Subject = "Test mail from workshop KAMRAN";
            foreach (string item in toMails)
            {
                message.To.Add(new MailAddress(item));

            }
            message.Body = "BU MAILIN BODYSIDIR";


            // SMTP CONF
            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(FromMail, FromPassword);
            smtpClient.EnableSsl = true;

            //SEND MESSAGE
            try
            {
                    Random waitTime = new Random();
                    int seconds = waitTime.Next(3, 10);
                    System.Threading.Thread.Sleep(seconds);
                    smtpClient.Send(message);
                    Console.WriteLine("GONDERILDI");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}