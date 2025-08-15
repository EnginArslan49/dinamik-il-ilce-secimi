namespace ililceSecimi.Models
{
    public class RegisterViewModel
    {

        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SelectedCityId { get; set; }
        public int? SelectedDistrictId { get; set; }
        public string Address { get; set; }

    }
}
