using System.Globalization;
using HandlebarsDotNet;

namespace paysys.webapi.Infra.Mail.Templates;

public class TransferMakedMailTemplate : IMailTemplate
{
    private readonly string _transferSenderName;
    private readonly string _transferReceiverName;
    private readonly DateTime _transferDateTime;
    private readonly double _transferAmount;

    public string Subject { get => "Transferência realizada"; }

    public TransferMakedMailTemplate(string transferSenderName, string transferReceiverName, DateTime transferDateTime, double transferAmount)
    {
        _transferSenderName = transferSenderName;
        _transferReceiverName = transferReceiverName;
        _transferDateTime = transferDateTime;
        _transferAmount = transferAmount;
    }

    public string GenerateEmailBody()
    {
        string source =
            @"<div style=""background-image: linear-gradient(#FFF, #EEF7F3); width: 100%; height: 100%; display: flex; flex-direction: column; padding: 16px"">
                <h1 style=""color: #13423E; font-size: 24px"">
                    Olá, {{TransferSenderName}}
                </h1>
                <p style=""color: #13423E; font-size: 18px"">
                    Em {{TransferDate}}, foi realizado um pagamento da sua conta,
                    no valor de {{TransferAmount}}. Os dados de destino são:
                </p>
                <ul style=""list-style-type: none"">
                    <li style=""color: #13423E; font-size: 16px"">
                        <strong>Nome do recebedor:</strong>
                        {{TransferReceiverName}}
                    </li>
                    <li style=""color: #13423E; font-size: 16px"">
                        <strong>Valor:</strong>
                        {{TransferAmount}}
                    </li>
                    <li style=""color: #13423E; font-size: 16px"">
                        <strong>Data e horário:</strong>
                        {{TransferDateTime}}
                    </li>
                </ul>
            </div>";

        var template = Handlebars.Compile(source);

        var data = new
        {
            TransferSenderName = _transferSenderName,
            TransferReceiverName = _transferReceiverName,
            TransferDate = _transferDateTime.Date.ToString("dd/MM/yyyy"),
            TransferDateTime = _transferDateTime.ToString(),
            TransferAmount = _transferAmount.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))
        };

        var result = template(data);

        return result;
    }
}
