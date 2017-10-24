using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using lunchPollNet.Models;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PollContext context)
        {
            // Look for any restaurants.
            if (context.Restaurant.Any())
            {
                return;   // DB has been seeded
            }

            Restaurant[] restaurants = new Restaurant[]
            {
                new Restaurant
                { 
                    Name = "Hullu Poro",
                    LunchUrl = "https://tampereelle.fi/fi-fi/lounas-ja-sunnuntaibrunssi/ravintola-poro/57/",
                    StreetAddress = "hullu poro osoite",
                    City = "kaupunki",
                    PostalCode = "33100",
                },
                new Restaurant
                { 
                    Name = "Amarillo",
                    LunchUrl = "https://tampereelle.fi/fi-fi/lounas-ja-sunnuntaibrunssi/ravintola-poro/57/",
                    StreetAddress = "Amarillo osoite",
                    City = "kaupunki",
                    PostalCode = "33100",
                },
                new Restaurant
                { 
                    Name = "Villisika",
                    LunchUrl = "https://tampereelle.fi/fi-fi/lounas-ja-sunnuntaibrunssi/ravintola-poro/57/",
                    StreetAddress = "Villisika osoite",
                    City = "kaupunki",
                    PostalCode = "33100",
                },
                new Restaurant
                { 
                    Name = "Salud",
                    LunchUrl = "https://tampereelle.fi/fi-fi/lounas-ja-sunnuntaibrunssi/ravintola-poro/57/",
                    StreetAddress = "Salud osoite",
                    City = "kaupunki",
                    PostalCode = "33100",
                },
                new Restaurant
                { 
                    Name = "Ainoya",
                    LunchUrl = "https://tampereelle.fi/fi-fi/lounas-ja-sunnuntaibrunssi/ravintola-poro/57/",
                    StreetAddress = "Ainoya osoite",
                    City = "kaupunki",
                    PostalCode = "33100",
                }
            };

            context.Restaurant.AddRange(restaurants);
            context.SaveChanges();

            Poll[] polls = new Poll[]
            {
                new Poll
                { 
                   Created = DateTime.Now,
                   ClosingTime = DateTime.Now.AddHours(-6)
                },
                new Poll
                { 
                   Created = DateTime.Now,
                   ClosingTime = DateTime.Now.AddHours(1)
                }
            };

            context.Poll.AddRange(polls);
            context.SaveChanges();

            PollItem[] pollItems = new PollItem[]
            {
                new PollItem
                {     
                    CreatedBy = "Jaska",
                    Description = "Lounaslistaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    TotalVoteCount = 2,
                    disabled = false,
                    Restaurant = restaurants[0],
                    Poll = polls[0]
                },
                new PollItem
                {     
                    CreatedBy = "Seppo",
                    Description = "Lounaslistaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    TotalVoteCount = 5,
                    disabled = false,
                    Restaurant = restaurants[1],
                    Poll = polls[0]
                },
                new PollItem
                {     
                    CreatedBy = "Jari",
                    Description = "Lounaslistaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    TotalVoteCount = -2,
                    disabled = false,
                    Restaurant = restaurants[2],
                    Poll = polls[0]
                },
                new PollItem
                {     
                    CreatedBy = "Teppo",
                    Description = "Lounaslistaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    TotalVoteCount = 2,
                    disabled = false,
                    Restaurant = restaurants[3],
                    Poll = polls[1]
                },
                new PollItem
                {     
                    CreatedBy = "Ripa",
                    Description = "Lounaslistaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    TotalVoteCount = 1,
                    disabled = false,
                    Restaurant = restaurants[1],
                    Poll = polls[1]
                }
            };

            context.PollItem.AddRange(pollItems);

            context.SaveChanges();
        }
    }
}