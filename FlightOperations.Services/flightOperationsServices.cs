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
    public interface IflightOperationsServices
    {
        IEnumerable<FlightScheduleDTO_Return> AssignAircraft(AssignAircraftSchedDTO obj, int userId);
        IEnumerable<FlightScheduleDTO_Return> UpdateAircraftSched(UpdateAircraftSchedDTO obj, int userId);
        IEnumerable<FlightScheduleDTO_Return> SetActual(ActualFlightDTO obj, int userId);
        IEnumerable<FlightScheduleDTO_Return> GetAllAircraftSchedules_byResourceID(int AirlineScheduleID, int ResourceID);
        IEnumerable<ScheduleResource> GetAllPublishedScheduleResource();
        IEnumerable<FlightScheduleDTO_Return> GetAircraftSchedules(DateParamDTO param);
        DelayedFlightsDTO NumberOfDelayedFlights(DelayedFlightsDTO obj);
    }
    public class flightOperationsServices : IflightOperationsServices
    {
        private FlightOperationsContext _context;
        private IMapper _mapper;
        private flightOperationsRepository _flightOpsRepo;
        private flightscheduleRepository _flightschedRepo;
        private aircraftRepository _aicraftRepo;
        private crewPlanningRepository _crewPlanningRepo;
        private commercialPlanningRepository _commercialPlanningRepo;
        public flightOperationsServices(FlightOperationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _flightOpsRepo = new flightOperationsRepository(_context);
            _flightschedRepo = new flightscheduleRepository(_context);
            _aicraftRepo = new aircraftRepository(_context);
            _crewPlanningRepo = new crewPlanningRepository(_context);
            _commercialPlanningRepo = new commercialPlanningRepository(_context);
          
        }  
        public IEnumerable<FlightScheduleDTO_Return> AssignAircraft(AssignAircraftSchedDTO obj, int userId)
        {

           // var airlineSched = _commercialPlanningRepo.GetAirlineSchedule(obj.AirlineScheduleID);
           // if (airlineSched.isPublished) throw new appException("Invalid. Cannot edit Published Airline Schedules.");

            var result = _flightschedRepo.GetAllFlightSchedules_byResourceID(obj);
            if (result == null)
                throw new appException("No Flight Schedule Found.");
            var DateCreated = DateTime.UtcNow;
            try { 
            foreach (var sched in result)
            {
                if(sched.Status == FlightStatusEnum.Planned) {

                        AircraftSchedule newAircraftSched = new AircraftSchedule();
                        newAircraftSched.FlightScheduleId = sched.Id;
                        newAircraftSched.ASTD = sched.STD;
                        newAircraftSched.ASTA = sched.STA;
                        newAircraftSched.AircraftID = obj.AircraftID;
                        newAircraftSched.AircraftFlightDate = sched.FlightDate.ToUniversalTime();
                        newAircraftSched.CreatedBy = userId;
                        newAircraftSched.UpdatedBy = userId;
                        newAircraftSched.CreatedDate = DateCreated;
                        newAircraftSched.UpdatedDate = DateCreated;
                        newAircraftSched.isDeleted = false;

                        sched.Status = FlightStatusEnum.Assigned;
                        _flightschedRepo.UpdateFlightSchedule(sched);
                        _flightOpsRepo.CreateAircraftSchedule(newAircraftSched);

                }
            }
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
            return GetAircraftSchedules(new DateParamDTO());
           //return GetAllAircraftSchedules_byResourceID(obj.AirlineScheduleID, obj.ResourceID);
        }
        public IEnumerable<FlightScheduleDTO_Return> UpdateAircraftSched(UpdateAircraftSchedDTO obj, int userId)
        {

            var aircraftSched = _flightOpsRepo.GetAircraftSchedule(obj.AircraftScheduleId);

            var resourceId = aircraftSched.FlightSchedule.resourceId;
            var airlineScheduleId = aircraftSched.FlightSchedule.AirlineScheduleID;

            if (aircraftSched == null)
                throw new appException("No Aircraft Schedule Found.");

            try { 
            
            var aSchedules = _flightOpsRepo.GetAllAircraftSchedule(resourceId, airlineScheduleId, aircraftSched.FlightSchedule.FlightDate);
            var groundTime = aircraftSched.FlightSchedule.Airport_Destination.StandardGroundTime;
            var blockTime = aircraftSched.FlightSchedule.BlockTime;

                aircraftSched.ASTD = obj.ASTD;
            aircraftSched.ASTA = aircraftSched.ASTD.AddMinutes(blockTime);
            aircraftSched.AircraftFlightDate = obj.ASTD.Date;
            aircraftSched.UpdatedBy = userId;
            aircraftSched.UpdatedDate = DateTime.UtcNow;

            _flightOpsRepo.UpdateAircraftSchedule(aircraftSched);

                var oldASTD = aircraftSched.ASTD;
                var oldASTA = aircraftSched.ASTA;

                foreach (var sched in aSchedules)
            {
                if (obj.AircraftScheduleId != sched.Id)
                {
                        if (sched.ASTD > oldASTD)
                        {
                            var newASTD = oldASTA.AddMinutes(groundTime);
                            if (newASTD > sched.ASTD)
                            {
                                sched.ASTD = newASTD;
                                sched.ASTA = sched.ASTD.AddMinutes(blockTime);
                                sched.AircraftFlightDate = newASTD.Date;
                                sched.UpdatedBy = userId;
                                sched.UpdatedDate = aircraftSched.UpdatedDate;

                                _flightOpsRepo.UpdateAircraftSchedule(sched);
                            }
                            oldASTD = sched.ASTD;
                            oldASTA = sched.ASTA;
                        }
                }               
            }
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            //Call getAircraftschedules by Resrouceid
            //return GetAllAircraftSchedules_byResourceID(obj.AirlineScheduleID, obj.ResourceID);

            return GetAircraftSchedules(new DateParamDTO() { From = obj.ASTD.Date.AddDays(-1), To=obj.ASTD.Date.AddDays(1) }) ;

        }
        public IEnumerable<FlightScheduleDTO_Return> SetActual(ActualFlightDTO obj, int userId)
        {
            var aircraftSched = _flightOpsRepo.GetAircraftSchedule(obj.AircraftScheduleId);
            if (aircraftSched == null)
                throw new appException("No Aircraft Schedule Found.");
            if (!obj.ATD.HasValue)
                throw new appException("No Actual Time of Departure Entered.");
            try {

                var aSchedules = _flightOpsRepo.GetAllAircraftSchedule(obj.ResourceID, obj.AirlineScheduleID, aircraftSched.FlightSchedule.FlightDate);
                var groundTime = aircraftSched.FlightSchedule.Airport_Destination.StandardGroundTime;
                var blockTime = aircraftSched.FlightSchedule.BlockTime;

                var FlightSched = _flightschedRepo.GetFlightSchedule(aircraftSched.FlightScheduleId);

                aircraftSched.ATD = obj.ATD.Value;
                if (obj.ATA.HasValue)
                {
                    aircraftSched.ATA = obj.ATA.Value;
                    FlightSched.Status = FlightStatusEnum.Completed;
                }
                else
                {
                    FlightSched.Status = FlightStatusEnum.EnRoute;
                }
                
                aircraftSched.AircraftFlightDate = obj.ATD.Value.Date;
                aircraftSched.AdultPAX = obj.AdultPAX >= 0 ? obj.AdultPAX : 0;
                aircraftSched.ChildPAX = obj.ChildPAX >= 0 ? obj.ChildPAX : 0;
                aircraftSched.Cargo = obj.Cargo >= 0 ? obj.Cargo : 0;
                aircraftSched.Comments = obj.Comments;
                aircraftSched.UpdatedBy = userId;
                aircraftSched.UpdatedDate = DateTime.UtcNow;

                _flightOpsRepo.UpdateAircraftSchedule(aircraftSched);
                _flightschedRepo.UpdateFlightSchedule(FlightSched);

                var oldASTD = aircraftSched.ASTD;
                var oldASTA = aircraftSched.ASTA;

                var oldATD = aircraftSched.ATD.Value;
                var oldATA = aircraftSched.ATA.HasValue ? aircraftSched.ATA.Value : aircraftSched.ATD.Value.AddMinutes(blockTime);
                
                //To Follow: Adjustment of FlightSchedule if ATA is earlier
                foreach (var sched in aSchedules)
                {
                    if (obj.AircraftScheduleId != sched.Id)
                    {
                        if (sched.ASTD > oldASTD)
                        {
                            var newASTD = oldATA.AddMinutes(groundTime);
                            if (newASTD > sched.ASTD)
                            {
                                sched.ASTD = newASTD;
                                sched.ASTA = sched.ASTD.AddMinutes(blockTime);
                                sched.ATA = null;
                                sched.ATD = null;
                                sched.AircraftFlightDate = newASTD.Date;
                                sched.UpdatedBy = userId;
                                sched.UpdatedDate = aircraftSched.UpdatedDate;

                                _flightOpsRepo.UpdateAircraftSchedule(sched);
                            }
                            oldASTD = sched.ASTD;
                            oldATA = sched.ASTA;
                        }
                    }
            }
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            //Call getAircraftschedules by Resrouceid
            return GetAllAircraftSchedules_byResourceID(obj.AirlineScheduleID, obj.ResourceID);

        }
        public IEnumerable<ScheduleResource> GetAllPublishedScheduleResource()
        {
            var schedRes = _flightOpsRepo.GetAllPublishedResources();
            return schedRes;
        }

        public IEnumerable<FlightScheduleDTO_Return> GetAircraftSchedules(DateParamDTO param)
        {
            if(param.From < DateTime.MinValue || param.To <= DateTime.MinValue)
            {
                param = null;
            }
      
            List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();
            var ret = _flightOpsRepo.GetAllAircraftSchedule(param);
           
            // Flight schedule
            foreach (var sched in ret)
            {
                var crews = _mapper.Map<IEnumerable<CrewDTO>>(_crewPlanningRepo.GetAllCrew_byFlightSched(sched.FlightScheduleId));

                var destination = _flightschedRepo.GetAirport(sched.FlightSchedule.Airport_DestinationID);
                var origin = _flightschedRepo.GetAirport(sched.FlightSchedule.Airport_OriginID);
                //original schedule
                var origresponse = new FlightScheduleDTO_Return();
                origresponse.Aircraft = _mapper.Map<AircraftDTO>(sched.Aircraft);
                origresponse.AircraftSchedule = _mapper.Map<AircraftScheduleDTO>(sched);
                origresponse.Crews = crews != null ? crews : null;
                origresponse.end = sched.FlightSchedule.STA;
                origresponse.start = sched.FlightSchedule.STD;
                origresponse.Id = "P" + sched.Id;
                origresponse.resourceId = sched.Aircraft.Id;
                origresponse.EventType = "Flight";
                origresponse.FlightDetails = _mapper.Map<FlightScheduleDTO>(sched.FlightSchedule);
                origresponse.Status = sched.FlightSchedule.Status;
                origresponse.FlightStatus = "Planned";
                origresponse.Title = sched.FlightSchedule.FlightNo + ":" + origin.IATA_Code + " - " + destination.IATA_Code;
                list_FlightSchedules.Add(origresponse);

                //aircraft schedule
                var response = new FlightScheduleDTO_Return();
                response.Aircraft = _mapper.Map<AircraftDTO>(sched.Aircraft);
                response.AircraftSchedule = _mapper.Map<AircraftScheduleDTO>(sched);
                response.Crews = crews != null ? crews : null;
                response.end = sched.ASTA;
                response.start = sched.ASTD;
                response.Id = "S" + sched.Id;
                response.resourceId = sched.Aircraft.Id;
                response.EventType = "Aircraft";
                response.FlightStatus = "Scheduled";
                response.FlightDetails = _mapper.Map<FlightScheduleDTO>(sched.FlightSchedule);
                response.Status = sched.FlightSchedule.Status;
                response.Title = sched.FlightSchedule.FlightNo + ":" + origin.IATA_Code + " - " + destination.IATA_Code;
                list_FlightSchedules.Add(response);

                //actual schedule
                if(sched.ATD != null)
                {
                    var actualresponse = new FlightScheduleDTO_Return();
                    actualresponse.Aircraft = _mapper.Map<AircraftDTO>(sched.Aircraft);
                    actualresponse.AircraftSchedule = _mapper.Map<AircraftScheduleDTO>(sched);
                    actualresponse.Crews = crews != null ? crews : null;
                    actualresponse.end = sched.ATA.Value;
                    actualresponse.start = sched.ATD.Value;
                    actualresponse.Id = "A" + sched.Id;
                    actualresponse.resourceId = sched.Aircraft.Id;
                    actualresponse.EventType = "Actual";
                    actualresponse.Status = sched.FlightSchedule.Status;
                    if (sched.FlightSchedule.STD < sched.ATD)
                    {
                        actualresponse.FlightStatus = "Delayed";
                    }
                    else
                    {
                        actualresponse.FlightStatus = "On Time";
                    }
                    if(actualresponse.Status == FlightStatusEnum.Cancelled)
                    {
                        actualresponse.FlightStatus = "Cancelled";
                    }
                    actualresponse.FlightDetails = _mapper.Map<FlightScheduleDTO>(sched.FlightSchedule);
                    
                    actualresponse.Title = sched.FlightSchedule.FlightNo + ":" + origin.IATA_Code + " - " + destination.IATA_Code;
                    list_FlightSchedules.Add(actualresponse);

                }

            }

            //Maintenance
            var maintenanceSched = _aicraftRepo.GetAllMaintenanceSchedule(param);

            foreach(var sched in maintenanceSched)
            {
                var mresponse = new FlightScheduleDTO_Return();
                mresponse.Aircraft = _mapper.Map<AircraftDTO>(sched.Aircraft);
                mresponse.AircraftSchedule = null;
                mresponse.Crews = null;
                mresponse.end = sched.scheduleFrom;
                mresponse.start = sched.scheduleTo;
                mresponse.Id = "M" + sched.Id;
                mresponse.resourceId = sched.Aircraft.Id;
                mresponse.EventType = "Maintenance";
                mresponse.FlightDetails = null;
                mresponse.Status =  FlightStatusEnum.Grounded;
                mresponse.FlightStatus = "Maintenance";
                mresponse.Title = sched.AircraftMaintenance.MaintenanceCode + ":" + sched.Aircraft.AircraftType.AircraftTypeName;
                list_FlightSchedules.Add(mresponse);
            }


            return list_FlightSchedules;
        }
        public IEnumerable<FlightScheduleDTO_Return> GetAllAircraftSchedules_byResourceID(int AirlineScheduleID,int ResourceID)
        {
            //Add VALIDATION if AIRLINESCHEDULE isPublished =true > throw appException

           var aircraftSchedules = _flightOpsRepo.GetAllAircraftSchedule(AirlineScheduleID,ResourceID);

            List<FlightScheduleDTO_Return> list_FlightSchedules = new List<FlightScheduleDTO_Return>();
            foreach (var sched in aircraftSchedules)
            {
                FlightScheduleDTO_Return AircraftSchedDTOs = new FlightScheduleDTO_Return();
                AircraftSchedDTOs.Id = sched.Id.ToString();
                AircraftSchedDTOs.start = sched.ASTD;
                AircraftSchedDTOs.end = sched.ASTA;
                AircraftSchedDTOs.resourceId = sched.FlightSchedule.resourceId;
                AircraftSchedDTOs.Status = sched.FlightSchedule.Status;
                var Airport_Origin = _flightschedRepo.GetAirport(sched.FlightSchedule.Airport_OriginID);
                var Airport_Destination = _flightschedRepo.GetAirport(sched.FlightSchedule.Airport_DestinationID);
                AircraftSchedDTOs.Crews = _mapper.Map<IEnumerable<CrewDTO>>(_crewPlanningRepo.GetAllCrew_byFlightSched(sched.FlightScheduleId));
                AircraftSchedDTOs.FlightDetails = _mapper.Map<FlightScheduleDTO>(sched.FlightSchedule);
                AircraftSchedDTOs.Aircraft = _mapper.Map<AircraftDTO>(_aicraftRepo.GetAircraft(sched.AircraftID));

                AircraftSchedDTOs.Title = sched.FlightSchedule.FlightNo + ": " + Airport_Origin.IATA_Code + " - " + Airport_Destination.IATA_Code;
                list_FlightSchedules.Add(AircraftSchedDTOs);
            }
            return list_FlightSchedules;
        }

        public DelayedFlightsDTO NumberOfDelayedFlights(DelayedFlightsDTO obj)
        {
            List<AircraftSchedule> result = _flightOpsRepo.NumberOfDelayedFlights(obj.DateRequested);
            DelayedFlightsDTO delayedFlightDetails = new DelayedFlightsDTO();
             delayedFlightDetails.NumOfFlights = result.Count;
            var totalMins = 0d;
            foreach(var sched in result)
            {                

                TimeSpan interval = sched.ATD.Value - sched.FlightSchedule.STD;
                totalMins += interval.TotalMinutes;
            }
            delayedFlightDetails.TotalMinutesDelayed = totalMins;
            delayedFlightDetails.DateRequested = obj.DateRequested;
            return delayedFlightDetails;
        }
    }
}
