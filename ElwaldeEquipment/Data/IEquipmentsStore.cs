namespace ElwaldeEquipment.Data
{
    public interface IEquipmentsStore
    {
        Task<IEnumerable<Equipment>> GetEquipments(string query = "");

        Task<Equipment?> GetEquipment(string id);

        Task<Equipment> UpdateEquipment(Equipment recipe);
    }
}
