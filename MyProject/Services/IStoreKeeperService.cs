using System.Collections.Generic;
using Test_1.DAL.Models;
using Test_1.Models.OtherModels;
using Test_1.Models.ViewModels;

namespace Test_1.Services
{
    public interface IStoreKeeperService
    {
        IEnumerable<Details> GetDetailsList();
        IEnumerable<StoreKeeper> GetStoreKeepers();
        RezInfo AddStoreKeeper(AddStoreKeeperViewModel storekeeper);
        RezInfo DeleteStoreKeeper(int id);
        int GetCoung(int IdSK);
    }
}
