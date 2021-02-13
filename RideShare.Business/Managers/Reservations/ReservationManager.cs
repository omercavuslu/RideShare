using RideShare.DataAccess.Repository;
using RideShare.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using RideShare.Entity;
using System.Threading.Tasks;
using RideShare.ViewModel;
using System.Linq;

namespace RideShare.Business.Managers.Ride
{
    public class ReservationManager : IReservationManager
    {
        private IUnitOfWork _unitOfWork;
        private IRideManager _rideManager;
        private IRepository<ReservationDataModel> _repository;
        public ReservationManager(IUnitOfWork unitOfWork,IRideManager rideManager)
        {
            _unitOfWork = unitOfWork;
            _rideManager = rideManager;
            _repository = _unitOfWork.GetRepository<ReservationDataModel>();
        }

        public async Task<int> AddAsync(ReservationCreateViewModel model)
        {
            var ride = _rideManager.GetById(model.rideId);
            if(ride.Reservations.Count < ride.seat)
            {
                var dataModel = MapToDataModel(model);
                dataModel.isActive = true;
                dataModel.createTime = DateTimeOffset.Now.ToUnixTimeSeconds();
                await _repository.AddAsync(dataModel);
                _unitOfWork.SaveChanges();

                return dataModel.id;
            }
            else
            {
                return 0;
            }

        }

        public async Task<List<ReservationViewModel>> GetAll()
        {
            var allReservations =  await _repository.GetAllAsync();
            return new List<ReservationViewModel>();
        }


        public ReservationViewModel MapToViewModel(ReservationDataModel model)
        {
            return new ReservationViewModel()
            {
                name = model.name,
                surname = model.surname,
                isActive = model.isActive,
                ride = MapToViewModel(model.ride),
                rideId = model.rideId

                
            };
        }

        private RideViewModel MapToViewModel(RideDataModel model)
        {
            return new RideViewModel()
            {
                Date = model.Date,
                from = model.from,
                to = model.to,
                seat = model.seat,
                description = model.description,
                isActive = model.isActive,
                Reservations = model.Reservations.Select(x => MapToViewModel(x)).ToList()

            };
        }

        private ReservationDataModel MapToDataModel(ReservationCreateViewModel model)
        {
            return new ReservationDataModel()
            {
                name = model.name,
                surname = model.surname,
                rideId = model.rideId
            };
        }
    }
}
