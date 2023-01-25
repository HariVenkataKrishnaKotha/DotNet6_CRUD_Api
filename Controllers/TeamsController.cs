using DotNetAPI.Data;
using DotNetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public TeamsController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext= fullStackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _fullStackDbContext.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam([FromBody] Team teamRequest)
        {
            teamRequest.Id = Guid.NewGuid();
            await _fullStackDbContext.Teams.AddAsync(teamRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(teamRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTeam([FromRoute] Guid id)
        {
            var team = await _fullStackDbContext.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if(team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateTeam([FromRoute] Guid id, Team updateTeamRequest)
        {
            var team = await _fullStackDbContext.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }
            team.Name = updateTeamRequest.Name;
            team.Owner = updateTeamRequest.Owner;
            team.Championships = updateTeamRequest.Championships;
            team.Fanbase = updateTeamRequest.Fanbase;
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(team);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> DeleteTeam([FromRoute] Guid id)
        {
            var team = await _fullStackDbContext.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Teams.Remove(team);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(team);
        }
    }
}
