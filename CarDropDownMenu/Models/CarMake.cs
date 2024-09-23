using CarDropDownMenu.Models;

public class CarMake
{
    public int CarMakeId { get; set; }
    public required string MakeName { get; set; }

        public bool ActiveFlag { get; set; }
    

    // Navigation property for many-to-many relationship
    public ICollection<CarBrandCarMakeMatrix> CarBrandCarMakeMatrix { get; set; } = new List<CarBrandCarMakeMatrix>();

}
