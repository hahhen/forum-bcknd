using MimeKit;
using MailKit.Net.Smtp;
using UsuariosApi.Data.Dtos;
using MailKit.Security;
using CpsForum.Data.Dtos;

namespace UsuariosApi.Services
{
    public class SendEmailService
    {
        public async Task ConstructorEmail(CreateStudentDto dto, string email, string pass)
        {
            using (var msg = new MimeMessage())
            {
                msg.Sender = MailboxAddress.Parse(email);
                msg.To.Add(MailboxAddress.Parse(dto.Email));
                msg.Subject = "Sua conta no CPS Fórum!";
                msg.Priority = MessagePriority.Normal;

                var builder = new BodyBuilder();
                builder.HtmlBody = $"Seja bem vindo {dto.Username},\r\n\r\nSeu cadastro no Fórum CPS foi feito com sucesso!\r\n\r\nPara criar seu primeiro tópico, entre em uma seção e clique em \"Criar tópico\" ou acesse www.cpsforum.com.br/criar\r\n\r\nSe tiver alguma dúvida, acesse cpsforum.com.br/docs ou mande um email para suporte@cpsforum.com.br\r\n\r\nAtenciosamente,\r\nFórum CPS";
                msg.Body = builder.ToMessageBody();

                await SendEmailAsync(msg, email, pass);
            };
        }

        public async Task ConstructorEmail(CreateTeacherDto dto, string email, string pass)
        {
            using (var msg = new MimeMessage())
            {
                msg.Sender = MailboxAddress.Parse(email);
                msg.To.Add(MailboxAddress.Parse(dto.Email));
                msg.Subject = "Sua conta no CPS Fórum!";
                msg.Priority = MessagePriority.Normal;

                var builder = new BodyBuilder();
                builder.HtmlBody = $"Seja vindo professor {dto.Username},\r\n\r\nSeu cadastro no Fórum CPS foi feito com sucesso!\r\n\r\nPara criar seu primeiro tópico, entre em uma seção e clique em \"Criar tópico\" ou acesse www.cpsforum.com.br/criar\r\n\r\nSe tiver alguma dúvida, acesse cpsforum.com.br/docs ou mande um email para suporte@cpsforum.com.br\r\n\r\nAtenciosamente,\r\nFórum CPS";
                msg.Body = builder.ToMessageBody();

                await SendEmailAsync(msg, email, pass);
            };
        }

        public async Task SendEmailAsync(MimeMessage msg, string email, string pass)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(email, pass);

                try
                {
                    await smtp.SendAsync(msg);
                    smtp.Disconnect(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
