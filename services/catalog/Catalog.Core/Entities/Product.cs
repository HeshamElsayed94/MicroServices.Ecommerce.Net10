namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
	public string Name { get; set; }
	public string Description { get; set; }
	public string Summary { get; set; }
	public string ImageFile { get; set; }
	[Bason.Representation(Bson.Type.Decimal128)]
	public decimal Price { get; set; }
	public ProuductBrand Brand { get; set; }
	public ProuductType Type { get; set; }
}
