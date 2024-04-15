using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Infra.Mail.Requests;
using paysys.webapi.Infra.Mail.Service;
using paysys.webapi.Infra.Mail.Templates;

namespace paysys.webapi.Application.Controllers;

[Route("api/mail-test")]
[ApiController]
[Produces("application/json")]
public class MailTestController : ControllerBase
{
    private readonly IMailInfraService _mailService;

    public MailTestController(IMailInfraService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(string receiverEmail)
    {
        try
        {
            var request = new MailRequest(
                ReceiverEmail: receiverEmail,
                MailSubject: "Hello, world e-mail!",
                MailBody: "<h1>Be Welcome!</h1>"
            );

            await _mailService.SendMailAsync(request);

            return Ok("E-mail sended!");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost("SendWelcomeEmail")]
    public async Task<IActionResult> SendWelcomeEmail(string userName, string receiverEmail)
    {
        try
        {
            var request = new MailWithTemplateRequest(
                ReceiverEmail: receiverEmail,
                MailTemplate: new WelcomeMailTemplate(userName)
            );

            await _mailService.SendMailWithTemplateAsync(request);

            return Ok("E-mail sended!");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
