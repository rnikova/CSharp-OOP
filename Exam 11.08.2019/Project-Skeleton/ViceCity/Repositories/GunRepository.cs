using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public bool Remove(IGun model)
        {
            var removedModel = this.models.FirstOrDefault(m => m.Name == model.Name);

            if (removedModel == null)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }

        public IGun Find(string name)
        {
            var searchedGun = this.models.FirstOrDefault(m => m.Name == name);

            return searchedGun;
        }
    }
}
