namespace ElwaldeEquipment.Model
{
    public class Partners
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string LogoUri => $"images/partners/{Name}.png";
    }
}
