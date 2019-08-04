using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> Models { get; set; }

        public MotorcycleRepository()
        {
            this.Models = new List<IMotorcycle>();
        }


        public void Add(IMotorcycle model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public IMotorcycle GetByName(string name)
        {
            var motorcycle = this.Models.FirstOrDefault(m => m.Model == name);

            return motorcycle;
        }

        public bool Remove(IMotorcycle model)
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
