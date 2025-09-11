﻿using Quickpack.Application.Common.Interface;

namespace Quickpack.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime HoraLocal()
        {
            var horaActualPacifico = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            var fechaActual = horaActualPacifico;
            return fechaActual.DateTime;
        }

        public DateTime HoraActual()
        {
            return DateTime.UtcNow;
        }
    }
}
