using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using FrutosMaipo.Feria.Service.Config;
using Microsoft.Extensions.Options;

namespace FrutosMaipo.Feria.Service.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly SendEmailConfig _sendEmailConfig;
        public SendEmailService(IOptions<SendEmailConfig> sendEmailConfig)
        {
            _sendEmailConfig = sendEmailConfig.Value;
        }

        public async Task<bool> SendEmail(string emailDestino)
        {
            try
            {
                string EmailOrigen = _sendEmailConfig.Email;
                //string EmailDestino = "agarcia@crossnet.cl";
                //string EmailDestino = "claubass7@gmail.com";
                string EmailDestino = emailDestino;

                string Contraseña = _sendEmailConfig.Pass;
                //string path = @"C:\Users\CNFCASTRO-NB\source\repos\ConsoleApp1\ConsoleApp1\adjuntos\Bliss.jpg";
                //string path2 = @"C:\Users\CNFCASTRO-NB\source\repos\ConsoleApp1\ConsoleApp1\adjuntos\CertificadoAfiliacion.pdf";
                //string path3 = @"C:\Users\CNFCASTRO-NB\source\repos\ConsoleApp1\ConsoleApp1\adjuntos\Nuevo Hoja de cálculo de Microsoft Excel.xlsx";

                MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, _sendEmailConfig.AsuntoReporteVenta, _sendEmailConfig.CuerpoReporteVenta);
                //oMailMessage.Attachments.Add(new Attachment(path));
                //oMailMessage.Attachments.Add(new Attachment(path2));
                //oMailMessage.Attachments.Add(new Attachment(path3));

                oMailMessage.IsBodyHtml = true;

                SmtpClient oSmtpCliente = new SmtpClient(_sendEmailConfig.SmtpClientEmail);
                oSmtpCliente.EnableSsl = true;
                oSmtpCliente.UseDefaultCredentials = false;
                oSmtpCliente.Port = _sendEmailConfig.EmailPort;
                oSmtpCliente.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

                oSmtpCliente.Send(oMailMessage);

                oSmtpCliente.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
