using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    public HeroController()
    {
    }

    [HttpGet]
    public ActionResult<List<Hero>> GetAll() =>
        HeroService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Hero> Get(int id)
    {
        var hero = HeroService.Get(id);

        if(hero == null)
            return NotFound();

        return hero;
    }

    [HttpGet("search/{query}")]
    public ActionResult<List<Hero>> Search(string query)
    {
        var hero = HeroService.Search(query);

        if(hero == null)
            return NotFound();

        return hero;
    }

    [HttpPost]
    public IActionResult Create(Hero hero)
    {    
        HeroService.Add(hero);
        return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Hero hero)
    {
        if (id != hero.Id)
            return BadRequest();
            
        var existingHeroes = HeroService.Get(id);
        if(existingHeroes is null)
            return NotFound();
    
        HeroService.Update(hero);           
    
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Heroes = HeroService.Get(id);
    
        if (Heroes is null)
            return NotFound();
        
        HeroService.Delete(id);
    
        return NoContent();
    }
}