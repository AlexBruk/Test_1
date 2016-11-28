using System.Collections.Generic;
using System.Linq;
using Test_1.DAL;
using Test_1.DAL.Models;
using Test_1.Models.OtherModels;
using Test_1.Models.ViewModels;

namespace Test_1.Services
{
    public class StoreKeeperService : IStoreKeeperService
    {
        public IEnumerable<Details> GetDetailsList()
        {
            using (var db = new AtlantDbContext())
            {
                return db.Details.ToList();
            }
        }

        public IEnumerable<StoreKeeper> GetStoreKeepers()
        {
            using (var db = new AtlantDbContext())
            {
                return db.StoreKeepers.ToList();
            }
        }

        public int GetCoung(int IdSK)
        {
            int sum = 0;
            using (var db = new AtlantDbContext())
            {
                IQueryable<Details> countdet = db.Details.Where(c => c.StoreKeeperId == IdSK).Select(c => c);
                foreach (Details num in countdet)
                {
                    sum += (int)num.Count;
                }
            }            
            return sum;
        }

        public RezInfo AddStoreKeeper(AddStoreKeeperViewModel storekeeper)
        {
            try
            {
                using (var db = new AtlantDbContext())
                {
                    var newSK = new StoreKeeper
                    {
                        Name = storekeeper.Name
                    };
                    db.StoreKeepers.Add(newSK);
                    db.SaveChanges();
                    return new RezInfo { Success = true, Info = "Кладовщик успешно добавлен" };
                }
            }
            catch
            {
                return new RezInfo { Success = false, Info = "Ошибка подключения к базе данных" };
            }
        }

        public RezInfo DeleteStoreKeeper(int id)
        {
            try
            {
                int sum = 0;
                using (var db = new AtlantDbContext())
                {
                    IQueryable<Details> countdet = db.Details.Where(c => c.StoreKeeperId == id).Select(c => c);
                    foreach (Details num in countdet)
                    {
                        sum += (int)num.Count;
                    }
                }
                using (var db = new AtlantDbContext())
                {
                    var storeKeeper = db.StoreKeepers.Find(id);
                    if (sum == 0)
                    {
                        db.StoreKeepers.Remove(storeKeeper);
                        db.SaveChanges();
                        return new RezInfo { Success = true, Info = "Кладовщик успешно удален" };
                    }
                    else
                    {
                        return new RezInfo { Success = false, Info = "На кладовщика записаны детали" };
                    }
                }
            }
            catch
            {
                return new RezInfo { Success = false, Info = "Ошибка подключения к базе данных" };
            }
        }
    }
}