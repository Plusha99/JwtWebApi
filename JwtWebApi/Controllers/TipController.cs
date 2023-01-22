using JwtWebApi.Data;
using JwtWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipController : ControllerBase
    {
        private readonly DataContext _context;

        public TipController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Tip>>> GetAllTips()
        {
            return Ok(await _context.Tips.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tip>>> GetByIdTip(int id)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip == null)
                return NotFound("No tip here. :/");
            return Ok(tip);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List<Tip>>> CreateTip(Tip tip)
        {
            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();
            return Ok(await _context.Tips.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Tip>>> UpdateTip(Tip tip, int id)
        {
            var dbTip = await _context.Tips.FindAsync(id);
            if (dbTip == null)
                return NotFound("No tip here. :/");

            dbTip.Content = tip.Content;

            await _context.SaveChangesAsync();
            return Ok(await _context.Tips.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Tip>>> DeleteTip(int id)
        {
            var dbTip = await _context.Tips.FindAsync(id);
            if (dbTip == null)
                return NotFound("No tip here. :/");

            _context.Tips.Remove(dbTip);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tips.ToListAsync());
        }
    }
}
