using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface IaircraftRepository
    {
        void CreateAircraftType(AircraftType obj);
        void DeleteAircraftType(AircraftType obj);
        IEnumerable<AircraftType> GetAllAircraftTypes();
        AircraftType GetAircraftType(int id);
        void UpdateAircraftType(AircraftType obj);

        void CreateAircraft(Aircraft obj);
        void DeleteAircraft(Aircraft obj);
        IEnumerable<Aircraft> GetAllAircrafts();
        Aircraft GetAircraft(int id);
        void UpdateAircraft(Aircraft obj);

        void CreateAircraftMaintenance(AircraftMaintenance obj);
        void DeleteAircraftMaintenance(AircraftMaintenance obj);
        IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance();
        AircraftMaintenance GetAircraftMaintenance(int id);
        void UpdateAircraftMaintenance(AircraftMaintenance obj);

        int CreateMaintenanceSchedule(MaintenanceSchedule obj);
        void DeleteMaintenanceSchedule(MaintenanceSchedule obj);
        IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule();
        IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule(DateParamDTO param);
        IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule_byResourceId(string resourceID);
        IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule_withDateRange(DateTime dateFrom, DateTime dateTo);
        MaintenanceSchedule GetMaintenanceSchedule(int id);
        void UpdateMaintenanceSchedule(MaintenanceSchedule obj);

       
    }
    public class aircraftRepository:IaircraftRepository
    {
        FlightOperationsContext _context;
        public aircraftRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }

        #region Aircraft Type
        public void CreateAircraftType(AircraftType obj)
        {
            _context.AircraftTypes.Add(obj);
        }
        public void DeleteAircraftType(AircraftType obj)
        {
            _context.AircraftTypes.Remove(obj);
        }
        public IEnumerable<AircraftType> GetAllAircraftTypes()
        {
            var x = _context.AircraftTypes
                .Where(p => p.isDeleted == false);
            return x;
        }
        public AircraftType GetAircraftType(int id)
        {
            var x = _context.AircraftTypes
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateAircraftType(AircraftType obj)
        {
            _context.AircraftTypes.Update(obj);
        }
        #endregion

        #region Aircraft
        public void CreateAircraft(Aircraft obj)
        {
            _context.Aircrafts.Add(obj);
        }
        public void DeleteAircraft(Aircraft obj)
        {
            _context.Aircrafts.Remove(obj);
        }
        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            var x = _context.Aircrafts
                .Include(a => a.AircraftType)
                .Include(c => c.Country)
                .Where(p => p.isDeleted == false);
            return x.OrderBy(y => y.AircraftType.AircraftTypeName).ThenBy(z => z.Registration);
        }
        public IEnumerable<Aircraft> GetAllAircrafts_ByAircraftType(int aircraftTypeId)
        {
            var x = _context.Aircrafts
                .Include(a => a.AircraftType)
                .Include(c => c.Country)
                .Where(p => p.isDeleted == false && p.AircraftTypeId == aircraftTypeId);
            return x;
        }
        public Aircraft GetAircraft(int id)
        {
            var x = _context.Aircrafts
                .Include(a => a.AircraftType)
                .Include(c => c.Country)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }

        public void UpdateAircraft(Aircraft obj)
        {
            _context.Aircrafts.Update(obj);
        }
        #endregion

        #region Aircraft Maintenance
        public void CreateAircraftMaintenance(AircraftMaintenance obj)
        {
            _context.AircraftMaintenances.Add(obj);
        }
        public void DeleteAircraftMaintenance(AircraftMaintenance obj)
        {
            _context.AircraftMaintenances.Remove(obj);
        }
        public IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance()
        {
            var x = _context.AircraftMaintenances
                .Include(a => a.AircraftType)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public AircraftMaintenance GetAircraftMaintenance(int id)
        {
            var x = _context.AircraftMaintenances
                .Include(a => a.AircraftType)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateAircraftMaintenance(AircraftMaintenance obj)
        {
            _context.AircraftMaintenances.Update(obj);
        }
        #endregion

        #region Maintenance Schedule
        public int CreateMaintenanceSchedule(MaintenanceSchedule obj)
        {
            var res = _context.MaintenanceSchedules.Add(obj);
            return res.Entity.Id;
        }
        public void DeleteMaintenanceSchedule(MaintenanceSchedule obj)
        {
            _context.MaintenanceSchedules.Remove(obj);
        }
        public IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule()
        {
            var x = _context.MaintenanceSchedules
                .Include(am => am.AircraftMaintenance)
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false);
            return x;
        }

        public IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule(DateTime from, DateTime to)
        {
            var x = _context.MaintenanceSchedules
                .Include(am => am.AircraftMaintenance)
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false && p.MaintenanceDate >= from.Date && p.MaintenanceDate <= to.Date);
            return x;
        }
        public IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule(DateParamDTO param)
        {
            var x = _context.MaintenanceSchedules
                .Include(am => am.AircraftMaintenance)
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false);
            if(param != null)
            {
                return x.Where(m => m.MaintenanceDate >= param.From && m.MaintenanceDate <= param.To);
            }
            return x;
        }
        public IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule_byResourceId(string resourceID)
        {
            var x = _context.MaintenanceSchedules
                .Include(am => am.AircraftMaintenance)
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false && p.ResourceID == resourceID);
            return x;
        }
        public IEnumerable<MaintenanceSchedule> GetAllMaintenanceSchedule_withDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var x = _context.MaintenanceSchedules
                .Include(am => am.AircraftMaintenance)
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false && (p.MaintenanceDate.Date >= dateFrom.Date && p.MaintenanceDate <= dateTo.Date));
            return x.OrderByDescending(y => y.MaintenanceDate);
        }
        public MaintenanceSchedule GetMaintenanceSchedule(int id)
        {
            var x = _context.MaintenanceSchedules
                .Include(am => am.AircraftMaintenance)
                .Include(a => a.Aircraft)
                .ThenInclude(at => at.AircraftType)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateMaintenanceSchedule(MaintenanceSchedule obj)
        {
            _context.MaintenanceSchedules.Update(obj);
        }
        #endregion

    }
}
