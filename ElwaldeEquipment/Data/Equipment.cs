using StarRatings;
using static ElwaldeEquipment.Data.EnumClass;

namespace ElwaldeEquipment.Data
{
    public class Equipment
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Source { get; set; }
        public string? SourceShort => Uri.TryCreate(Source, UriKind.Absolute, out var sourceUri) ? sourceUri.Authority : Source;
        
        public string Catagory { get; set; } 

        public string? Comments { get; set; }
        public IList<Review> Reviews { get; set; } = new List<Review>();
        public string Descriptions { get; set; } = "";
        public string[] Performances { get; set; } = Array.Empty<string>();
        public ProductDetail[] ProductDetails { get; set; } = Array.Empty<ProductDetail>();
        public string[] TestItems { get; set; } = Array.Empty<string>();
        public string[] Tags { get; set; } = Array.Empty<string>();
        public Dictionary<string, string> Specifications=new Dictionary<string, string>();
        public Dictionary<string, Dictionary<string,string>> Parameters = new Dictionary<string, Dictionary<string,string>>();
        public string[] Confugitation { get; set; } = Array.Empty<string>();

        public Uri CardImageUrl => new Uri($"images/cards/{Name}.png", UriKind.Relative);
        public Uri BannerImageUrl => new Uri($"images/banners/{Name} Banner.png", UriKind.Relative);
    }
}
