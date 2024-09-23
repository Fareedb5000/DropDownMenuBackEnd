using System.ComponentModel.DataAnnotations;

namespace CarDropDownMenu.Models
{
    public class Submit
    {
        [Key] // Mark CarBrandID as the primary key
        public string CarBrandID { get; set; }

        public string CarMakeID { get; set; }

    }
}
