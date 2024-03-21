using FlightOperations.Model;
using FlightOperations.Model.Entity;
using FlightOperations.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface IcrewPlanningRepository
    {
        void CreateCrewPosition(CrewPosition obj);
        void DeleteCrewPosition(CrewPosition obj);
        IEnumerable<CrewPosition> GetAllCrewPosition();
        CrewPosition GetCrewPosition(int id);
        void UpdateCrewPosition(CrewPosition obj);

        void CreateCrew(Crew obj);
        void DeleteCrew(Crew obj);
        IEnumerable<Crew> GetAllCrew();
        IEnumerable<Crew> GetAllCrew_ByCrewPos(int id);
        IEnumerable<Crew> GetAllCrew_ByCrewPositionType(PositionTypeEnum positionType);
        Crew GetCrew(int id);
        void UpdateCrew(Crew obj);

        void CreateCrewSchedule(CrewSchedule obj);
        void DeleteCrewSchedule(CrewSchedule obj);
        IEnumerable<CrewSchedule> GetAllCrewSchedule();
        IEnumerable<CrewSchedule> GetAllCrewSchedule_byFlightSched(int id);
        IEnumerable<CrewSchedule> GetAllCrewSchedule_withDateRange(DateTime dateFrom, DateTime dateTo);
        IEnumerable<Crew> GetAllCrew_byFlightSched(int id);
        CrewSchedule GetCrewSchedule(int id);
        IEnumerable<Crew> CrewsAssigned(DateTime dateTime);
        void UpdateCrewSchedule(CrewSchedule obj);
    }
    public class crewPlanningRepository:IcrewPlanningRepository
    {
        FlightOperationsContext _context;
        public crewPlanningRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }
        #region CrewPosition
        public void CreateCrewPosition(CrewPosition obj)
        {
            _context.CrewPositions.Add(obj);
        }
        public void DeleteCrewPosition(CrewPosition obj)
        {
            _context.CrewPositions.Remove(obj);
        }
        public IEnumerable<CrewPosition> GetAllCrewPosition()
        {
            var x = _context.CrewPositions.Where(p => p.isDeleted == false);
            return x;
        }
        public CrewPosition GetCrewPosition(int id)
        {
            var x = _context.CrewPositions.Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateCrewPosition(CrewPosition obj)
        {
            _context.CrewPositions.Update(obj);
        }
        #endregion
        #region Crew
        public void CreateCrew(Crew obj)
        {
            _context.Crews.Add(obj);
        }
        public void DeleteCrew(Crew obj)
        {
            _context.Crews.Remove(obj);
        }
        public IEnumerable<Crew> GetAllCrew()
        {
            var x = _context.Crews
                .Include(p => p.CrewPosition)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public IEnumerable<Crew> GetAllCrew_ByCrewPos(int id)
        {
            var x = _context.Crews
                   .Include(p=>p.CrewPosition)
                .Where(p => p.isDeleted == false && p.CrewPositionID == id);
            return x;
        }
        public IEnumerable<Crew> GetAllCrew_ByCrewPositionType(PositionTypeEnum positionType)
        {
            var x = _context.Crews
                   .Include(p => p.CrewPosition)
                .Where(p => p.isDeleted == false && p.CrewPosition.PositionType == positionType);
            return x;
        }
        public Crew GetCrew(int id)
        {
            var x = _context.Crews.Include(p=>p.CrewPosition).Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateCrew(Crew obj)
        {
            _context.Crews.Update(obj);
        }
        #endregion
        #region CrewSchedule
        public void CreateCrewSchedule(CrewSchedule obj)
        {
            _context.CrewSchedules.Add(obj);
        }
        public void DeleteCrewSchedule(CrewSchedule obj)
        {
            _context.CrewSchedules.Remove(obj);
        }
        public IEnumerable<CrewSchedule> GetAllCrewSchedule()
        {
            var x = _context.CrewSchedules
                .Include(c =>c.Crew)
                .Include(f =>f.FlightSchedule)
                .Where(p => p.isDeleted == false);
            return x.OrderByDescending(y => y.FlightSchedule.FlightDate);
        }
        public IEnumerable<CrewSchedule> GetAllCrewSchedule_byFlightSched(int id)
        {
            var x = _context.CrewSchedules.Where(p => p.isDeleted == false && p.FlightScheduleID == id);
            return x.OrderBy(y => y.FlightSchedule.FlightDate);
        }
        public IEnumerable<CrewSchedule> GetAllCrewSchedule_withDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var x = _context.CrewSchedules
                .Include(f => f.FlightSchedule).ThenInclude(oa => oa.Airport_Origin).ThenInclude(oac => oac.City)
                .Include(f => f.FlightSchedule).ThenInclude(od => od.Airport_Destination).ThenInclude(odc => odc.City)
                .Include(f => f.FlightSchedule).ThenInclude(at => at.AircraftType)
                .Include(c => c.Crew).ThenInclude(cp => cp.CrewPosition)
                .Where(p => p.isDeleted == false && (p.FlightSchedule.FlightDate.Date >= dateFrom.Date && p.FlightSchedule.FlightDate.Date <= dateTo.Date));
            
            return x.OrderBy(y => y.FlightSchedule.FlightDate );
        }
        public IEnumerable<Crew> GetAllCrew_byFlightSched(int id)
        {

            List<Crew> Crew = new List<Crew>();
            var x = _context.CrewSchedules
                .Include(c=>c.Crew)
                .ThenInclude(p=>p.CrewPosition)
                .Where(p => p.isDeleted == false && p.FlightScheduleID == id);
            foreach(var members in x)
            {
                
                Crew.Add(members.Crew);
            }
            return Crew;
        }

        public CrewSchedule GetCrewSchedule(int id)
        {
            var x = _context.CrewSchedules.Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateCrewSchedule(CrewSchedule obj)
        {
            _context.CrewSchedules.Update(obj);
        }

        public IEnumerable<Crew> CrewsAssigned(DateTime dateTime)
        {
            var x = from c in _context.Crews
                    join cs in _context.CrewSchedules on c.Id equals cs.CrewID
                    join fs in _context.FlightSchedules on cs.FlightScheduleID equals fs.Id
                    where (c.isDeleted == false && fs.FlightDate.Date == dateTime.Date)
                    select c;
            return x.OrderBy(y => y.CrewPositionID);
        }
        #endregion

    }
}
