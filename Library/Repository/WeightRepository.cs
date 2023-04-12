using System;
using Library.Context;
using Library.Models;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
	public class WeightRepository : IRepository<WeightDbModel>
	{
        private readonly WeightContext expenseContext;

        public WeightRepository(WeightContext weightContext)
        {
            this.weightContext = weightContext;
        }
        public void Add(WeightDbModel item)
        {
            weightContext.Add(item);
            weightContext.SaveChanges();
        }

        public bool Exists(string id)
        {
            return weightContext.WeightDbModels.Any(e => e._id == id);
        }

        public List<WeightDbModel> Find(Expression<Func<WeightDbModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public WeightDbModel? Get(string? id)
        {
            return weightContext.WeightDbModels.FirstOrDefault(m => m._id == id);
        }

        public List<WeightDbModel> GetAll()
        {
            return weightContext.WeightDbModels.ToList();
        }

        public void Remove(string id)
        {
            var weight = weightContext.WeightDbModels.Find(id);
            if (weight != null)
            {
                weightContext.WeightDbModels.Remove(weight);
                weightContext.SaveChanges();
            }
        }

        public WeightDbModel Update(WeightDbModel item)
        {
            weightContext.Update(item);
            weightContext.SaveChanges();
            return item;
        }
    }
}

