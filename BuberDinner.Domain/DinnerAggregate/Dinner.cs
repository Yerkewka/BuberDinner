using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new();

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDatetime { get; }
    public DinnerStatus DinnerStatus { get; }
    public DateTime? StartedDateTime { get; }
    public DateTime? EndedDateTime { get; }
    public DinnerStatus Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    private Dinner(
        DinnerId id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDatetime,
        DinnerStatus dinnerStatus,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDatetime = endDatetime;
        DinnerStatus = dinnerStatus;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private Dinner()
    {        
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            DinnerStatus.Upcoming,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}