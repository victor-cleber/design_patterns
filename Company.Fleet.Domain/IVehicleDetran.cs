using System;
using System.Threading.Tasks;

namespace Company.Fleet.Domain
{
    public interface IVehicleDetran
    {
        //schedule an car inspection no matter the place
        public Task ScheduleInspection(Guid vehicleId);
    }
}