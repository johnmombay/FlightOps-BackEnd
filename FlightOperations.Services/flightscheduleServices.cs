using AutoMapper;
using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using FlightOperations.Model.Enum;
using FlightOperations.Repository;
using FlightOperations.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Services
{
    public interface IflightscheduleServices
    {
        AirportCategoryDTO CreateAirportCategory(AirportCategoryDTO obj);
        void DeleteAirportCategory(int id);
        AirportCategoryDTO GetAirportCategory(int id);
        IEnumerable<AirportCategoryDTO> GetAllAirportCategory();
        void UpdateAirportCategory(AirportCategoryDTO obj);

        AirportDTO CreateAirport(AirportDTO_edit obj);
        void DeleteAirport(int id);
        AirportDTO GetAirport(int id);
        IEnumerable<AirportDTO> GetAllAirport();
        void UpdateAirport(AirportDTO_edit obj);
        void CancelFlightSchedule(int id);

        NumberOfFlightsDTO NumberOfFlights(NumberOfFlightsDTO obj);

        /*
        RouteDTO CreateRoute(RouteDTO_Edit obj);
        void DeleteRoute(int id);
        RouteDTO GetRoute(int id);
        IEnumerable<RouteDTO> GetAllRoute();
        void UpdateRoute(RouteDTO_Edit obj);*/

        IEnumerable<FlightScheduleDTO_Return> CreateFlightSchedule(FlightScheduleDTO obj);
        void DeleteFlightSchedule(int id);
        FlightScheduleDTO GetFlightSchedule(int id);
        IEnumerable<FlightScheduleDTO> GetAllFlightSchedule();
        IEnumerable<FlightScheduleDTO_Return> GetAllFlightSchedule_byAirlineSchedID(int id);
        IEnumerable<FlightScheduleDTO_Return> GetAllPublishedFlightSchedule(DateTime From, DateTime To);
        IEnumerable<FlightScheduleDTO_Return> GetAllFlightScheduleOrderByFlightDate_withDateRange(ReportFiltersDTO obj);
        IEnumerable<FlightScheduleDTO_Return> GetAllFlightScheduleOrderByFlightDate();
        IEnumerable<FlightScheduleDTO_Return> UpdateFlightSchedule(FlightScheduleDTO obj); 


    }
    public class flightscheduleServices:IflightscheduleServices
    {
        private FlightOperationsContext _context;
        private IMapper _mapper;
        private flightscheduleRepository _flightschedRepo;
        private crewPlanningRepository _crewPlanningRepo;
        private aircraftRepository _aircraftRepo;
        private flightOperationsRepository _flightOpsRepo;
        public flightscheduleServices(FlightOperationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _flightschedRepo = new flightscheduleRepository(_context);
            _crewPlanningRepo = new crewPlanningRepository(_context);
            _aircraftRepo = new aircraftRepository(_context);
            _flightOpsRepo = new flightOperationsRepository(_context);
        }
        #region Airport Category
        public AirportCategoryDTO CreateAirportCategory(AirportCategoryDTO obj)
        {
            var airportCat = _mapper.Map<AirportCategory>(obj);

            airportCat.CreatedDate = DateTime.UtcNow;
            airportCat.UpdatedDate = airportCat.CreatedDate;

            airportCat.isDeleted = false;

            _flightschedRepo.CreateAirportCategory(airportCat);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<AirportCategoryDTO>(airportCat);
        }
        public void DeleteAirportCategory(int id) {
            var airportCat = _flightschedRepo.GetAirportCategory(id);
            if(airportCat == null)
                throw new appException("Airport Category does not exist.");

            airportCat.isDeleted = true;
                _flightschedRepo.UpdateAirportCategory(airportCat);
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
        public AirportCategoryDTO GetAirportCategory(int id)
        {
            var airportCat = _flightschedRepo.GetAirportCategory(id);
            return _mapper.Map<AirportCategoryDTO>(airportCat);
        }
        public IEnumerable<AirportCategoryDTO> GetAllAirportCategory()
        {
            var airportCat = _flightschedRepo.GetAllAirportCategories();
            return _mapper.Map<IEnumerable<AirportCategoryDTO>>(airportCat);
        }
        public void UpdateAirportCategory(AirportCategoryDTO obj)
        {
            var airportCat = _flightschedRepo.GetAirportCategory(obj.Id);
            if (airportCat == null)
                throw new appException("Airport Category does not exist.");
            try
            {
                airportCat.CategoryName = obj.CategoryName ?? airportCat.CategoryName;
            airportCat.CategoryNumber = obj.CategoryNumber > 0 ?obj.CategoryNumber : airportCat.CategoryNumber;

            airportCat.UpdatedDate = DateTime.UtcNow;
            airportCat.UpdatedBy = obj.UpdatedBy;

            _flightschedRepo.UpdateAirportCategory(airportCat);
           
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }
        #endregion
        #region Airport
        public AirportDTO CreateAirport(AirportDTO_edit obj)
        {
            var airport = _mapper.Map<Airport>(obj);

            airport.CreatedDate = DateTime.Now;
            airport.UpdatedDate = airport.CreatedDate;
            airport.isDeleted = false;
            _flightschedRepo.CreateAirport(airport);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<AirportDTO>(airport);
        }
        public void DeleteAirport(int id)
        {
            var airport = _flightschedRepo.GetAirport(id);
            if (airport == null)
                throw new appException("Airport does not exist.");

            airport.isDeleted = true;
                _flightschedRepo.UpdateAirport(airport);
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
        public AirportDTO GetAirport(int id)
        {
            var airport = _flightschedRepo.GetAirport(id);
            return _mapper.Map<AirportDTO>(airport);
        }
        public IEnumerable<AirportDTO> GetAllAirport()
        {
            var airport = _flightschedRepo.GetAllAirports();
            return _mapper.Map<IEnumerable<AirportDTO>>(airport);
        }
        public void UpdateAirport(AirportDTO_edit obj)
        {
            var airport = _flightschedRepo.GetAirport(obj.Id);
            if (airport == null)
                throw new appException("Airport does not exist.");
            try
            {
                airport.AirportName = obj.AirportName ?? airport.AirportName;
                airport.ICAO_Code = obj.ICAO_Code ?? airport.ICAO_Code;
                airport.IATA_Code = obj.IATA_Code ?? airport.IATA_Code;
                airport.CityId = obj.CityId > 0 ? obj.CityId : airport.CityId;
                airport.Address = obj.Address ?? airport.Address;
                airport.AirportCategory = obj.AirportCategory > 0 ? obj.AirportCategory : airport.AirportCategory;

                airport.Latitude = obj.Latitude;
                airport.Longitude = obj.Longitude;

                airport.OperationFrom = obj.OperationFrom;
                airport.OperationTo = obj.OperationTo;
                airport.PCN = obj.PCN ?? airport.PCN;
            
            airport.UpdatedDate = DateTime.Now;
            airport.UpdatedBy = obj.UpdatedBy;

            _flightschedRepo.UpdateAirport(airport);

            
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        /*
        #region Route
        
        public RouteDTO CreateRoute(RouteDTO_Edit obj)
        {
            var route = _mapper.Map<Route>(obj);

            route.CreatedDate = DateTime.Now;
            route.UpdatedDate = route.CreatedDate;
            route.isDeleted = false;
            _flightschedRepo.CreateRoute(route);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<RouteDTO>(route);
        }
        public void DeleteRoute(int id)
        {
            var route = _flightschedRepo.GetRoute(id);
            if (route != null)
            {
                route.isDeleted = true;
                _flightschedRepo.UpdateRoute(route);
                _context.SaveChanges();
            }

        }
        public RouteDTO GetRoute(int id)
        {
            var route = _flightschedRepo.GetRoute(id);
            return _mapper.Map<RouteDTO>(route);
        }
        public IEnumerable<RouteDTO> GetAllRoute()
        {
            var route = _flightschedRepo.GetAllRoutes();
            return _mapper.Map<IEnumerable<RouteDTO>>(route);
        }
        public void UpdateRoute(RouteDTO_Edit obj)
        {
            var route = _flightschedRepo.GetRoute(obj.Id);
            if (route == null)
                throw new appException("No route found.");
            route.Origin = obj.Origin > 0 ? obj.Origin : route.Origin;
            route.Destination = obj.Destination > 0 ? obj.Destination : route.Destination;
            route.TripHours = obj.TripHours > 0 ? obj.TripHours : route.TripHours;
            route.FlightHours = obj.FlightHours > 0 ? obj.FlightHours : route.FlightHours;

            route.UpdatedDate = DateTime.Now;
            route.UpdatedBy = obj.UpdatedBy;

            _flightschedRepo.UpdateRoute(route);
            _context.SaveChanges();
        }
        #endregion */
        #region Flight Schedule
        public IEnumerable<FlightScheduleDTO_Return> CreateFlightSchedule(FlightScheduleDTO obj)
        {
            try
            {

                List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();
                var DateCreated = DateTime.UtcNow;

                var PeriodFrom = obj.PeriodFrom.ToUniversalTime();
                var PeriodTo = obj.PeriodTo.ToUniversalTime();

                var Origin_Airport = _flightschedRepo.GetAirport(obj.Airport_OriginID);
                if (Origin_Airport == null)
                    throw new appException("Origin Airport does not exist.");
                var Destination_Airport = _flightschedRepo.GetAirport(obj.Airport_DestinationID);
                if (Destination_Airport == null)
                    throw new appException("Destination Airport does not exist.");
                var daysDuration = (PeriodTo.Date - PeriodFrom.Date).TotalDays;
                var flightDate = PeriodFrom;


            for(var x = PeriodFrom.Date; x <= PeriodTo.Date; x = x.AddDays(1))
            {
                var flightsched = _mapper.Map<FlightSchedule>(obj);

                flightsched.CreatedDate = DateCreated;
                flightsched.UpdatedDate = flightsched.CreatedDate;
                flightsched.isDeleted = false;
                    flightsched.Status = FlightStatusEnum.Planned;   
                flightDate = x;
                
                var z = Convert.ToString((int)flightDate.DayOfWeek);
                if (flightsched.Days.Contains(z)) {

                    flightsched.FlightDate = flightDate.Date;
                    flightsched.FlightNo = obj.OutboundFlightNo;                   

                    flightsched.STD = new DateTime(flightDate.Year, flightDate.Month, flightDate.Day, obj.STD.Hour, obj.STD.Minute, 0).ToUniversalTime();
                        if (flightsched.STD < Origin_Airport.OperationFrom && flightsched.STD > Origin_Airport.OperationTo)
                            throw new appException("Flight Schedule Departure Time not within Origin Airport Operation Time.");
                    flightsched.STA = flightsched.STD.AddMinutes(obj.BlockTime);
                        if (flightsched.STA < Destination_Airport.OperationFrom && flightsched.STA > Destination_Airport.OperationTo)
                            throw new appException("Flight Schedule Arrival Time not within Destination Airport Operation Time.");
                        var res = _flightschedRepo.CreateFlightSchedule(flightsched);
                    _context.SaveChanges();

                    FlightScheduleDTO_Return NewflightSchedDTO = new FlightScheduleDTO_Return();
                    NewflightSchedDTO.FlightDetails = _mapper.Map<FlightScheduleDTO>(flightsched);
                    NewflightSchedDTO.Id = res.Id.ToString();
                    NewflightSchedDTO.start = flightsched.STD;
                    NewflightSchedDTO.end = flightsched.STA;
                    NewflightSchedDTO.resourceId = flightsched.resourceId;
                    NewflightSchedDTO.Status = flightsched.Status;
                    NewflightSchedDTO.Title = flightsched.OutboundFlightNo + ": " + Origin_Airport.City.CityCode + " - " + Destination_Airport.City.CityCode;

                    list_FlightSchedules.Add(NewflightSchedDTO);
                    if (flightsched.isReturn)
                    {
                        // new return flight schedule
                        var returnFlightSched = new FlightSchedule();//fe
                        returnFlightSched.FlightNo = obj.InboundFlightNo;

                        returnFlightSched.STD = flightsched.STA.AddMinutes(Destination_Airport.StandardGroundTime);
                            if (returnFlightSched.STD < Destination_Airport.OperationFrom && returnFlightSched.STD > Destination_Airport.OperationTo)
                                throw new appException("Return Flight Schedule Departure Time not within Origin Airport Operation Time.");
                            returnFlightSched.FlightDate = returnFlightSched.STD.Date;
                        returnFlightSched.STA = returnFlightSched.STD.AddMinutes(obj.BlockTime);
                            if (returnFlightSched.STA < Destination_Airport.OperationFrom && returnFlightSched.STA > Destination_Airport.OperationTo)
                                throw new appException("Return Flight Schedule Arrival Time not within Destination Airport Operation Time.");
                            returnFlightSched.isReturn = true;
                        returnFlightSched.AircraftTypeID = flightsched.AircraftTypeID;
                        returnFlightSched.resourceId = flightsched.resourceId;
                        returnFlightSched.BlockTime = obj.BlockTime;
                        returnFlightSched.FlyingHours = obj.FlyingHours;
                        returnFlightSched.Status = FlightStatusEnum.Planned;

                        returnFlightSched.AirlineScheduleID = flightsched.AirlineScheduleID;
                        returnFlightSched.Airport_DestinationID = flightsched.Airport_OriginID;
                        returnFlightSched.Airport_OriginID = flightsched.Airport_DestinationID;

                        returnFlightSched.Days = flightsched.Days;

                        returnFlightSched.PeriodFrom = flightsched.PeriodFrom;
                        returnFlightSched.PeriodTo = flightsched.PeriodTo;

                        returnFlightSched.CreatedBy = flightsched.CreatedBy;
                        returnFlightSched.UpdatedBy = flightsched.UpdatedBy;
                        returnFlightSched.CreatedDate = flightsched.CreatedDate;
                        returnFlightSched.UpdatedDate = flightsched.CreatedDate;

                        returnFlightSched.InboundFlightNo = obj.InboundFlightNo;
                        returnFlightSched.OutboundFlightNo = obj.OutboundFlightNo;

                        var resRet = _flightschedRepo.CreateFlightSchedule(returnFlightSched);
                        _context.SaveChanges();

                        FlightScheduleDTO_Return NewflightSchedDTO_R = new FlightScheduleDTO_Return();
                        NewflightSchedDTO_R.Id = resRet.Id.ToString();
                        NewflightSchedDTO_R.FlightDetails = _mapper.Map<FlightScheduleDTO>(returnFlightSched);
                        NewflightSchedDTO_R.start = returnFlightSched.STD;
                        NewflightSchedDTO_R.end = returnFlightSched.STA;
                        NewflightSchedDTO_R.resourceId = returnFlightSched.resourceId;
                        NewflightSchedDTO_R.Status = returnFlightSched.Status;
                        NewflightSchedDTO_R.Title = returnFlightSched.InboundFlightNo + ": " + Destination_Airport.City.CityCode + " - " + Origin_Airport.City.CityCode;
                        list_FlightSchedules.Add(NewflightSchedDTO_R);
                    }

                }
                          
            }
                return list_FlightSchedules;
            }
            catch (appException ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public IEnumerable<FlightScheduleDTO_Return> GetAllPublishedFlightSchedule(DateTime From, DateTime To)
        {
            var res = _flightschedRepo.GetAllPublishedFlightSchedules(From.ToUniversalTime(),To.ToUniversalTime());
            if (res == null)
                throw new appException("No Published Flight Schedules.");
            try { 
            List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();
            foreach (var sched in res)
            {
                FlightScheduleDTO_Return AircraftSchedDTOs = new FlightScheduleDTO_Return();
                AircraftSchedDTOs.Id = sched.Id.ToString();
                AircraftSchedDTOs.start = sched.STD;
                AircraftSchedDTOs.end = sched.STA;
                AircraftSchedDTOs.resourceId = sched.resourceId;
                AircraftSchedDTOs.Status = sched.Status;
                AircraftSchedDTOs.Crews = _mapper.Map<IEnumerable<CrewDTO>>(_crewPlanningRepo.GetAllCrew_byFlightSched(sched.Id));
                AircraftSchedDTOs.FlightDetails = _mapper.Map<FlightScheduleDTO>(sched);
                var aircraftSched = _mapper.Map<AircraftScheduleDTO>(_flightOpsRepo.GetAircraftSchedule_byFlightIdSchedule(sched.Id));
                AircraftSchedDTOs.Aircraft = aircraftSched!= null? aircraftSched.Aircraft : null;

                AircraftSchedDTOs.Title = sched.FlightNo + ": " + sched.Airport_Origin.IATA_Code + " - " + sched.Airport_Destination.IATA_Code;
                list_FlightSchedules.Add(AircraftSchedDTOs);
            }
            return list_FlightSchedules;
            }
            catch (appException ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void CancelFlightSchedule(int id)
        {
            var flightsched = _flightschedRepo.GetFlightSchedule(id);
            if (flightsched == null)
                throw new appException("Flight Schedule does not exist.");
            if (flightsched.Status == FlightStatusEnum.Cancelled)
                throw new appException("Flight Schedule is already canceled");

            flightsched.Status = FlightStatusEnum.Cancelled;
            _flightschedRepo.UpdateFlightSchedule(flightsched);
            try
            {
                _context.SaveChanges();
            }
            catch (appException ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }
        public void DeleteFlightSchedule(int id)
        {
            var flightsched = _flightschedRepo.GetFlightSchedule(id);
            if (flightsched == null)
                throw new appException("Flight Schedule does not exist.");

            flightsched.isDeleted = true;
                _flightschedRepo.UpdateFlightSchedule(flightsched);
                try
                {
                    _context.SaveChanges();
                }
                catch (appException ex)
                {
                    string message = ex.Message;
                    throw ex;
                }
            

        }
        public FlightScheduleDTO GetFlightSchedule(int id)
        {
            var flightsched = _flightschedRepo.GetFlightSchedule(id);
            return _mapper.Map<FlightScheduleDTO>(flightsched);
        }
        public IEnumerable<FlightScheduleDTO> GetAllFlightSchedule()
        {
            var flightsched = _flightschedRepo.GetAllFlightSchedules();
            return _mapper.Map<IEnumerable<FlightScheduleDTO>>(flightsched);
        }
        public IEnumerable<FlightScheduleDTO_Return> GetAllFlightSchedule_byAirlineSchedID(int id)
        {
            var flightsched = _flightschedRepo.GetAllFlightSchedules_byAirlineSchedID(id);
            if (flightsched == null)
                throw new appException("No Flight Schedules by this Airline Schedule.");
            List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();
           
            foreach(var sched in flightsched)
            {
                FlightScheduleDTO_Return fs_return = ToFlightScheduleDTO_return(sched);

                list_FlightSchedules.Add(fs_return);
            }

            return list_FlightSchedules;
        }
        public IEnumerable<FlightScheduleDTO_Return> GetAllFlightScheduleOrderByFlightDate()
        {
            var flightsched = _flightschedRepo.GetAllFlightSchedules_report();
            if (flightsched == null)
                throw new appException("No Flight Schedules by this Airline Schedule.");
            List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();

            foreach (var sched in flightsched)
            {
                FlightScheduleDTO_Return fs_return = ToFlightScheduleDTO_return(sched);

                list_FlightSchedules.Add(fs_return);
            }

            return list_FlightSchedules;
        }
        public IEnumerable<FlightScheduleDTO_Return> GetAllFlightScheduleOrderByFlightDate_withDateRange(ReportFiltersDTO obj)
        {
            var flightsched = _flightschedRepo.GetAllFlightSchedules_report_withDateRange(obj.DateFrom.ToUniversalTime(),obj.DateTo.ToUniversalTime());
            if (flightsched == null)
                throw new appException("No Flight Schedules by this Airline Schedule.");
            List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();

            foreach (var sched in flightsched)
            {
                FlightScheduleDTO_Return fs_return = ToFlightScheduleDTO_return(sched);

                list_FlightSchedules.Add(fs_return);
            }

            return list_FlightSchedules;
        }
        public IEnumerable<FlightScheduleDTO_Return> UpdateFlightSchedule(FlightScheduleDTO obj)
        {
            var flightschedules = _flightschedRepo.GetAllFlightSchedules_byResourceID(obj);
            if (flightschedules == null)
                throw new appException("No flight schedule found.");
            try
            {
                //Add VALIDATION
                //clear all existing
                foreach (var fs in flightschedules)
                {
                    DeleteFlightSchedule(fs.Id);
                }

                var result = CreateFlightSchedule(obj);
                return result;
            }
            catch (appException ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public NumberOfFlightsDTO NumberOfFlights(NumberOfFlightsDTO obj)
        {
            List<AircraftSchedule> res = _flightschedRepo.NumberOfFlights(obj.DateRequested);
            NumberOfFlightsDTO NumOfFlights = new NumberOfFlightsDTO();
            NumOfFlights.DateRequested = obj.DateRequested;
            int aircraftId = 0;
            foreach (var sched in res)
            {
                NumOfFlights.TotalAdultPAX += sched.AdultPAX;
                NumOfFlights.TotalChildPAX += sched.ChildPAX;
                NumOfFlights.TotalCargo += sched.Cargo;
                if (aircraftId != sched.AircraftID)
                {

                    NumOfFlights.NumberOfAircraft += 1;
                }
                NumOfFlights.NumOfFlights += 1;

                aircraftId = sched.AircraftID;
            }
            return NumOfFlights;
        }
        #endregion

        #region FORMAT to flightscheduleDTO_return
        public FlightScheduleDTO_Return ToFlightScheduleDTO_return(FlightSchedule sched)
        {
            FlightScheduleDTO_Return fs_return = new FlightScheduleDTO_Return();
            fs_return.Id = sched.Id.ToString();
            fs_return.start = sched.STD;
            fs_return.end = sched.STA;
            fs_return.resourceId = sched.resourceId;
            fs_return.Status = sched.Status;
            fs_return.FlightStatus = sched.Status.ToString();
            fs_return.Crews = _mapper.Map<IEnumerable<CrewDTO>>(_crewPlanningRepo.GetAllCrew_byFlightSched(sched.Id));
            fs_return.FlightDetails = _mapper.Map<FlightScheduleDTO>(sched);
            var aircraftSched = _mapper.Map<AircraftScheduleDTO>(_flightOpsRepo.GetAircraftSchedule_byFlightIdSchedule(sched.Id));
            fs_return.Aircraft = aircraftSched != null ? aircraftSched.Aircraft : null;
            fs_return.AircraftSchedule = aircraftSched;
            fs_return.Title = sched.FlightNo + ": " + sched.Airport_Origin.IATA_Code + " - " + sched.Airport_Destination.IATA_Code;
            return fs_return;
        }
        #endregion
    }
}
