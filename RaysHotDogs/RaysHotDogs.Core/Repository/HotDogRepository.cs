using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogGroupId = 1, Title = "Meat lovers", ImagePath = "", HotDogs = new List<HotDog>
                {
                    new HotDog()
                    {
                        HotDogId = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on thos planet",
                        Description = "Manchego smelly cheese danish fontina",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Regular bun", "Sausage", "Ketchup"},
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 2,
                        Name = "Haute Dog",
                        ShortDescription = "The classy one",
                        Description = "Bacon ipsum dolor amet turducken ham t-bone",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Baked bun", "Gourmet sausage"},
                        Price = 10,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        HotDogId = 3,
                        Name = "Extra Long",
                        ShortDescription = "For when a regurlat one isn't enough",
                        Description = "Capicola short lion shoulder strip steak ribeye",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Extra Long bun", "Extra Long sausage"},
                        Price = 8,
                        IsFavorite = true
                    }
                }
            },
            new HotDogGroup()
            {
                HotDogGroupId = 2, Title = "Veggie lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 4,
                        Name = "Veggie Hot Dog",
                        ShortDescription = "American for non-meat-lovers",
                        Description = "Veggies es bonus vobis, proinde vos postulo",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Bun", "Vegetarian sausage"},
                        Price = 8,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        HotDogId = 5,
                        Name = "Haute Dog Veggie",
                        ShortDescription = "Classy and Veggie",
                        Description = "Turnip greens yarrow ricebean rutabaga endive",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Baked bun", "Gourmet vegetarian Sausage"},
                        Price = 10,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 6,
                        Name = "Extra Long Veggie",
                        ShortDescription = "For when a regurlat one isn't enough",
                        Description = "Beetroot water spinach okra water chestnut ricebean",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Extra Long bun", "Extra Long veg sausage"},
                        Price = 8,
                        IsFavorite = false
                    }
                }
            }
        };

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.HotDogId == hotDogId
                select hotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

            if(group != null)
            {
                return group.HotDogs;
            }
            return null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
            from hotDogGroup in hotDogGroups
            from hotDog in hotDogGroup.HotDogs
            where hotDog.IsFavorite
            select hotDog;
            return hotDogs.ToList<HotDog>();
        }
    }
}
