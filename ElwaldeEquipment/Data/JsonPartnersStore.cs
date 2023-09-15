using ElwaldeEquipment.Model;
using ElwaldeEquipment.Pages;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ElwaldeEquipment.Data
{
    public class JsonPartnersStore:IPartnersStore
    {
        private List<Partners> partners;

        private bool dataInitialized = true;
        public JsonPartnersStore()
        {

         
        }
        public async Task<List<Partners>> GetPartners()
        {
            if (dataInitialized)
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("https://honda99.github.io/ElwaldeMedicalV-1/partners.json");
             
                var result = JsonConvert.DeserializeObject<List<Partners>>(json);
                if (result is null)
                {
                    throw new InvalidDataException("Failed to deserialize partners: partner is null");
                }
                this.partners =result;
                dataInitialized= false; 
            }
           
          
            return partners;
          
        }

      
    }
}
  

