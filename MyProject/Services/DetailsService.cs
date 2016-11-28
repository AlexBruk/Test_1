using System.Collections.Generic;
using System.Linq;
using Test_1.DAL;
using Test_1.DAL.Models;
using Test_1.Models.OtherModels;
using Test_1.Models.ViewModels;

namespace Test_1.Services
{
    public class DetailsService : IDetailsService
    {
        public IEnumerable<Detail> GetDetails()
        {
            using (var db = new AtlantDbContext())
            {
                return db.Details.Select(c => new Detail
                {
                    Id = c.Id,
                    Code = c.Code,
                    Count = c.Count == null ? "Неизвестно" : c.Count.ToString(),
                    DateAdded = c.DateAdded,
                    Special = c.Special,
                    Name = c.Name,
                    StoreKeeperName = c.StoreKeeper.Name
                }).ToList();
            }
        }
        public IEnumerable<Detail> GetDetails(string code)
        {
            using (var db = new AtlantDbContext())
            {
                return db.Details.Where(c => c.Code.Contains(code)).Select(c => new Detail
                {
                    Code = c.Code,
                    Count = c.Count == null ? "Неизвестно" : c.Count.ToString(),
                    DateAdded = c.DateAdded,
                    Id = c.Id,
                    Special = c.Special,
                    Name = c.Name,
                    StoreKeeperName = c.StoreKeeper.Name
                }).ToList();
            }
        }

        public IEnumerable<StoreKeeper> GetStoreKeepers()
        {
            using (var db = new AtlantDbContext())
            {
                return db.StoreKeepers.ToList();
            }
        }


        public RezInfo AddDetail(AddDetailViewModel detail)
        {
            if (detail.DateAdded.DayOfWeek == System.DayOfWeek.Sunday || detail.DateAdded.DayOfWeek == System.DayOfWeek.Saturday)
            {
                return new RezInfo { Success = false, Info = "Выходной" };
            }

            try
            {
                using (var db = new AtlantDbContext())
                {
                    var newDetail = new Details
                    {
                        Code = detail.Code,
                        Name = detail.Name,
                        Count = detail.Count,
                        DateAdded = detail.DateAdded,
                        Special = detail.Special,
                        StoreKeeperId = detail.SelectedStoreKeeperId
                    };
                    db.Details.Add(newDetail);
                    db.SaveChanges();
                    return new RezInfo { Success = true, Info = "Деталь успешно добавлена" };
                }
            }
            catch
            {
                return new RezInfo { Success = false, Info = "Ошибка подключения к базе данных" };
            }
        }

        public RezInfo DeleteDetail(int id)
        {
            try
            {
                using (var db = new AtlantDbContext())
                {
                    var detail = db.Details.Find(id);
                    db.Details.Remove(detail);
                    db.SaveChanges();
                    return new RezInfo { Success = true, Info = "Деталь успешно удалена" };
                }
            }
            catch
            {
                return new RezInfo { Success = false, Info = "Ошибка подключения к базе данных" };
            }
        }

    }
}