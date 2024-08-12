using Homework_02.Models;

namespace Homework_02
{
    public static class StaticDb
    {
        public static List<Beverage> Beverages = new List<Beverage>
    {
        new Beverage { Brand = "Coca-Cola", Type = "Soda" },
        new Beverage { Brand = "Fanta", Type = "Soda" },
        new Beverage { Brand = "Nestea", Type = "Tea" },
        new Beverage { Brand = "Bravo", Type = "Juice" },
    };

    }
}
