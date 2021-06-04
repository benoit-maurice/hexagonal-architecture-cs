using api.Controllers;
using System;
using Xunit;
using domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using api.Dto;

namespace tests
{
    public class TrainReservationControllerTest
    {
        class FakeSeatsProvider : ISeatsProvider
        {
            public IEnumerable<Seat> GetAvailableSeats(string trainId)
            {
                yield return new Seat("A", 1);
                yield return new Seat("A", 2);
            }
        }

        [Fact]
        public void Post_Train_Reservation_Should_Return_Reservation()
        {
            var controller = new TrainReservationController(new TicketOffice(new FakeSeatsProvider()));

            var request = new ReservationRequestDTO() { TrainId = "TGV", SeatCount = 2 };

            var response = controller.PostReserveTickets(request);
            Assert.IsType<OkObjectResult>(response.Result);

            var result = response.Result as OkObjectResult;
            Assert.NotNull(result);
            var reservation = result.Value as ReservationDTO;

            var expectedReservation = new ReservationDTO("TGV", "REF_1234", new List<string>() { "1A", "2A" } );

            Assert.Equal(expectedReservation.TrainId, reservation.TrainId);
            Assert.Equal(expectedReservation.BookingReference, reservation.BookingReference);
            Assert.Equal(expectedReservation.Seats, reservation.Seats);
        }
    }
}
