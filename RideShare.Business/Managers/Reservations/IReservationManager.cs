using RideShare.Entity;
using RideShare.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideShare.Business.Managers.Ride
{
    public interface IReservationManager
    {
        Task<int> AddAsync(ReservationCreateViewModel model);
        Task<List<ReservationViewModel>> GetAll();
        ReservationViewModel MapToViewModel(ReservationDataModel model);
    }
}