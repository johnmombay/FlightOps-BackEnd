using FlightOperations.Model;
using FlightOperations.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface IresourceRepository
    {
        int CreateScheduleResource(ScheduleResource obj);
        void DeleteScheduleResource(ScheduleResource obj);
        IEnumerable<ScheduleResource> GetAllScheduleResources();
        IEnumerable<ScheduleResource> GetAllScheduleResources(int AirlineScheduleId);
        ScheduleResource GetScheduleResource(int id);
        void UpdateScheduleResource(ScheduleResource obj);
    }
    public class ResourceRepository:IresourceRepository
    {
        FlightOperationsContext _context;
        public ResourceRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }
        public int CreateScheduleResource(ScheduleResource obj)
        {
            var res = _context.ScheduleResources.Add(obj);
            return res.Entity.Id;
        }
        public void DeleteScheduleResource(ScheduleResource obj)
        {
            _context.ScheduleResources.Remove(obj);
        }
        public IEnumerable<ScheduleResource> GetAllScheduleResources()
        {
            var x = _context.ScheduleResources
                .Where(p => p.isDeleted == false);
            return x;
        }
        public IEnumerable<ScheduleResource> GetAllScheduleResources(int AirlineScheduleId)
        {
            var x = _context.ScheduleResources
                .Where(p => p.isDeleted == false && p.AirlineScheduleID == AirlineScheduleId);
            return x;
        }
        public ScheduleResource GetScheduleResource(int id)
        {
            var x = _context.ScheduleResources
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateScheduleResource(ScheduleResource obj)
        {
            _context.ScheduleResources.Update(obj);
        }
    }
}
