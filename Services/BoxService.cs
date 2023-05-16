using Geopharm_testttt.Data;
using Geopharm_testttt.Models;

namespace Geopharm_testttt.Services
{
    public class BoxService
    {
        private readonly ApplicationContext context = new ApplicationContext();

        public BoxService()
        { 
        }

        public List<Box> GetRows(int from, int to)
        {
            var rows = context.Boxes.Skip(from - 1).Take(to - from + 1).ToList();
            return rows;
        } 
    }
}
