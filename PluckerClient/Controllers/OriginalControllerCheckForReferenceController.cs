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
    public class OriginalControllerCheckForReference : ControllerBase
    {
        private readonly em_portContext _context;

        public OriginalControllerCheckForReference(em_portContext context)
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
                    .AfterMap((src, dest, context) => dest.AllowedClientCountries = _context.ClientCountry
                        .Where(x => x.ClientId == id).Join(_context.Country,
                            clientcountry => clientcountry.CountryCode, country => country.CountryCode,
                            (clientcountry, country) =>
                                context.Mapper.Map<AllowedClientCountries>(country)));

                //new AllowedClientCountries()
                //{

                //    CountryCode = clientcountry.CountryCode,
                //    CountryCodeId = country.CountryCodeId,
                //    CountryShortName = country.CountryShortName,
                //    CountryName = country.CountryName
                //}
                //  ))

                //.AfterMap((src, dest) => dest.AllowedClientIndustries = _context.ClientIndustry
                //    .Where(x => x.ClientId == id)
                //    //    .Select(x =>  x.IndustryCode).ToList());
                //    .AfterMap((src, dest, context) => dest.AllowedClientIndustries = _context.ClientIndustry
                //        .Where(x => x.ClientId == id).Join(
                //            _context.Industry, clientIndustry => clientIndustry.IndustryCode,
                //            industry => industry.IndustryCode, ((ClientIndustry, industry) =>
                //                context.Mapper.Map<AllowedClientIndustries>(industry))));
                ////new Industry()
                //{
                //    IndustryCode = ClientIndustry.IndustryCode,
                //    IndustryName = industry.IndustryName,
                //    IsCustomIndustry = industry.IsCustomIndustry,
                //    IsFullReport = industry.IsFullReport,
                //    IsGmidindustry = industry.IsGmidindustry,
                //    IsImisindustry = industry.IsImisindustry,
                //    SequenceBy = industry.SequenceBy,
                //    SortOrder = industry.SortOrder,
                //    ExpandedLevels = industry.ExpandedLevels,
                //    OnlineNo = industry.OnlineNo,
                //    Dead = industry.Dead,
                //    HasDatagraphics = industry.HasDatagraphics,
                //    CategoryGroup = industry.CategoryGroup,
                //    PermissionGroupLevels = industry.PermissionGroupLevels,
                //    Notes = industry.Notes
                //})));
                //c.CreateMap<Country, AllowedClientCountries>();
                //c.CreateMap<Industry, AllowedClientIndustries>();
            });

            var mapper = config.CreateMapper();


            var clientsQuery = _context.Client.AsEnumerable().Where(c => c.ClientId == id)
                .Select(role => mapper.Map<ClientDto>(role));
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


