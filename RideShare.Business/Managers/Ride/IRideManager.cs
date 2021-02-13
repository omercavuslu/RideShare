using RideShare.Entity;
using RideShare.ViewModel;
using RideShare.ViewModel.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideShare.Business.Managers.Ride
{
    public interface IRideManager
    {
        Task<int> AddAsync(RideCreateViewModel model);
        Task<List<RideViewModel>> GetAll();
        bool Update(RideUpdateViewModel model);
        List<RideViewModel> Find(RideQueryModel model);
       RideDataModel GetById(int id);
    }
}