using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class Description : ValueObject
{
    public string? DescriptionText { get; init; }

    protected Description()
    {
    }

    public Description(string descriptionText)
    {
        descriptionText = StringFormatter.BasicClear(descriptionText);

        AddNotifications(new Contract<Description>()
            .IsNotNullOrEmpty(descriptionText, "Description", "A descrição não pode ser nula ou vazia")
            .IsLowerOrEqualsThan(descriptionText, 120, "Description", "A descrição deve conter no máximo 120 caracteres")
            .Matches(descriptionText, @"^[A-Z](\s?[A-Za-z,.();?!%$#&]+\s?)+$", "Description", "Descrição inválida")
        );

        if (!IsValid)
            throw new ArgumentException("Descrição inválido");

        DescriptionText = descriptionText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return DescriptionText!;
    }
}
