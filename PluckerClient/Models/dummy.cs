using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluckerClient.Models
{
    public class dummy
    {
        //  Mapper.Initialize(cfg => cfg.CreateMap<ClientCountry, ClientDTO>().AfterMap((Src, Dest) => Dest.clientCountries = _context.ClientCountry.Where(x => x.ClientId == id).Select(x => x.CountryCode).ToList()));





        //select 
        //{


        //    ClientId = c.ClientId,
        //    Name = c.Name,
        //    ZipfileName = c.ZipfileName,
        //    AllCountries = c.AllCountries,
        //    clientCountries = _context.ClientCountry.Where(x => x.ClientId == id).Select(x => x.CountryCode).ToList(),
        //    clientIndustries = _context.ClientIndustry.Where(x=>x.ClientId == id).Select(x=>x.IndustryCode).ToList(),
        //    AllIndustries = c.AllIndustries,
        //    GetsWord = c.GetsWord,
        //    GetsLoadsheet = c.GetsLoadsheet,
        //    GetsPpt = c.GetsPpt,
        //    GetsPdf = c.GetsPdf,
        //    GetsControlFiles = c.GetsControlFiles
        //};


        //var clients1 = from c in _context.Client
        //               join clientcountry in _context.ClientCountry on c.ClientId equals clientcountry.ClientId
        //               where c.ClientId == id
        //               select new ClientDTO
        //               {
        //                   ClientId = c.ClientId,
        //                   Name = c.Name,
        //                   ZipfileName = c.ZipfileName,
        //                   AllCountries = c.AllCountries,
        //                   clientCountries =_context.ClientCountry.Where(x=>x.ClientId == id).Select(x=>x.CountryCode).ToList(),
        //                   AllIndustries = c.AllIndustries,
        //                   GetsWord = c.GetsWord,
        //                   GetsLoadsheet = c.GetsLoadsheet,
        //                   GetsPpt = c.GetsPpt,
        //                   GetsPdf = c.GetsPdf,
        //                   GetsControlFiles = c.GetsControlFiles
        //               };



        //if (clients == null)
        //{
        //    return NotFound();

        //}

        //if (clients. == false)
        //{
        //    var query = from client in _context.ClientCountry
        //                where client.ClientId == id
        //                select client.CountryCode;
        //    foreach (var item in query)
        //    {
        //        list.Add(item);
        //    }
        //}

        //var clientCountries = new { clientCountries = list };
        ////JsonResult result = new JsonResult(list);

        //var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(clientCountries);
        //var config = new MapperConfiguration(c =>
        //{

        //    c.CreateMap<ClientCountry, ClientDto>()
        //        //.AfterMap((src, dest) => dest.AllowedClientCountries = _context.ClientCountry.Where(x => x.ClientId == id)
        //        //    .Select(x => x.CountryCode).ToList())
        //        //.AfterMap((src,dest) =>dest.AllowedClientCountries = _context.ClientCountry.Join(_context.C) )
        //        .AfterMap((src, dest) => dest.AllowedClientIndustries = _context.ClientIndustry.Where(x => x.ClientId == id)
        //            .Select(x => x.IndustryCode).ToList());


        //});

        //var mapper = config.CreateMapper();


        //var clientsQuery = _context.Client.AsEnumerable().Where(c => c.ClientId == id)
        //        .Select(role => mapper.Map<ClientCountry, ClientDto>(role));


        //    return Ok(clientsQuery);
    }
}
