using Hangfire;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{

    public class FireAndForgetJob:IFireAndForgetJob
    {

        /// <summary>
        /// Tetiklendiginde hemen bir defa çalışan backgroundJob.
        /// </summary>
        public void SendMailJob(AppUser appUser)
        {
            string subject = $"Hoş Geldiniz {appUser.UserName}";
            string body = $"Giriş İşlemi Başarılı Hoş geldiniz \n {appUser.UserName}";

            try
            {    
                 BackgroundJob.Enqueue(() => EmailSender.SendAsync(appUser,subject,body));
            }
            catch (Exception)
            {

                throw new Exception("Hoş geldiniz Maili Gönderimi Başarısız");
            }

        }
    }
}
