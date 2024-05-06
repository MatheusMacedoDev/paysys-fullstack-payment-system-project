using HandlebarsDotNet;

namespace paysys.webapi.Infra.Mail.Templates;

public class WelcomeMailTemplate : IMailTemplate
{
    private readonly string _userName;

    public string Subject { get => "Boas-vindas do PaySys"; }

    public WelcomeMailTemplate(string userName)
    {
        _userName = userName;
    }

    public string GenerateEmailBody()
    {
        string source =
            @"<div style=""background-image: linear-gradient(#FFF, #EEF7F3); width: 100%; height: 100%; display: flex; flex-direction: column; flex; align-items: center; padding: 16px"">
                <h1 style=""color: #13423E; font-size: 48px; text-align: center"">Seja bem-vindo ao PaySys, {{UserName}}</h1>
                <p style=""color: #13423E; font-size: 20px; text-align: center"">Agora você faz parte dos nossos clientes e tem acesso à todos os serviços.</p>
            </div>";

        var template = Handlebars.Compile(source);

        var data = new
        {
            UserName = _userName
        };

        var result = template(data);

        return result;
    }
}
