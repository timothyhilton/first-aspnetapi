using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class HeroService
{
    static List<Hero> Heroes { get; }

    static int nextId = 21;
    static HeroService()
    {
        Heroes = new List<Hero>
        {
            new Hero { Id = 12, Name = "Dr. Nice" },
            new Hero { Id = 13, Name = "Bombasto" },
            new Hero { Id = 14, Name = "Celeritas" },
            new Hero { Id = 15, Name = "Magneta" },
            new Hero { Id = 16, Name = "RubberMan" },
            new Hero { Id = 17, Name = "Dynama" },
            new Hero { Id = 18, Name = "Dr. IQ" },
            new Hero { Id = 19, Name = "Magma" },
            new Hero { Id = 20, Name = "Tornado" },
        };
    }

    public static List<Hero> GetAll() => Heroes;

    public static Hero? Get(int id) => Heroes.FirstOrDefault(h => h.Id == id);

    public static void Add(Hero hero)
    {
        hero.Id = nextId++;
        Heroes.Add(hero);
    }

    public static void Delete(int id)
    {
        var hero = Get(id);
        if(hero is null)
            return;

        Heroes.Remove(hero);
    }

    public static void Update(Hero hero)
    {
        var index = Heroes.FindIndex(h => h.Id == hero.Id);
        if(index == -1)
            return;

        Heroes[index] = hero;
    }
    public static List<Hero>? Search(string query) {
        return Heroes.Where(hero => hero.Name.ToLower().Contains(query.ToLower())).ToList();
    }
}