using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private List<IRider> Models { get; set; }

        public RiderRepository()
        {
            this.Models = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            var motorcycle = this.Models.FirstOrDefault(m => m.Name == name);

            return motorcycle;
        }

        public bool Remove(IRider model)
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
