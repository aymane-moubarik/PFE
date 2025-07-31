using System.Collections.Generic;

namespace BackendApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string EmpreinteDigitaleHash { get; set; }
        public string Localisation { get; set; }

        // Simulation d'un identifiant unique d'empreinte digitale
        public string FingerprintId { get; set; }

        // Indique si l'employé a authentifié par empreinte
        public bool IsFingerprintAuthenticated { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
