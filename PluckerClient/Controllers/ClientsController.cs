using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PluckerClient.Models;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<Client>> GetClient()
        {
            var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<Client, ClientDto>()
                        .AfterMap((src, dest, context) => dest.AllowedClientCountries = _context.ClientCountry
                            .Where(x => x.ClientId == src.ClientId).Join(_context.Country,
                                clientCountry => clientCountry.CountryCode, country => country.CountryCode,
                                (clientCountry, country) => context.Mapper.Map<AllowedClientCountries>(country)))

                        .AfterMap((src, dest, context) => dest.AllowedClientIndustries = _context.ClientIndustry
                            .Where(x => x.ClientId == src.ClientId).Join(
                                _context.Industry, clientIndustry => clientIndustry.IndustryCode,
                                industry => industry.IndustryCode, (clientIndustry, industry) =>
                                    context.Mapper.Map<Industry, AllowedClientIndustries>(industry)));
                });


                var mapper = config.CreateMapper();
                var clientsQuery =_context.Client.AsEnumerable()
                    .Select(role => mapper.Map<ClientDto>(role));

                var clients = clientsQuery.ToList();


                return Ok(clients);

        }
    

    //GET: api/Clients/5
            [HttpGet("{id}")]
        public ActionResult<Client> GetClient(int clientId)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Client, ClientDto>()
                      .AfterMap((src, dest, context) => dest.AllowedClientCountries = _context.ClientCountry
                        .Where(clientCountry => clientCountry.ClientId == src.ClientId).Join(_context.Country,
                            clientCountry => clientCountry.CountryCode, country => country.CountryCode,
                            (clientCountry, country) => context.Mapper.Map<AllowedClientCountries>(country)))

                      .AfterMap((src, dest, context) => dest.AllowedClientIndustries = _context.ClientIndustry
                        .Where(clientCountry => clientCountry.ClientId == src.ClientId).Join(
                            _context.Industry, clientIndustry => clientIndustry.IndustryCode,
                            industry => industry.IndustryCode, (clientIndustry, industry) =>
                                context.Mapper.Map<AllowedClientIndustries>(industry)));

             
            });

            var mapper = config.CreateMapper();
            var clientsQuery = _context.Client.AsEnumerable().Where(c => c.ClientId == clientId)
                .Select(role => mapper.Map<ClientDto>(role));
            return Ok(clientsQuery);
        }
        //}

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
}


