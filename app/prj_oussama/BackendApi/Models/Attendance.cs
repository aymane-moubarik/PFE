using System;

namespace BackendApi.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime? DateSortie { get; set; }
        public string Geolocalisation { get; set; }

        public Employee Employee { get; set; }
    }
}
