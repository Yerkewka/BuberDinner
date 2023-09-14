using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationBillId : ValueObject
{
    public Guid Value { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private ReservationBillId(
        Guid value,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        Value = value;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static ReservationBillId CreateUnique(DateTime? arrivalDateTime)
    {
        return new(
            Guid.NewGuid(),
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow
            );
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return CreatedDateTime;
        yield return UpdatedDateTime;
        
        if (ArrivalDateTime is not null)
            yield return ArrivalDateTime;
    }
}