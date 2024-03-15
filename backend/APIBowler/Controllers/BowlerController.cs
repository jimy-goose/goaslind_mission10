using APIBowler.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace APIBowler.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;

        public BowlerController(IBowlerRepository temp) {
            _bowlerRepository = temp;
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var joinedData = (from bowler in _bowlerRepository.Bowlers
                             join team in _bowlerRepository.Teams
                             on bowler.TeamID equals team.TeamID
                             where team.TeamName == "Marlins" | team.TeamName == "Sharks"
                             select new
                             {
                                 BowlerID = bowler.BowlerID,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 TeamName = team.TeamName,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                             }).ToArray();

            return joinedData;
        }

    }
}
