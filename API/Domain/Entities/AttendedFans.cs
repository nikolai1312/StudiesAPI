﻿namespace StudiesAPI.Domain.Entities
{
    public class AttendedFans
    {
        public int Id { get; set; }
        public int AttendedGuests { get; set; }
       
        public int ConcertId { get; set; }
    }
}
