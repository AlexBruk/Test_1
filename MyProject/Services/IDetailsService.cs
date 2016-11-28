using System.Collections.Generic;
using Test_1.DAL.Models;
using Test_1.Models.OtherModels;
using Test_1.Models.ViewModels;

namespace Test_1.Services
{
    public interface IDetailsService
    {
        IEnumerable<Detail> GetDetails(string code);
        IEnumerable<Detail> GetDetails();

        IEnumerable<StoreKeeper> GetStoreKeepers();
        RezInfo AddDetail(AddDetailViewModel detail);
        RezInfo DeleteDetail(int id);
    }
}
