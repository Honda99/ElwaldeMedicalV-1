using ElwaldeEquipment.Model;

namespace ElwaldeEquipment.Data
{
    public interface IPartnersStore
    {
        Task<List<Partners>> GetPartners();
    }
}
