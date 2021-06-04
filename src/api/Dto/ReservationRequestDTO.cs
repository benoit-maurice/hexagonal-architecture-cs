using System.Text.Json.Serialization;

namespace api.Dto
{
    public class ReservationRequestDTO
    {
        [JsonPropertyName("train_id")]
        public string TrainId { get; set; }
        [JsonPropertyName("seat_count")]
        public int SeatCount { get; set; }
    }
}
