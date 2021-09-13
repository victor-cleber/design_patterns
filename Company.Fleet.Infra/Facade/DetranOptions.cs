using System;

namespace Company.Fleet.Infra.Facade
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string BaseUrl { get; set; }

        public string ScheduleUrl { get; set; }

        public int NumberOfDaysForScheduling { get; set; }
    }
}