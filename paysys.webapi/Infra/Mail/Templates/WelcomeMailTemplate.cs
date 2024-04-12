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
            @"<div>
                <h1>Seja bem-vindo, {{UserName}}</h1>
                <p>Agora você faz parte dos nossos clientes e tem acesso à todos os serviços.</p>
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
