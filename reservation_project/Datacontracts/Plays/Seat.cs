using System;
namespace reservation_project.Datacontracts.Plays
{
    public class Seat
    {
        public int SeatNb { get; set; }
        public bool IsReserved { get; set; }
        public bool ReservationIsConfirmed { get; set; }
        public string ReservingUser { get; set; }
        public string ReservingUserId { get; set; }
    }
}
