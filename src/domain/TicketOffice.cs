using System.Collections.Generic;
using System.Linq;

namespace domain
{
    public class TicketOffice
    {
        private readonly ISeatsProvider seatsProvider;

        public TicketOffice(ISeatsProvider seatsProvider)
        {
            this.seatsProvider = seatsProvider;
        }

        public Reservation MakeReservation(ReservationRequest request)
        {
            var seats = seatsProvider.GetAvailableSeats(request.TrainId)
                                     .Take(request.SeatCount).ToList();

            return new Reservation("TGV", "REF_1234", seats);
        }
    }

    public interface ISeatsProvider
    {
        IEnumerable<Seat> GetAvailableSeats(string trainId);
    }
}
