using System;
using System.Collections.Generic;

namespace Company.Fleet.Domain
{
    public interface IVehicleRepository{

        Vehicle GetById(Guid id);

        IEnumerable<Vehicle> GetAll();

        void Update(Vehicle vehicle);

        void Add(Vehicle vehicle);

        void Delete(Vehicle vehicle);
    }
}