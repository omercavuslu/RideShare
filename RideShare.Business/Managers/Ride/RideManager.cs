using RideShare.DataAccess.Repository;
using RideShare.DataAccess.UnitOfWork;
using RideShare.Entity;
using RideShare.ViewModel;
using RideShare.ViewModel.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.Business.Managers.Ride
{
    public class RideManager : IRideManager
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<RideDataModel> _repository;
        public RideManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<RideDataModel>();
        }

        public async Task<int> AddAsync(RideCreateViewModel model)
        {
            var dataModel = MapToDataModel(model);
            dataModel.isActive = true;
            dataModel.createTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            await _repository.AddAsync(dataModel);
            _unitOfWork.SaveChanges();

            return dataModel.id;

        }

        public async Task<List<RideViewModel>> GetAll()
        {

            var allRides = _repository.Include(x => x.Reservations);
            var list = new List<RideDataModel>(allRides.AsQueryable().Cast<RideDataModel>());
            return list.Select(x => MapToViewModel(x)).ToList();
        }

        public bool Update(RideUpdateViewModel model)
        {
            var updatedModel = GetById(model.id);
            updatedModel.description = model.description;
            updatedModel.Date = model.Date;
            updatedModel.seat = model.seat;
            updatedModel.to = model.to;
            updatedModel.from = model.from;
            updatedModel.isActive = model.isActive;
            updatedModel.updateTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            _repository.Update(updatedModel);
            _unitOfWork.SaveChanges();
            return true;
        }


        public RideDataModel GetById(int id)
        {
            var allRides = _repository.Include(x => x.Reservations);
            var ride = allRides.Cast<RideDataModel>().FirstOrDefault(x => x.id == id);
            return ride;
        }



        public List<RideViewModel> Find(RideQueryModel model)
        {
            var rides = _repository.Find(x =>
            x.from == model.from &&
            x.to == model.to);


            return rides.Select(x => MapToViewModel(x)).ToList();
        }

        public RideDataModel MapToDataModel(RideUpdateViewModel model)
        {
            return new RideDataModel()
            {

                Date = model.Date,
                from = model.from,
                to = model.to,
                seat = model.seat,
                description = model.description,
                isActive = model.isActive,

            };
        }
        public RideUpdateViewModel MapToUpdateViewModel(RideDataModel model)
        {
            return new RideUpdateViewModel()
            {
                Date = model.Date,
                from = model.from,
                to = model.to,
                seat = model.seat,
                description = model.description,
                isActive = model.isActive,

            };
        }



        public RideViewModel MapToViewModel(RideDataModel model)
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


        public ReservationViewModel MapToViewModel(ReservationDataModel model)
        {
            return new ReservationViewModel()
            {
                name = model.name,
                surname = model.surname,
                isActive = model.isActive,
                rideId = model.rideId
            };
        }

        private RideDataModel MapToDataModel(RideCreateViewModel model)
        {
            return new RideDataModel()
            {
                Date = model.Date,
                from = model.from,
                to = model.to,
                seat = model.seat,
                description = model.description
            };
        }
    }
}
