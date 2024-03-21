using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using FlightOperations.Model.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface IflightscheduleRepository
    {
        void CreateAirportCategory(AirportCategory obj);
        void DeleteAirportCategory(AirportCategory obj);
        IEnumerable<AirportCategory> GetAllAirportCategories();
        AirportCategory GetAirportCategory(int id);
        void UpdateAirportCategory(AirportCategory obj);

        void CreateAirport(Airport obj);
        void DeleteAirport(Airport obj);
        IEnumerable<Airport> GetAllAirports();
        Airport GetAirport(int id);
        void UpdateAirport(Airport obj);

        void CreateRoute(Route obj);
        void DeleteRoute(Route obj);
        IEnumerable<Route> GetAllRoutes();
        Route GetRoute(int id);
        void UpdateRoute(Route obj);

        FlightSchedule CreateFlightSchedule(FlightSchedule obj);
        void DeleteFlightSchedule(FlightSchedule obj);
        IEnumerable<FlightSchedule> GetAllFlightSchedules();
        IEnumerable<FlightSchedule> GetAllFlightSchedules_byAirlineSchedID(int id);
        IEnumerable<FlightSchedule> GetAllFlightSchedules_byResourceID(AssignAircraftSchedDTO obj);
        IEnumerable<FlightSchedule> GetAllFlightSchedules_byResourceID(FlightScheduleDTO obj);
        IEnumerable<FlightSchedule> GetAllFlightSchedules_byResourceID(int AirlineScheduleID, int ResourceID);
        IEnumerable<FlightSchedule> GetAllPublishedFlightSchedules(DateTime From, DateTime To);
        IEnumerable<FlightSchedule> GetAllFlightSchedules_report_withDateRange(DateTime DateFrom, DateTime DateTo);
        IEnumerable<FlightSchedule> GetAllFlightSchedules_report();
        bool CheckFlightSched_Status(int id);
        FlightSchedule GetFlightSchedule(int id);
        void UpdateFlightSchedule(FlightSchedule obj);
        List<AircraftSchedule> NumberOfFlights(DateTime dateTime);
        List<AircraftSchedule> NumberOfAircraft(DateTime dateTime);
    }

    public class flightscheduleRepository:IflightscheduleRepository
    {
        FlightOperationsContext _context;
        public flightscheduleRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }
        #region Airport Category
        public void CreateAirportCategory(AirportCategory obj)
        {
            _context.AirportCategories.Add(obj);
        }
        public void DeleteAirportCategory(AirportCategory obj)
        {
            _context.AirportCategories.Remove(obj);
        }
        public IEnumerable<AirportCategory> GetAllAirportCategories()
        {
            var x = _context.AirportCategories
                .Where(p => p.isDeleted == false);
            return x;
        }
        public AirportCategory GetAirportCategory(int id)
        {
            var x = _context.AirportCategories
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateAirportCategory(AirportCategory obj)
        {
            _context.AirportCategories.Update(obj);
        }
        #endregion

        #region Airport
        public void CreateAirport(Airport obj)
        {
            _context.Airports.Add(obj);
        }
        public void DeleteAirport(Airport obj)
        {
            _context.Airports.Remove(obj);
        }
        public IEnumerable<Airport> GetAllAirports()
        {
            var x = _context.Airports
                .Include(c => c.City)
                .ThenInclude(co => co.Country)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public Airport GetAirport(int id)
        {
            var x = _context.Airports
                .Include(c => c.City)
                .ThenInclude(co => co.Country)
                .Where(p => p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateAirport(Airport obj)
        {
            _context.Airports.Update(obj);
        }
        #endregion

        #region Route
        public void CreateRoute(Route obj)
        {
            _context.Routes.Add(obj);
        }
        public void DeleteRoute(Route obj)
        {
            _context.Routes.Remove(obj);
        }
        public IEnumerable<Route> GetAllRoutes()
        {
            var x = _context.Routes
                .Include(o => o.OriginAirport)
                .Include(d => d.DestinationAirport)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public Route GetRoute(int id)
        {
            var x = _context.Routes
                .Include(o => o.OriginAirport)
                .Include(d => d.DestinationAirport)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateRoute(Route obj)
        {
            _context.Routes.Update(obj);
        }
        #endregion

        #region FlightSchedule
        public FlightSchedule CreateFlightSchedule(FlightSchedule obj)
        {
            var res = _context.FlightSchedules.Add(obj);
            return res.Entity;            
            
        }
        public void DeleteFlightSchedule(FlightSchedule obj)
        {
            _context.FlightSchedules.Remove(obj);
        }
        public IEnumerable<FlightSchedule> GetAllFlightSchedules()
        {
            var x = _context.FlightSchedules
                .Include(s => s.AirlineSchedule)
                .Include(o => o.Airport_Origin)
                .Include(d => d.Airport_Destination)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public IEnumerable<FlightSchedule> GetAllFlightSchedules_byAirlineSchedID(int id)
        {
            var x = _context.FlightSchedules
                .Include(s => s.AirlineSchedule)
                .Include(o => o.Airport_Origin)
                .Include(d => d.Airport_Destination)
                .Where(p => p.isDeleted == false && p.AirlineScheduleID == id);
            return x;
        }
        public bool CheckFlightSched_Status(int id)
        {
            var x = _context.FlightSchedules
                .Where(p => p.isDeleted == false && p.AirlineScheduleID == id && p.Status != FlightStatusEnum.Planned);
            return x.Count() > 0;
        }
        public IEnumerable<FlightSchedule> GetAllFlightSchedules_byResourceID(AssignAircraftSchedDTO obj)
        {
            var x = _context.FlightSchedules
                .Include(ao => ao.Airport_Origin)
                .ThenInclude(aoCity => aoCity.City)
                .Include(ad => ad.Airport_Destination)
                .ThenInclude(adCity => adCity.City)
                .Where(p => p.isDeleted == false && p.resourceId == obj.ResourceID && p.AirlineScheduleID == obj.AirlineScheduleID
                && (p.FlightDate.Date >= obj.From.Date && p.FlightDate.Date <= obj.To.Date));
            return x;
        }
        public IEnumerable<FlightSchedule> GetAllFlightSchedules_byResourceID(FlightScheduleDTO obj)
        {
            //include flight number
            var x = _context.FlightSchedules
                .Include(ao => ao.Airport_Origin)
                .ThenInclude(aoCity => aoCity.City)
                .Include(ad => ad.Airport_Destination)
                .ThenInclude(adCity => adCity.City)
                .Where(p => p.isDeleted == false && p.resourceId == obj.resourceId && p.AirlineScheduleID == obj.AirlineScheduleID
                && (p.FlightDate.Date >= obj.PeriodFrom.Date && p.FlightDate.Date <= obj.PeriodTo.Date) && (p.FlightNo == obj.OutboundFlightNo || p.FlightNo == obj.OutboundFlightNo));
            return x;
        }
        public IEnumerable<FlightSchedule> GetAllFlightSchedules_byResourceID(int AirlineScheduleID,int ResourceID)
        {
            var x = _context.FlightSchedules
                .Include(ao => ao.Airport_Origin)
                .ThenInclude(aoCity => aoCity.City)
                .Include(ad => ad.Airport_Destination)
                .ThenInclude(adCity => adCity.City)
                .Where(p => p.isDeleted == false && p.resourceId == ResourceID && p.AirlineScheduleID == AirlineScheduleID);
            return x;
        }
        public IEnumerable<FlightSchedule> GetAllFlightSchedules_report()
        {
            var x = _context.FlightSchedules
              .Include(ao => ao.Airport_Origin)
              .ThenInclude(aoCity => aoCity.City)
              .Include(ad => ad.Airport_Destination)
              .ThenInclude(adCity => adCity.City)
              .Include(a => a.AircraftType)
              .Where(p => p.isDeleted == false );
            return x.OrderBy(y=>y.STD).ThenBy(z => z.FlightDate);
        }

        public IEnumerable<FlightSchedule> GetAllFlightSchedules_report_withDateRange(DateTime DateFrom, DateTime DateTo)
        {
            var x = _context.FlightSchedules
              .Include(ao => ao.Airport_Origin).ThenInclude(aoCity => aoCity.City)
              .Include(ad => ad.Airport_Destination).ThenInclude(adCity => adCity.City)
              .Include(at => at.AircraftType)
              .Where(p => p.isDeleted == false && (p.FlightDate.Date >= DateFrom.Date && p.FlightDate.Date <= DateTo.Date ));
            return x.OrderBy(y => y.STD).ThenBy(z=> z.FlightDate);
        }
        public IEnumerable<FlightSchedule> GetAllPublishedFlightSchedules(DateTime From, DateTime To)
        {
            

            var x = from fs in _context.FlightSchedules
                    join a in _context.AirlineSchedules on fs.AirlineScheduleID equals a.Id
                    where (fs.isDeleted == false && fs.Status == FlightStatusEnum.Planned && a.isPublished == true && fs.FlightDate >= From && fs.FlightDate <=To)
                    select fs;

            var y = x.Include(ao => ao.Airport_Origin).Include(ad => ad.Airport_Destination).Select(a=>a);
            return y ;
        }
        public FlightSchedule GetFlightSchedule(int id)
        {
            var x = _context.FlightSchedules
                .Include(s => s.AirlineSchedule)
                .Include(o => o.Airport_Origin)
                .Include(d => d.Airport_Destination)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateFlightSchedule(FlightSchedule obj)
        {
            _context.FlightSchedules.Update(obj);
        }

        public List<AircraftSchedule> NumberOfFlights(DateTime dateTime)
        {
            var x = from asc in _context.AircraftSchedules
                    join fs in _context.FlightSchedules on asc.FlightScheduleId equals fs.Id
                    where (asc.isDeleted == false && dateTime.Date == fs.FlightDate.Date)
                    orderby (asc.AircraftID)
                    select asc;
            return x.Include(y => y.FlightSchedule).ToList();

        }
        public List<AircraftSchedule> NumberOfAircraft(DateTime dateTime) {

            var x = from asc in _context.AircraftSchedules

                    join fs in _context.FlightSchedules on asc.FlightScheduleId equals fs.Id
                    where (asc.isDeleted == false && dateTime.Date == fs.FlightDate.Date)
                    select asc;
            return x.Include(y => y.Aircraft).ThenInclude(z => z.AircraftType).ToList();
        }
        #endregion


    }
}
