using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PluckerClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluckerClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly em_portContext _context;

        public ClientsController(em_portContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await _context.Client.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Client, ClientDto>()
                    //.AfterMap((src, dest) => dest.AllowedClientCountries = _context.ClientCountry.Where(x => x.ClientId == id)
                    //    .Select(x => x.CountryCode).ToList())
                    ////.AfterMap((src,dest) =>dest.AllowedClientCountries = _context.ClientCountry.Join(_context.C) )
                    .AfterMap((src, dest) => dest.AllowedClientIndustries = _context.ClientIndustry
                        .Where(x => x.ClientId == id)
                        .Select(x => x.IndustryCode).ToList());
            });

            var mapper = config.CreateMapper();


            var clientsQuery = _context.Client.AsEnumerable().Where(c => c.ClientId == id)
                .Select(role => mapper.Map<Client, ClientDto>(role));
            return Ok(clientsQuery);
        }
    }

        // PUT: api/Clients/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClient(int id, Client client)
        //{
        //    if (id != client.ClientId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(client).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Clients
        //[HttpPost]
        //public async Task<ActionResult<Client>> PostClient(Client client)
        //{
        //    _context.Client.Add(client);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        //}

        //// DELETE: api/Clients/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Client>> DeleteClient(int id)
        //{
        //    var client = await _context.Client.FindAsync(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Client.Remove(client);
        //    await _context.SaveChangesAsync();

        //    return client;
        //}

        //private bool ClientExists(int id)
        //{
        //    return _context.Client.Any(e => e.ClientId == id);
        //}
    }


