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
        var handlebars = Handlebars.Create();

        string emailReceiverName = "";
        string otherPartName = "";
        string transferDescriptionText = "";

        if (_transferMailTo == TransferMailTo.TransferSender)
        {
            emailReceiverName = _transferSenderName;
            otherPartName = @"
                <strong>Nome do recebedor:</strong>
                {{TransferReceiverName}}
            ";
            transferDescriptionText = @"
                Em {{TransferDate}}, foi realizado um pagamento da sua conta,
                no valor de {{TransferAmount}}. Os dados de destino são:
            ";
        }

        if (_transferMailTo == TransferMailTo.TransferReceiver)
        {
            emailReceiverName = _transferReceiverName;
            otherPartName = @"
                <strong>Nome do pagador:</strong>
                {{TransferSenderName}}
            ";
            transferDescriptionText = @"
                Em {{TransferDate}}, foi realizado um pagamento para a sua conta,
                no valor de {{TransferAmount}}. Os dados do pagamento são:
            ";
        }

        handlebars.RegisterTemplate("Other_Part_Name_Template", otherPartName);
        handlebars.RegisterTemplate("Transfer_Description_Text_Template", transferDescriptionText);

        string source =
            @"<div style=""background-image: linear-gradient(#FFF, #EEF7F3); width: 100%; height: 100%; display: flex; flex-direction: column; padding: 16px"">
                <h1 style=""color: #13423E; font-size: 24px"">
                    Olá, {{EmailReceiverName}}
                </h1>
                <p style=""color: #13423E; font-size: 18px"">
                    {{>Transfer_Description_Text_Template}}
                </p>
                <ul style=""list-style-type: none"">
                    <li style=""color: #13423E; font-size: 16px"">
                        {{>Other_Part_Name_Template}}
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

        var template = handlebars.Compile(source);

        var data = new
        {
            EmailReceiverName = emailReceiverName,
            TransferReceiverName = _transferReceiverName,
            TransferSenderName = _transferSenderName,
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
