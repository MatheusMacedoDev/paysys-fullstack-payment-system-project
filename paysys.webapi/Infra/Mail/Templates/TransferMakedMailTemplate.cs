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

        string emailReceiverName = GetEmailReceiverName();

        RegistrateOtherPartNameTemplate(handlebars);
        RegistrateTransferDescriptionTemplate(handlebars);
        RegistrateMainTemplate(handlebars);

        return CompileTemplate(handlebars);
    }

    private string GetEmailReceiverName()
    {
        if (_transferMailTo == TransferMailTo.TransferSender)
        {
            return _transferSenderName;
        }

        return _transferReceiverName;
    }

    private void RegistrateOtherPartNameTemplate(IHandlebars handlebars)
    {
        string otherPartName;

        if (_transferMailTo == TransferMailTo.TransferSender)
        {
            otherPartName = @"
                <strong>Nome do recebedor:</strong>
                {{TransferReceiverName}}
            ";
        }
        else
        {
            otherPartName = @"
                <strong>Nome do pagador:</strong>
                {{TransferSenderName}}
            ";
        }

        handlebars.RegisterTemplate("Other_Part_Name_Template", otherPartName);
    }

    private void RegistrateTransferDescriptionTemplate(IHandlebars handlebars)
    {
        string transferDescriptionText = "";

        if (_transferMailTo == TransferMailTo.TransferSender)
        {
            transferDescriptionText = @"
                Em {{TransferDate}}, foi realizado um pagamento da sua conta,
                no valor de {{TransferAmount}}. Os dados de destino são:
            ";
        }
        else
        {
            transferDescriptionText = @"
                Em {{TransferDate}}, foi realizado um pagamento para a sua conta,
                no valor de {{TransferAmount}}. Os dados do pagamento são:
            ";

        }

        handlebars.RegisterTemplate("Transfer_Description_Text_Template", transferDescriptionText);
    }

    private void RegistrateMainTemplate(IHandlebars handlebars)
    {
        string transferMakedEmailMain =
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

        handlebars.RegisterTemplate("Transfer_Maked_Email_Template", transferMakedEmailMain);
    }

    private string CompileTemplate(IHandlebars handlebars)
    {
        string compilationResult = "";

        string source = "{{>Transfer_Maked_Email_Template}}";
        string emailReceiverName = GetEmailReceiverName();

        var template = handlebars.Compile(source);

        var data = new
        {
            EmailReceiverName = emailReceiverName,
            TransferReceiverName = _transferReceiverName,
            TransferSenderName = _transferSenderName,
            TransferDate = _transferDateTime.Date.ToString("dd/MM/yyyy"),
            TransferDateTime = _transferDateTime.ToString("dd/MM/yyyy HH:mm"),
            TransferAmount = _transferAmount.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))
        };

        compilationResult = template(data);

        return compilationResult;
    }
}

public enum TransferMailTo
{
    TransferSender,
    TransferReceiver
}
