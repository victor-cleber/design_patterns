using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Company.Fleet.Domain;


namespace Company.Fleet.Infra.Repository
{
    public class InMemoryRepository : IVehicleRepository
    {
        private readonly IList<Vehicle> entities = new List<Vehicle>();

        public Vehicle GetById(Guid id) => entities.SingleOrDefault(c => c.Id == id);

        public IEnumerable<Vehicle> GetAll(){
            return entities.ToList();
        }

        public void Update(Vehicle vehicle){
            entities.Remove(GetById(vehicle.Id));
            entities.Add(vehicle);
        }

        public void Add(Vehicle vehicle) => entities.Add(vehicle);
        
        public void Delete(Vehicle vehicle) => entities.Remove(vehicle);
    }
}