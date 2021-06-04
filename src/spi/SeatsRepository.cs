using domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace spi
{
    public class SeatsRepository : ISeatsProvider
    {

        public IEnumerable<Seat> GetAvailableSeats(string trainId)
        {
            yield return new Seat("A", 1);
            yield return new Seat("A", 2);
        }
    }
}
