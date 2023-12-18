namespace PetReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public Reviewer Reviewer { get; set; }
        public Pet Pet { get; set; }
    }
}
