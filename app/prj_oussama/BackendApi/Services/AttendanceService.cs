using System;
using BackendApi.Models;

namespace BackendApi.Services
{
    public class AttendanceService
    {
        private readonly OfficeLocation _officeLocation;
        private const double EarthRadiusMeters = 6371000;
        private const double AllowedRadiusMeters = 100;

        public AttendanceService(OfficeLocation officeLocation)
        {
            _officeLocation = officeLocation;
        }

        public AttendanceValidationResult ValidateAttendance(double latitude, double longitude, bool isFingerprintAuthenticated)
        {
            if (!isFingerprintAuthenticated)
            {
                return new AttendanceValidationResult { IsValid = false, Message = "Authentification par empreinte requise." };
            }

            double distance = CalculateDistanceMeters(latitude, longitude, _officeLocation.Latitude, _officeLocation.Longitude);
            if (distance > AllowedRadiusMeters)
            {
                return new AttendanceValidationResult { IsValid = false, Message = $"Hors zone autorisée ({distance:F1}m > 100m)." };
            }

            return new AttendanceValidationResult { IsValid = true, Message = "Présence validée." };
        }

        // Haversine formula
        private double CalculateDistanceMeters(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusMeters * c;
        }

        private double ToRadians(double angle) => angle * Math.PI / 180.0;
    }
}
