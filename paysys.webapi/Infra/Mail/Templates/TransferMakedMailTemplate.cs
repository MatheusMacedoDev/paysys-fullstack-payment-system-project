using System.Globalization;
using HandlebarsDotNet;

namespace paysys.webapi.Infra.Mail.Templates;

public class TransferMakedMailTemplate : IMailTemplate
{
    private readonly string _transferSenderName;
    private readonly string _transferReceiverName;
    private readonly DateTime _transferDateTime;
    private readonly double _transferAmount;

    private readonly TransferMailTo _transferMailTo;

    public string Subject { get => "Transferência realizada"; }

    public TransferMakedMailTemplate(string transferSenderName, string transferReceiverName, DateTime transferDateTime, double transferAmount, TransferMailTo transferMailTo)
    {
        _transferSenderName = transferSenderName;
        _transferReceiverName = transferReceiverName;
        _transferDateTime = transferDateTime;
        _transferAmount = transferAmount;

        _transferMailTo = transferMailTo;
    }

    public string GenerateEmailBody()
    {
        string source =
            @"<div style=""background-image: linear-gradient(#FFF, #EEF7F3); width: 100%; height: 100%; display: flex; flex-direction: column; padding: 16px"">
                <h1 style=""color: #13423E; font-size: 24px"">
                    Olá, {{EmailReceiverName}}
                </h1>
                <p style=""color: #13423E; font-size: 18px"">
                    {{TransferDescription}}
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

        string emailReceiverName = "";
        string transferDescription = "";

        if (_transferMailTo == TransferMailTo.TransferSender)
        {
            emailReceiverName = _transferSenderName;
            transferDescription = @$"
                Em {{TransferDate}}, foi realizado um pagamento da sua conta,
                no valor de {{TransferAmount}}. Os dados de destino são:
            ";
        }

        if (_transferMailTo == TransferMailTo.TransferReceiver)
        {
            emailReceiverName = _transferReceiverName;
            transferDescription = @$"
                Em {{TransferDate}}, foi realizado um pagamento da para a sua conta,
                no valor de {{TransferAmount}}. Os dados do pagamento são:
            ";
        }

        var data = new
        {
            EmailReceiverName = emailReceiverName,
            TransferDescription = transferDescription,
            TransferDate = _transferDateTime.Date.ToString("dd/MM/yyyy"),
            TransferDateTime = _transferDateTime.ToString(),
            TransferAmount = _transferAmount.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))
        };

        var result = template(data);

        return result;
    }

    public enum TransferMailTo
    {
        TransferSender,
        TransferReceiver
    }
}
