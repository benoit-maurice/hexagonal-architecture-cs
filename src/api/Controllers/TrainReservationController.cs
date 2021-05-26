using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainReservationController : ControllerBase
    {
        private readonly ILogger<TrainReservationController> _logger;

        public TrainReservationController(ILogger<TrainReservationController> logger)
        {
            _logger = logger;
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
        public ActionResult PostReserveTickets(object reservationRequest)
        {
            // TODO : implement
            throw new NotImplementedException();
        }
    }
}
