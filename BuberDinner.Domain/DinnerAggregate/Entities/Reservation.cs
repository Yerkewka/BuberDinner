using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public ReservationBillId ReservationBillId { get; }
    
    private Reservation(
        ReservationId id,
        ReservationStatus reservationStatus,
        GuestId guestId,
        ReservationBillId reservationBillId) : base(id)
    {
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        ReservationBillId = reservationBillId;
    }

    public static Reservation Create(
        GuestId guestId,
        ReservationBillId reservationBillId)
    {
        return new(
            ReservationId.CreateUnique(),
            ReservationStatus.PendingGuestConfirmation,
            guestId,
            reservationBillId);
    }
}