using AutoMapper;
using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using FlightOperations.Repository;
using FlightOperations.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Services
{
    public interface IcommercialPlanningServices {
        AirlineScheduleDTO CreateAirlineSchedule(AirlineScheduleDTO_edit obj);
        AirlineScheduleDTO GetAirlineSchedule(int id);
        IEnumerable<AirlineScheduleDTO> GetAllAirlineSchedule();
        void DeleteAirlineSchedule(int id);
        void PublishAirlineSchedule(AirlineScheduleDTO_verify obj);
        void UnpublishAirlineSchedule(AirlineScheduleDTO_verify obj);
        void UpdateAirlineSchedule(AirlineScheduleDTO_edit obj);

        Schedule_AircraftTypeDTO CreateSchedule_AircraftType(Schedule_AircraftTypeDTO_edit obj);
        Schedule_AircraftTypeDTO GetSchedule_AircraftType(int id);
        IEnumerable<Schedule_AircraftTypeDTO> GetAllSchedule_AircraftType();
        IEnumerable<Schedule_AircraftTypeDTO> GetAllSchedule_AircraftType_ByAirlineSched(int id);
        void DeleteSchedule_AircraftType(int id);
        void UpdateSchedule_AircraftType(Schedule_AircraftTypeDTO_edit obj);
    }
    public class commercialPlanningServices:IcommercialPlanningServices
    {
        private FlightOperationsContext _context;
        private IMapper _mapper;
        private commercialPlanningRepository _commercialPlanRepo;
        private ResourceRepository _resourceRepo;
        private aircraftRepository _aircraftRepo;
        private flightscheduleRepository _flightSchedRepo;
        public commercialPlanningServices(FlightOperationsContext foContext,IMapper mapper)
        {
            _context = foContext;
            _mapper = mapper;
            _commercialPlanRepo = new commercialPlanningRepository(_context);
            _resourceRepo = new ResourceRepository(_context);
            _aircraftRepo = new aircraftRepository(_context);
            _flightSchedRepo = new flightscheduleRepository(_context);
        }
        #region AirlineSchedule
        public AirlineScheduleDTO CreateAirlineSchedule(AirlineScheduleDTO_edit obj)
        {
            var airlineSched = _mapper.Map<AirlineSchedule>(obj);
            airlineSched.CreatedDate = DateTime.UtcNow;
            airlineSched.UpdatedDate = airlineSched.CreatedDate;
            airlineSched.PeriodFrom = obj.PeriodFrom.ToUniversalTime();
            airlineSched.PeriodTo = obj.PeriodTo.ToUniversalTime();
            List<ScheduleResource> schedResources = new List<ScheduleResource>();
            airlineSched.isDeleted = false;
            try
            {
                foreach (var aircraftType in airlineSched.AircraftTypes)
                {
                    var ACtype = _aircraftRepo.GetAircraftType(aircraftType.AircraftTypeId);
                    aircraftType.CreatedDate = airlineSched.CreatedDate;
                    aircraftType.UpdatedDate = aircraftType.CreatedDate;
                    aircraftType.CreatedBy = airlineSched.CreatedBy;
                    aircraftType.UpdatedBy = airlineSched.UpdatedBy;
                    aircraftType.isDeleted = false;

                    for(int x=0;x < aircraftType.Quantity; x++)
                    {
                        ScheduleResource schedRes = new ScheduleResource();
                        schedRes.Name = ACtype.AircraftTypeName;
                        schedRes.Description = "";
                        schedRes.AircraftTypeID = aircraftType.AircraftTypeId;
                        schedRes.CreatedBy = airlineSched.CreatedBy;
                        schedRes.UpdatedBy = airlineSched.UpdatedBy;
                        schedRes.CreatedDate = airlineSched.CreatedDate;
                        schedRes.UpdatedDate = aircraftType.CreatedDate;
                        schedRes.isDeleted = false;
                        schedResources.Add(schedRes);
                    }
                }
                airlineSched.ScheduleResources = schedResources;
                _commercialPlanRepo.CreateAirlineSchedule(airlineSched);
                _context.SaveChanges();              

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<AirlineScheduleDTO>(airlineSched);
        }
        public AirlineScheduleDTO GetAirlineSchedule(int id)
        {
            var obj = _commercialPlanRepo.GetAirlineSchedule(id);
            return _mapper.Map<AirlineScheduleDTO>(obj);
        }
        public IEnumerable<AirlineScheduleDTO> GetAllAirlineSchedule()
        {
            var obj = _commercialPlanRepo.GetAllAirlineSchedules();
            return _mapper.Map<IEnumerable<AirlineScheduleDTO>>(obj);
        }
       
        public void DeleteAirlineSchedule(int id)
        {
            var obj = _commercialPlanRepo.GetAirlineSchedule(id);
            if (obj == null)
                throw new appException("No Airline Schedule found.");

            obj.isDeleted = true;
                _commercialPlanRepo.UpdateAirlineSchedule(obj);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }
        public void PublishAirlineSchedule(AirlineScheduleDTO_verify obj)
        {
            var airlineSched = _commercialPlanRepo.GetAirlineSchedule(obj.Id);
            if (airlineSched == null)
                throw new appException("Airline Schedule does not exist.");
            try
            {
                airlineSched.UpdatedDate = DateTime.UtcNow;
                airlineSched.UpdatedBy = obj.UpdatedBy;
                airlineSched.isPublished = true;
                _commercialPlanRepo.UpdateAirlineSchedule(airlineSched);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void UnpublishAirlineSchedule(AirlineScheduleDTO_verify obj)
        {
            var airlineSched = _commercialPlanRepo.GetAirlineSchedule(obj.Id);
            if (airlineSched == null)
                throw new appException("Airline Schedule does not exist.");
            if (_flightSchedRepo.CheckFlightSched_Status(airlineSched.Id))
                throw new appException("Cannot Unpublish Schedule Assigned Flights.");
            try
            {
                //get # of flights assigned
                airlineSched.UpdatedDate = DateTime.UtcNow;
                airlineSched.UpdatedBy = obj.UpdatedBy;
                airlineSched.isPublished = false;
                _commercialPlanRepo.UpdateAirlineSchedule(airlineSched);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void UpdateAirlineSchedule(AirlineScheduleDTO_edit obj)
        {
            var airlineSched = _commercialPlanRepo.GetAirlineSchedule(obj.Id);
            if (airlineSched == null)
                throw new appException("Airline Schedule does not exist.");
            try
            {
                airlineSched.ScheduleName = obj.ScheduleName ?? airlineSched.ScheduleName;
                airlineSched.PeriodFrom = obj.PeriodFrom.ToUniversalTime();
                airlineSched.PeriodTo = obj.PeriodTo.ToUniversalTime();
                airlineSched.UpdatedDate = DateTime.UtcNow;
                airlineSched.UpdatedBy = obj.UpdatedBy;

            _commercialPlanRepo.UpdateAirlineSchedule(airlineSched);
           
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region Schedule_AircraftType
        public Schedule_AircraftTypeDTO CreateSchedule_AircraftType(Schedule_AircraftTypeDTO_edit obj)
        {
            var sched_at = _mapper.Map<Schedule_AircraftType>(obj);
            sched_at.CreatedDate = DateTime.UtcNow;
            sched_at.UpdatedDate = sched_at.CreatedDate;

            sched_at.isDeleted = false;
            _commercialPlanRepo.CreateSchedule_AircraftType(sched_at);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<Schedule_AircraftTypeDTO>(sched_at);
        }
        public Schedule_AircraftTypeDTO GetSchedule_AircraftType(int id)
        {
            var obj = _commercialPlanRepo.GetSchedule_AircraftType(id);
            return _mapper.Map<Schedule_AircraftTypeDTO>(obj);
        }
        public IEnumerable<Schedule_AircraftTypeDTO> GetAllSchedule_AircraftType()
        {
            var obj = _commercialPlanRepo.GetAllSchedule_AircraftType();
            return _mapper.Map<IEnumerable<Schedule_AircraftTypeDTO>>(obj);
        }
        public IEnumerable<Schedule_AircraftTypeDTO> GetAllSchedule_AircraftType_ByAirlineSched(int id)
        {
            var obj = _commercialPlanRepo.GetAllSchedule_AircraftType_ByAirlineSchedId(id);
            return _mapper.Map<IEnumerable<Schedule_AircraftTypeDTO>>(obj);
        }
        public void DeleteSchedule_AircraftType(int id)
        {
            var obj = _commercialPlanRepo.GetSchedule_AircraftType(id);
            if (obj == null)
                throw new appException("Aircraft Type does not exist.");

            obj.isDeleted = true;
                _commercialPlanRepo.UpdateSchedule_AircraftType(obj);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }
        public void UpdateSchedule_AircraftType(Schedule_AircraftTypeDTO_edit obj)
        {
            var sched_at = _commercialPlanRepo.GetSchedule_AircraftType(obj.Id);
            if (sched_at == null)
                throw new appException("No Schedule AircraftType found.");
            try
            {
                sched_at.Airline_ScheduleID = obj.Airline_ScheduleID > 0 ? obj.Airline_ScheduleID : sched_at.Airline_ScheduleID;
            sched_at.AircraftTypeId = obj.AircraftTypeId > 0 ? obj.AircraftTypeId : sched_at.AircraftTypeId;
            sched_at.Quantity = obj.Quantity >= 0 ? obj.Quantity : sched_at.Quantity;
            sched_at.isDeleted = obj.isDeleted;
            sched_at.UpdatedDate = DateTime.UtcNow;
            sched_at.UpdatedBy = obj.UpdatedBy;


            _commercialPlanRepo.UpdateSchedule_AircraftType(sched_at);
            
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
    }
}
