using AutoMapper;
using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using FlightOperations.Model.Enum;
using FlightOperations.Repository;
using FlightOperations.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Services
{
    public interface IaircraftServices
    {
        //aircraft
        AircraftTypeDTO CreateAircraftType(AircraftTypeDTO_Edit obj);
        void DeleteAircraftType(int id);
        AircraftTypeDTO GetAircraftType(int id);
        IEnumerable<AircraftTypeDTO> GetAllAircraftType();
        void UpdateAircraftType(AircraftTypeDTO_Edit obj);

        AircraftDTO CreateAircraft(AircraftDTO_edit obj);
        void DeleteAircraft(int id);
        AircraftDTO GetAircraft(int id);
        IEnumerable<AircraftDTO> GetAllAircraft();
        void UpdateAircraft(AircraftDTO_edit obj);

        //aircraft maintenance
        AircraftMaintenanceDTO CreateAircraftMaintenance(AircraftMaintenanceDTO_Edit obj);
        void DeleteAircraftMaintenance(int id);
        AircraftMaintenanceDTO GetAircraftMaintenance(int id);
        IEnumerable<AircraftMaintenanceDTO> GetAllAircraftMaintenance();
        void UpdateAircraftMaintenance(AircraftMaintenanceDTO_Edit obj);

        List<MaintenanceScheduleDTO_Return> CreateMaintenanceSchedule(MaintenanceScheduleDTO_Edit obj);
        void DeleteMaintenanceSchedule(int id);
        MaintenanceScheduleDTO GetMaintenanceSchedule(int id);
        IEnumerable<MaintenanceScheduleDTO> GetAllMaintenanceSchedule();
        IEnumerable<MaintenanceScheduleDTO_Return> GetAllMaintenanceScheduleCalendar(DateTime From, DateTime To);

        IEnumerable<MaintenanceScheduleDTO> GetAllMaintenanceSchedule_withDateRange(ReportFiltersDTO obj);
        MaintenanceScheduleDTO_Return UpdateMaintenanceSchedule(MaintenanceScheduleDTO_Edit obj);
        List<MaintenanceScheduleDTO_Return> UpdateMaintenanceSchedule_ByMany(MaintenanceScheduleDTO_Edit obj);
    }
    public class aircraftServices:IaircraftServices
    {
        private FlightOperationsContext _context;
        private IMapper _mapper;
        private aircraftRepository _aircraftRepo;

        public aircraftServices(FlightOperationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _aircraftRepo = new aircraftRepository(_context);
        }

        #region Aircraft Type
        public AircraftTypeDTO CreateAircraftType(AircraftTypeDTO_Edit obj)
        {
            var aircraftType = _mapper.Map<AircraftType>(obj);

            aircraftType.CreatedDate = DateTime.UtcNow;
            aircraftType.UpdatedDate = aircraftType.CreatedDate;
            aircraftType.isDeleted = false;
            _aircraftRepo.CreateAircraftType(aircraftType);

            try
            {
                _context.SaveChanges();
                return _mapper.Map<AircraftTypeDTO>(aircraftType);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }
        public void DeleteAircraftType(int id)
        {
            var aircraftType = _aircraftRepo.GetAircraftType(id);
            if(aircraftType == null)
                throw new appException("Aircraft Type does not exist.");
                aircraftType.isDeleted = true;
                _aircraftRepo.UpdateAircraftType(aircraftType);
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
        public AircraftTypeDTO GetAircraftType(int id)
        {
            var aircraftType = _aircraftRepo.GetAircraftType(id);
            return _mapper.Map<AircraftTypeDTO>(aircraftType);
        }
        public IEnumerable<AircraftTypeDTO> GetAllAircraftType()
        {
            var aircraftTypes = _aircraftRepo.GetAllAircraftTypes();

            var aircraftTypeDTO = _mapper.Map<IEnumerable<AircraftTypeDTO>>(aircraftTypes);
            foreach(var aircraftType in aircraftTypeDTO)
            {
                var aircrafts = _aircraftRepo.GetAllAircrafts_ByAircraftType(aircraftType.Id);
                var aircraftsDTO = _mapper.Map<IEnumerable<AircraftDTO>>(aircrafts);

                aircraftType.Aircrafts = aircraftsDTO.ToList();
                aircraftType.AircraftCount = aircraftsDTO.Count();
            }

            return aircraftTypeDTO;
        }
        public void UpdateAircraftType(AircraftTypeDTO_Edit obj)
        {
            var aircraftType = _aircraftRepo.GetAircraftType(obj.Id);
            if (aircraftType == null)
                throw new appException("Aircraft Type not found.");
            try
            {
                aircraftType.AircraftTypeName = obj.AircraftTypeName ?? aircraftType.AircraftTypeName;
                aircraftType.Make = obj.Make ?? aircraftType.AircraftTypeName;
                aircraftType.UpdatedDate = DateTime.UtcNow;
                aircraftType.UpdatedBy = obj.UpdatedBy;
                aircraftType.ACN = obj.ACN;
                aircraftType.CategoryNumber = obj.CategoryNumber;
                aircraftType.MaximumFlightHours = obj.MaximumFlightHours > 0 ? obj.MaximumFlightHours : aircraftType.MaximumFlightHours;

                _aircraftRepo.UpdateAircraftType(aircraftType);
           
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region Aircraft
        public AircraftDTO CreateAircraft(AircraftDTO_edit obj)
        {
            var aircraft = _mapper.Map<Aircraft>(obj);

            aircraft.CreatedDate = DateTime.UtcNow;
            aircraft.UpdatedDate = aircraft.CreatedDate;
            aircraft.isDeleted = false;
            _aircraftRepo.CreateAircraft(aircraft);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<AircraftDTO>(aircraft);
        }
        public void DeleteAircraft(int id)
        {
            var aircraft = _aircraftRepo.GetAircraft(id);
            if (aircraft == null)
                throw new appException("Airline Schedule does not exist.");
            aircraft.isDeleted = true;
                _aircraftRepo.UpdateAircraft(aircraft);
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
        public AircraftDTO GetAircraft(int id)
        {
            var aircraft = _aircraftRepo.GetAircraft(id);
            return _mapper.Map<AircraftDTO>(aircraft);
        }
        public IEnumerable<AircraftDTO> GetAllAircraft()
        {
            var aircraft = _aircraftRepo.GetAllAircrafts();
            return _mapper.Map<IEnumerable<AircraftDTO>>(aircraft);
        }
        public void UpdateAircraft(AircraftDTO_edit obj)
        {
            var aircraft = _aircraftRepo.GetAircraft(obj.Id);
            if (aircraft == null)
                throw new appException("No aircraft found.");
            try
            {
                aircraft.AircraftTypeId = obj.AircraftTypeId > 0 ? obj.AircraftTypeId:aircraft.AircraftTypeId;
            aircraft.FirstCapacity = obj.FirstCapacity >= 0 ? obj.FirstCapacity: aircraft.FirstCapacity;
            aircraft.BusinessCapacity = obj.BusinessCapacity >= 0 ? obj.BusinessCapacity : aircraft.BusinessCapacity;
            aircraft.PeconomyCapacity = obj.PeconomyCapacity >= 0 ? obj.PeconomyCapacity : aircraft.PeconomyCapacity;
            aircraft.EconomyCapacity = obj.EconomyCapacity >= 0 ? obj.EconomyCapacity : aircraft.EconomyCapacity;
            aircraft.CargoCapacity = obj.CargoCapacity >= 0 ? obj.CargoCapacity : aircraft.CargoCapacity;

            aircraft.Registration = obj.Registration ?? aircraft.Registration;
            aircraft.CountryOfRegistration = obj.CountryOfRegistration > 0 ? obj.CountryOfRegistration : aircraft.CountryOfRegistration;
            aircraft.DateOfRegistration = obj.DateOfRegistration;

            aircraft.UpdatedDate = DateTime.UtcNow;
            aircraft.UpdatedBy = obj.UpdatedBy;

            _aircraftRepo.UpdateAircraft(aircraft);
           
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region AircraftMaintenance
        public AircraftMaintenanceDTO CreateAircraftMaintenance(AircraftMaintenanceDTO_Edit obj)
        {
            var aircraftMaintenance = _mapper.Map<AircraftMaintenance>(obj);

            aircraftMaintenance.CreatedDate = DateTime.UtcNow;
            aircraftMaintenance.UpdatedDate = aircraftMaintenance.CreatedDate;
            aircraftMaintenance.isDeleted = false;
            _aircraftRepo.CreateAircraftMaintenance(aircraftMaintenance);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<AircraftMaintenanceDTO>(aircraftMaintenance);
        }
        public void DeleteAircraftMaintenance(int id)
        {
            var aircraftType = _aircraftRepo.GetAircraftType(id);
            if (aircraftType == null)
                throw new appException("Aircraft Maintenance not found.");
            aircraftType.isDeleted = true;
            _aircraftRepo.UpdateAircraftType(aircraftType);
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
        public AircraftMaintenanceDTO GetAircraftMaintenance(int id)
        {
            var aircraftMaintenance = _aircraftRepo.GetAircraftType(id);
            return _mapper.Map<AircraftMaintenanceDTO>(aircraftMaintenance);
        }
        public IEnumerable<AircraftMaintenanceDTO> GetAllAircraftMaintenance()
        {
            var aircraftMaintenance = _aircraftRepo.GetAllAircraftMaintenance();
            return _mapper.Map<IEnumerable<AircraftMaintenanceDTO>>(aircraftMaintenance);
        }
        public void UpdateAircraftMaintenance(AircraftMaintenanceDTO_Edit obj)
        {
            var aircraftMaintenance = _aircraftRepo.GetAircraftMaintenance(obj.Id);
            if (aircraftMaintenance == null)
                throw new appException("Aircraft Maintenance not found.");
            try
            {
                aircraftMaintenance.MaintenanceCode = obj.MaintenanceCode ?? aircraftMaintenance.MaintenanceCode;
                aircraftMaintenance.MaintenanceName = obj.MaintenanceName ?? aircraftMaintenance.MaintenanceName;
                aircraftMaintenance.Duration = obj.Duration >= 0 ? obj.Duration : aircraftMaintenance.Duration;
                aircraftMaintenance.AircraftTypeID = obj.AircraftTypeID >= 0 ? obj.AircraftTypeID : aircraftMaintenance.AircraftTypeID;
                aircraftMaintenance.Frequency = obj.Frequency;
                aircraftMaintenance.UpdatedDate = DateTime.UtcNow;
                aircraftMaintenance.UpdatedBy = obj.UpdatedBy;

                _aircraftRepo.UpdateAircraftMaintenance(aircraftMaintenance);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region Maintenance Schedule
        public List<MaintenanceScheduleDTO_Return> CreateMaintenanceSchedule(MaintenanceScheduleDTO_Edit obj)
        {
            var DateCreated = DateTime.UtcNow;

            var aircraftMaintenance = _aircraftRepo.GetAircraftMaintenance(obj.AircraftMaintenanceID);
            if (aircraftMaintenance == null) throw new appException("Aircraft Maintenance not found.");
            var aircraft = _aircraftRepo.GetAircraft(obj.AircraftID);
            if (aircraft == null) throw new appException("Aircraft not found.");
            var resourceID = obj.AircraftID.ToString();
            List<MaintenanceScheduleDTO_Return> maintenanceSchedules = new List<MaintenanceScheduleDTO_Return>();
            MaintenanceSchedule maintenanceSched = new MaintenanceSchedule();
            if (aircraft.AircraftTypeId == aircraftMaintenance.AircraftTypeID)
            {
                var Frequency = aircraftMaintenance.Frequency;
                

                var x = obj.scheduleFrom;
                while (x <= obj.scheduleTo)
                {
                    maintenanceSched = new MaintenanceSchedule();
                    var StartTime = obj.StartTime.ToUniversalTime();
                    maintenanceSched.StartTime = StartTime;
                    maintenanceSched.EndTime = StartTime.AddMinutes(aircraftMaintenance.Duration);

                    maintenanceSched.AircraftMaintenance = aircraftMaintenance;
                    maintenanceSched.Aircraft = aircraft;

                    maintenanceSched.scheduleFrom = obj.scheduleFrom.ToUniversalTime();
                    maintenanceSched.scheduleTo = obj.scheduleTo.ToUniversalTime();
                    maintenanceSched.ResourceID = resourceID;
                    maintenanceSched.Duration = aircraftMaintenance.Duration;
                    maintenanceSched.MaintenanceDate = x.ToUniversalTime();

                    maintenanceSched.CreatedBy = obj.CreatedBy;
                    maintenanceSched.UpdatedBy = obj.UpdatedBy;
                    maintenanceSched.CreatedDate = DateCreated;
                    maintenanceSched.UpdatedDate = maintenanceSched.CreatedDate;
                    maintenanceSched.isDeleted = false;

                    switch (Frequency)
                    {
                        case MaintenanceFrequencyEnum.OneTime:
                            x = obj.scheduleTo.AddDays(1);                break;
                        case MaintenanceFrequencyEnum.Daily:
                            x = x.AddDays(1);                            break;
                        case MaintenanceFrequencyEnum.Weekly:
                            x = x.AddDays(7);                            break;
                        case MaintenanceFrequencyEnum.BiMonthly:
                            x = x.AddDays(14);                            break;
                        case MaintenanceFrequencyEnum.Monthly:
                            x = x.AddMonths(1);                            break;
                        case MaintenanceFrequencyEnum.Quarterly:
                            x = x.AddMonths(3);                            break;
                        case MaintenanceFrequencyEnum.SemiAnnual:
                            x = x.AddMonths(6);                            break;
                        case MaintenanceFrequencyEnum.Annual:
                            x = x.AddYears(1);                            break;
                        default: throw new Exception("Invalid Frequency.");
                    }

                    var Id = _aircraftRepo.CreateMaintenanceSchedule(maintenanceSched);
                    _context.SaveChanges();
                    MaintenanceScheduleDTO_Return newMaintenanceSched = new MaintenanceScheduleDTO_Return();
                    newMaintenanceSched.Id = Id;

                    newMaintenanceSched.Aircraft = _mapper.Map<AircraftDTO>(aircraft);
                    newMaintenanceSched.MaintenanceDetails = _mapper.Map<AircraftMaintenanceDTO>(aircraftMaintenance);

                    newMaintenanceSched.resourceId = resourceID;
                    newMaintenanceSched.start = maintenanceSched.StartTime;
                    newMaintenanceSched.end = maintenanceSched.EndTime;
                    newMaintenanceSched.Title = maintenanceSched.AircraftMaintenance.MaintenanceCode + " - " + maintenanceSched.Aircraft.Registration;
                    maintenanceSchedules.Add(newMaintenanceSched);
                }

            }
            else
            {
                throw new Exception("Aircraft is not Allowed for this Maintenance");
            }


            try
            {
                _context.SaveChanges();
                return maintenanceSchedules;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void DeleteMaintenanceSchedule(int id)
        {
            var maintenanceSched = _aircraftRepo.GetMaintenanceSchedule(id);
            if (maintenanceSched == null)
                throw new appException("Maintenance Schedule not found.");
            maintenanceSched.isDeleted = true;
            _aircraftRepo.UpdateMaintenanceSchedule(maintenanceSched);
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
        public MaintenanceScheduleDTO GetMaintenanceSchedule(int id)
        {
            var maintenanceSched = _aircraftRepo.GetMaintenanceSchedule(id);
            return _mapper.Map<MaintenanceScheduleDTO>(maintenanceSched);
        }
        public IEnumerable<MaintenanceScheduleDTO> GetAllMaintenanceSchedule()
        {
            var maintenanceSched = _aircraftRepo.GetAllMaintenanceSchedule();
            return _mapper.Map<IEnumerable<MaintenanceScheduleDTO>>(maintenanceSched);
        }

        public IEnumerable<MaintenanceScheduleDTO_Return> GetAllMaintenanceScheduleCalendar(DateTime From, DateTime To)
        {
            var maintenanceSched = _aircraftRepo.GetAllMaintenanceSchedule(From.ToUniversalTime(), To.ToUniversalTime());
            var calendar = new List<MaintenanceScheduleDTO_Return>();

            foreach(var maintain in maintenanceSched)
            {
                var sched = new MaintenanceScheduleDTO_Return();

                sched.Aircraft = _mapper.Map<AircraftDTO>(maintain.Aircraft);
                sched.Id = maintain.Id;
                sched.resourceId = maintain.AircraftID.ToString();
                sched.MaintenanceDetails = _mapper.Map<AircraftMaintenanceDTO>(maintain.AircraftMaintenance);
                sched.Title = maintain.Aircraft.AircraftType.AircraftTypeName + ":" + maintain.AircraftMaintenance.MaintenanceCode;
                sched.start = new DateTime(maintain.MaintenanceDate.Year, maintain.MaintenanceDate.Month, maintain.MaintenanceDate.Day, maintain.StartTime.Hour, maintain.StartTime.Minute, 0);
                sched.end = new DateTime(maintain.MaintenanceDate.Year, maintain.MaintenanceDate.Month, maintain.MaintenanceDate.Day, maintain.EndTime.Hour, maintain.EndTime.Minute, 0);

                calendar.Add(sched);
            }
            return calendar;
        }
        public IEnumerable<MaintenanceScheduleDTO> GetAllMaintenanceSchedule_withDateRange(ReportFiltersDTO obj)
        {
            var maintenanceSched = _aircraftRepo.GetAllMaintenanceSchedule_withDateRange(obj.DateFrom.ToUniversalTime(),obj.DateTo.ToUniversalTime());
            return _mapper.Map<IEnumerable<MaintenanceScheduleDTO>>(maintenanceSched);
        }
        public MaintenanceScheduleDTO_Return UpdateMaintenanceSchedule(MaintenanceScheduleDTO_Edit obj) // individual
        {
            var maintenanceSched = _aircraftRepo.GetMaintenanceSchedule(obj.Id);
            if (maintenanceSched == null)
                throw new appException("Maintenance Schedule not found.");
            try
            {
                maintenanceSched.AircraftMaintenanceID = obj.AircraftMaintenanceID > 0 ? obj.AircraftMaintenanceID : maintenanceSched.AircraftMaintenanceID;
                var aircraftMaintenance = maintenanceSched.AircraftMaintenance;
                var aircraft = _aircraftRepo.GetAircraft(obj.AircraftID);

                maintenanceSched.AircraftID = obj.AircraftID > 0 ? obj.AircraftID : maintenanceSched.AircraftID;

                maintenanceSched.Duration = aircraftMaintenance.Duration ;
                var StartTime = obj.StartTime.ToUniversalTime();
                maintenanceSched.StartTime = StartTime;
                maintenanceSched.EndTime = StartTime.AddMinutes(maintenanceSched.Duration);
              
                maintenanceSched.UpdatedDate = DateTime.UtcNow;
                maintenanceSched.UpdatedBy = obj.UpdatedBy;

                _aircraftRepo.UpdateMaintenanceSchedule(maintenanceSched);

                _context.SaveChanges();

                MaintenanceScheduleDTO_Return newMaintenanceSched = new MaintenanceScheduleDTO_Return();

                newMaintenanceSched.Id = obj.Id;
                newMaintenanceSched.resourceId = obj.ResourceID;
                newMaintenanceSched.start = maintenanceSched.StartTime;
                newMaintenanceSched.end = maintenanceSched.EndTime;

                newMaintenanceSched.Aircraft = _mapper.Map<AircraftDTO>(aircraft);
                newMaintenanceSched.MaintenanceDetails = _mapper.Map<AircraftMaintenanceDTO>(aircraftMaintenance);

                newMaintenanceSched.Title = maintenanceSched.AircraftMaintenance.MaintenanceCode + " - " + maintenanceSched.Aircraft.Registration;

                return newMaintenanceSched;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public List<MaintenanceScheduleDTO_Return> UpdateMaintenanceSchedule_ByMany(MaintenanceScheduleDTO_Edit obj)  //set 
        {
            var maintenanceSchedules = _aircraftRepo.GetAllMaintenanceSchedule_byResourceId(obj.ResourceID);
            if (maintenanceSchedules == null)
                throw new appException("Maintenance Schedule not found.");

            try { 

            foreach(var maintenanceSched in maintenanceSchedules)
            {
                if(maintenanceSched.MaintenanceDate.ToUniversalTime() >= DateTime.UtcNow)
                maintenanceSched.isDeleted = true;
                maintenanceSched.UpdatedDate = DateTime.UtcNow;
                maintenanceSched.UpdatedBy = obj.UpdatedBy;

                _aircraftRepo.UpdateMaintenanceSchedule(maintenanceSched);
            }
                _context.SaveChanges();
                var result = CreateMaintenanceSchedule(obj);

                return result;
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
