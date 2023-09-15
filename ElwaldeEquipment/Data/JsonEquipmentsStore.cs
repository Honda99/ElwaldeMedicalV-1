using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ElwaldeEquipment.Data
{
    public class JsonEquipmentsStore:IEquipmentsStore
    {

       private bool dataInitialized=true; 
            private  Dictionary<string, Equipment> equipments;
            private  InMemorySearchProvider searchProvider;

            // Inject the IHttpClientFactory service in the constructor
            public JsonEquipmentsStore()
            {
           
             equipments = new Dictionary<string, Equipment>();  
            searchProvider=new InMemorySearchProvider(equipments);    
              
            }
        

        public async Task<IEnumerable<Equipment>> GetEquipments(string query)
        {
            // Fetch the JSON file from the server asynchronously
            if (dataInitialized)
            {
                var client =new HttpClient();       
                var json = await client.GetStringAsync("https://honda99.github.io/ElwaldeMedicalV-1/equipments.json");
                // Deserialize the JSON data into a dictionary of equipments
                var equipments = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(json);
                if (equipments is null)
                {
                    throw new InvalidDataException("Failed to deserialize equipments: equipment is null");
                }
                this.equipments = equipments;
                // Create an in-memory search provider with the equipments
                searchProvider = new InMemorySearchProvider(equipments);
                dataInitialized= false;
            }
           
            if (string.IsNullOrWhiteSpace(query))
            {
                return equipments.Values;
            }
            return searchProvider.Search(query);
        }

        public Task<Equipment?> GetEquipment(string id)
        {
            equipments.TryGetValue(id, out var equipment);
            return Task.FromResult(equipment);
        }

        public Task<Equipment> UpdateEquipment(Equipment equipment)
        {
            return Task.FromResult(equipment);
        }
    }
}
