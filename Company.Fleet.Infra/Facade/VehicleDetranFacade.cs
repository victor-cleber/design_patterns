using System.Text;
using System.Runtime.Serialization.Json;
using System.Net.WebSockets;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using Company.Fleet.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Company.Fleet.Infra.Facade
{
    public class VehicleDetranFacade : IVehicleDetran
    {
        private readonly DetranOptions _detranOptions;        
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor, 
        IHttpClientFactory httpClientFactory,
        IVehicleRepository vehicleRepository)
        {
            this._detranOptions = optionsMonitor.CurrentValue;
            this._httpClientFactory = httpClientFactory;
            this._vehicleRepository = vehicleRepository;
        }

       public async Task ScheduleInspection(Guid vehicleId){
            
            var vehicle = _vehicleRepository.GetById(vehicleId);

            var requestModel = new InspectionModel(){
                Plate = vehicle.Plate,
                ScheduledTo = DateTime.Now.AddDays(_detranOptions.NumberOfDaysForScheduling)
            };

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await client.PostAsync(_detranOptions.ScheduleUrl, contentString);
       }
    }
}