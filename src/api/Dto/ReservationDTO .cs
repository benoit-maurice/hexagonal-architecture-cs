using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Dto
{
    public record ReservationDTO(
        [property: JsonPropertyName("train_id")] string TrainId,
        [property: JsonPropertyName("booking_reference")] string BookingReference,
        [property: JsonPropertyName("seats")] List<string> Seats);
}
