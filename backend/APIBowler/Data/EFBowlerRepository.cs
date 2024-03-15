
namespace APIBowler.Data
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlerContext _context;

        public EFBowlerRepository(BowlerContext temp) {
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers.ToList();

        public IEnumerable<Team> Teams => _context.Teams.ToList();



    }
}
