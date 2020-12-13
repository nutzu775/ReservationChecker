using System;

namespace API.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}