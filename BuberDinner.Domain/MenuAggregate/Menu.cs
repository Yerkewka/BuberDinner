﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.Events;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AvarageRating AvarageRating { get; private set; }
    public HostId HostId { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId id,
        HostId hostId,
        string name,
        string description,
        AvarageRating avarageRating,
        List<MenuSection> sections) : base(id)
    {
        Name = name;
        Description = description;
        AvarageRating = avarageRating;
        HostId = hostId;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;

        _sections = sections;
    }

#pragma warning disable CS8618
    private Menu()
    {        
    }
#pragma warning restore CS8618

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections)
    {
        // TODO: Enforce invariants
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AvarageRating.CreateNew(),
            sections ?? new());

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }
}

