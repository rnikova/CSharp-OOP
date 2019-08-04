using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> Models { get; set; }

        public RaceRepository()
        {
            this.Models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            var motorcycle = this.Models.FirstOrDefault(m => m.Name == name);

            return motorcycle;
        }

        public bool Remove(IRace model)
        {
            if (this.Models.Contains(model))
            {
                this.Models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
