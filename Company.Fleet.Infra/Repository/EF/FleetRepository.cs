using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Company.Fleet.Domain;

namespace Company.Fleet.Infra.Repository.EF
{
    public class FleetRepository : IVehicleRepository{
        private readonly FleetContext dbContext;

        public FleetRepository(FleetContext dbContext) => this.dbContext = dbContext;

        public void Add(Vehicle vehicle){
             dbContext.Vehicles.Add(vehicle);
             dbContext.SaveChanges();
        }

        public void Delete(Vehicle vehicle){
            dbContext.Vehicles.Remove(vehicle);
            dbContext.SaveChanges();
        }

        public IEnumerable<Vehicle> GetAll() => dbContext.Vehicles.ToListAsync().Result;

        public Vehicle GetById(Guid id) => dbContext.Vehicles.SingleOrDefaultAsync().Result;

        public void Update(Vehicle vehicle){
            dbContext.Entry(vehicle).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}