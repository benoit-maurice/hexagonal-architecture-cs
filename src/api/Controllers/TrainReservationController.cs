using System;
using System.Collections.Generic;
using System.Linq;
using api.Dto;
using domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainReservationController : ControllerBase
    {
        private readonly TicketOffice ticketOffice;

        public TrainReservationController(TicketOffice ticketOffice)
        {
            this.ticketOffice = ticketOffice;
        }

        /// <summary>
        /// Reserve a certain amount of tickets in the train if train is not full
        /// </summary>
        /// <remarks>
        /// <returns>All reserved seats</returns>
        /// <param name="reservationRequest"></param>
        [Produces("application/json")]
        [HttpPost]
        [Route("/tickets")]
        public ActionResult<ReservationDTO> PostReserveTickets(ReservationRequestDTO reservationRequestDto)
        {
            // Infra -> Domain
            var reservationRequest = new ReservationRequest(reservationRequestDto.TrainId, reservationRequestDto.SeatCount);

            //Domain
            var reservation = ticketOffice.MakeReservation(reservationRequest);

            // Domain -> Infra
            var reservationDto = new ReservationDTO(reservation.TrainId, reservation.BookingId, reservation.Seats.Select(x => x.SeatNumber + x.Coach).ToList());

            //// TODO : implement
            return Ok(reservationDto);
        }
    }
}
