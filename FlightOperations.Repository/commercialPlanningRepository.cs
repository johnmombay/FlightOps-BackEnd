using FlightOperations.Model;
using FlightOperations.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface IcommercialPlanningRepository
    {
        int CreateAirlineSchedule(AirlineSchedule obj);
        void DeleteAirlineSchedule(AirlineSchedule obj);
        IEnumerable<AirlineSchedule> GetAllAirlineSchedules();
        AirlineSchedule GetAirlineSchedule(int id);
        void UpdateAirlineSchedule(AirlineSchedule obj);

        void CreateSchedule_AircraftType(Schedule_AircraftType obj);
        void DeleteSchedule_AircraftType(Schedule_AircraftType obj);
        IEnumerable<Schedule_AircraftType> GetAllSchedule_AircraftType();
        IEnumerable<Schedule_AircraftType> GetAllSchedule_AircraftType_ByAirlineSchedId(int id);
        Schedule_AircraftType GetSchedule_AircraftType(int id);
        void UpdateSchedule_AircraftType(Schedule_AircraftType obj);
    }
    public class commercialPlanningRepository:IcommercialPlanningRepository
    {
        FlightOperationsContext _context;
        public commercialPlanningRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }
        #region AirlineSchedule
        public int CreateAirlineSchedule(AirlineSchedule obj)
        {
            var res = _context.AirlineSchedules.Add(obj);
            return res.Entity.Id;
        }
        public void DeleteAirlineSchedule(AirlineSchedule obj)
        {
            _context.AirlineSchedules.Remove(obj);
        }
        public IEnumerable<AirlineSchedule> GetAllAirlineSchedules()
        {
            var x = _context.AirlineSchedules
                .Include(s_at => s_at.AircraftTypes)
                .ThenInclude(at => at.AircraftType)
                .Include(sr => sr.ScheduleResources)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public AirlineSchedule GetAirlineSchedule(int id)
        {
            var x = _context.AirlineSchedules
                .Include(at=> at.AircraftTypes)
                .ThenInclude(at => at.AircraftType)
                .Include(sr => sr.ScheduleResources)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateAirlineSchedule(AirlineSchedule obj)
        {
            _context.AirlineSchedules.Update(obj);
        }
        #endregion
        #region Schedule_AircraftType
        public void CreateSchedule_AircraftType(Schedule_AircraftType obj)
        {
            _context.Schedule_AircraftTypes.Add(obj);
        }
        public void DeleteSchedule_AircraftType(Schedule_AircraftType obj)
        {
            _context.Schedule_AircraftTypes.Remove(obj);
        }
        public IEnumerable<Schedule_AircraftType> GetAllSchedule_AircraftType()
        {
            var x = _context.Schedule_AircraftTypes
                .Where(p => p.isDeleted == false);
            return x;
        }
        public IEnumerable<Schedule_AircraftType> GetAllSchedule_AircraftType_ByAirlineSchedId(int id)
        {
            var x = _context.Schedule_AircraftTypes
                .Where(p => p.isDeleted == false && p.Airline_ScheduleID == id);
            return x;
        }
        public Schedule_AircraftType GetSchedule_AircraftType(int id)
        {
            var x = _context.Schedule_AircraftTypes
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateSchedule_AircraftType(Schedule_AircraftType obj)
        {
            _context.Schedule_AircraftTypes.Update(obj);
        }

        #endregion


    }
}
