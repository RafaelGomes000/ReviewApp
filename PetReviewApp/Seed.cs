using PetReviewApp.Data;
using PetReviewApp.Models;

namespace PetReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PetOwners.Any())
            {
                var petOwners = new List<PetOwner>()
                {
                    new PetOwner()
                    {
                        Pet = new Pet()
                        {
                            Name = "Bella",
                            BirthDate = new DateTime(2010,1,1),
                            PetCategories = new List<PetCategory>()
                            {
                                new PetCategory { Category = new Category() { Name = "Dog"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Bella",Text = "Bella is the best pet, because it is a dog", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Bella", Text = "Bella is the best", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Bella",Text = "Bella, Bella, Bella", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "Stephan",
                            City = "Paris",
                            Country = new Country()
                            {
                                Name = "France"
                            }
                        }
                    },
                    new PetOwner()
                    {
                        Pet = new Pet()
                        {
                            Name = "Max",
                            BirthDate = new DateTime(2015,5,7),
                            PetCategories = new List<PetCategory>()
                            {
                                new PetCategory { Category = new Category() { Name = "Cat"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Max", Text = "Max is the best, because it is a cat", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Max",Text = "Max is the best", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Max", Text = "Max, Max, Max", Rating = 2,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Harry",
                            LastName = "Klose",
                            City = "Toronto",
                            Country = new Country()
                            {
                                Name = "Canada"
                            }
                        }
                    },
                    new PetOwner()
                    {
                        Pet = new Pet()
                        {
                            Name = "Luna",
                            BirthDate = new DateTime(2016,7,10),
                            PetCategories = new List<PetCategory>()
                            {
                                new PetCategory { Category = new Category() { Name = "Bird"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Luna",Text = "Luna is the best, because it is a bird", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Luna",Text = "Luna is the best", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Luna",Text = "Luna, Luna, Luna", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Daisy",
                            LastName = "Charlie",
                            City = "London",
                            Country = new Country()
                            {
                                Name = "England"
                            }
                        }
                    }
                };
                dataContext.PetOwners.AddRange(petOwners);
                dataContext.SaveChanges();
            }
        }
    }
}