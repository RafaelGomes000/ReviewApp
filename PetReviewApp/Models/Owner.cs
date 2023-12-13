namespace PetReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public ICollection<PetOwner> PetOwners { get; set; }
    }
}
