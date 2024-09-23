using CarDropDownMenu.Models;

public class CarBrand
{
    public int CarBrandId { get; set; }
    
    public required string BrandName { get; set; }
    public bool ActiveFlag { get; set; }

    // Navigation property for many-to-many relationship
   public ICollection<CarBrandCarMakeMatrix> CarBrandCarMakeMatrix { get; set; } = new List<CarBrandCarMakeMatrix>();

}
