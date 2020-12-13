using System;
namespace Core.Entities
{
    public class Reservation : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}