using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using FlightOperations.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface IflightOperationsRepository
    {
        int CreateAircraftSchedule(AircraftSchedule obj);
        void DeleteAircraftSchedule(AircraftSchedule obj);
        IEnumerable<AircraftSchedule> GetAllAircraftSchedule();
        IEnumerable<AircraftSchedule> GetAllAircraftSchedule(int ResourceID, int AirlineScheduleID, DateTime flightDate);
        IEnumerable<AircraftSchedule> GetAllAircraftSchedule(int AirlineScheduleId, int ResourceId);
        List<AircraftSchedule> NumberOfDelayedFlights(DateTime dateTime);
        AircraftSchedule GetAircraftSchedule_byFlightIdSchedule(int id);
        IEnumerable<ScheduleResource> GetAllPublishedResources();
        AircraftSchedule GetAircraftSchedule(int id);
        void UpdateAircraftSchedule(AircraftSchedule obj);
    }
    public class flightOperationsRepository:IflightOperationsRepository
    {
        FlightOperationsContext _context;
        public flightOperationsRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }
        #region AircraftSchedule
        public int CreateAircraftSchedule(AircraftSchedule obj)
        {
            var res = _context.AircraftSchedules.Add(obj);
                 return res.Entity.Id;
        }
        public void DeleteAircraftSchedule(AircraftSchedule obj)
        {
            _context.AircraftSchedules.Remove(obj);
        }
        public IEnumerable<AircraftSchedule> GetAllAircraftSchedule()
        {
            var x = _context.AircraftSchedules
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public AircraftSchedule GetAircraftSchedule(int id)
        {
            var x = _context.AircraftSchedules
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Include(fs => fs.FlightSchedule)
                .ThenInclude(ad => ad.Airport_Destination)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public AircraftSchedule GetAircraftSchedule_byFlightIdSchedule(int id)
        {
            var x = _context.AircraftSchedules
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false && p.FlightScheduleId == id).FirstOrDefault();
            return x;
        }
        public IEnumerable<AircraftSchedule> GetAllAircraftSchedule(int ResourceID, int AirlineScheduleID,DateTime flightDate)
        {
            var x = _context.AircraftSchedules
                .Include(fs => fs.FlightSchedule)
                .Where(p => p.isDeleted == false && p.FlightSchedule.resourceId == ResourceID
                && p.FlightSchedule.AirlineScheduleID == AirlineScheduleID && (flightDate.Date <= p.FlightSchedule.FlightDate.Date));
            return x.OrderBy(z => z.ASTD);
        }

        public IEnumerable<AircraftSchedule> GetAllAircraftSchedule(int AirlineScheduleId, int ResourceId)
        {
            var x = _context.AircraftSchedules
                .Include(fs => fs.FlightSchedule)
                .Where(p => p.isDeleted == false && p.FlightSchedule.resourceId == ResourceId
                && p.FlightSchedule.AirlineScheduleID == AirlineScheduleId);
            return x.OrderBy(z => z.ASTD);
        }
        public IEnumerable<AircraftSchedule> GetAllAircraftSchedule(DateParamDTO param)
        {
            
            var AircraftSched = from ax in _context.AircraftSchedules
                                join f in _context.FlightSchedules on ax.FlightScheduleId equals f.Id
                                join a in _context.AirlineSchedules on f.AirlineScheduleID equals a.Id
                                where (f.isDeleted == false && a.isPublished == true)
                                select ax;

            var y = AircraftSched
                .Include(f => f.FlightSchedule)
                .ThenInclude(ao => ao.Airport_Origin)
                .Include(f => f.FlightSchedule)
                .ThenInclude(ad => ad.Airport_Origin)
                .Include(a => a.Aircraft)
                .Select(f => f);
                

            var x = y;
            if (param != null)
                x = y.Where(z => z.FlightSchedule.FlightDate >= param.From && z.FlightSchedule.FlightDate <= param.To);

            return x.OrderBy(z => z.ASTD);
        }
        public IEnumerable<ScheduleResource> GetAllPublishedResources()
        {
            var x = from sr in _context.ScheduleResources
                    join a in _context.AirlineSchedules on sr.AirlineScheduleID equals a.Id
                    where (sr.isDeleted == false && a.isPublished == true)
                    select  sr;
            return x.OrderBy(y => y.Name);
        }

        public void UpdateAircraftSchedule(AircraftSchedule obj)
        {
            _context.AircraftSchedules.Update(obj);
        }

        public List<AircraftSchedule> NumberOfDelayedFlights(DateTime dateTime)
        {
            var x = from a in _context.AircraftSchedules
                    join fs in _context.FlightSchedules on a.FlightScheduleId equals fs.Id
                    where (fs.isDeleted == false && fs.STD <= a.ATD && dateTime.Date == fs.FlightDate.Date)
                    select a;
            return x.Include(f => f.FlightSchedule).ToList();

        }
        #endregion
    }
}
