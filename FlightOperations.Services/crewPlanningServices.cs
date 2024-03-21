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
    public interface IcrewPlanningServices
    {
        CrewPositionDTO CreateCrewPosition(CrewPositionDTO_Edit obj);
        void DeleteCrewPosition(int id);
        CrewPositionDTO GetCrewPosition(int id);
        IEnumerable<CrewPositionDTO> GetAllCrewPosition();
        void UpdateCrewPosition(CrewPositionDTO_Edit obj);

        CrewDTO CreateCrew(CrewDTO_Edit obj);
        void DeleteCrew(int id);
        CrewDTO GetCrew(int id);
        IEnumerable<CrewDTO> GetAllCrew();
        IEnumerable<CrewDTO> GetAllCrew_ByCrewPos(int id);
        IEnumerable<CrewDTO> GetAllCrew_ByCrewPositionType(PositionTypeEnum positionType);
        void UpdateCrew(CrewDTO_Edit obj);
        IEnumerable<CrewsAssignedDTO> NumberOfCrews(CrewsAssignedDTO obj);

        CrewScheduleDTO CreateCrewSchedule(CrewScheduleDTO_Edit obj);
        IEnumerable<CrewDTO> SaveCrewSchedule(List<CrewScheduleDTO_Edit> obj,int userid);
        void DeleteCrewSchedule(int id);
        CrewScheduleDTO GetCrewSchedule(int id);
        IEnumerable<CrewScheduleDTO> GetAllCrewSchedule();
        IEnumerable<CrewScheduleDTO> GetAllCrewSchedule_withDateRange(ReportFiltersDTO obj);
        void UpdateCrewSchedule(CrewScheduleDTO_Edit obj);
    }
    public class crewPlanningServices : IcrewPlanningServices
    {
        private FlightOperationsContext _context;
        private IMapper _mapper;
        private crewPlanningRepository _crewPlanningRepo;
        
        public crewPlanningServices(FlightOperationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _crewPlanningRepo = new crewPlanningRepository(_context);
        }
        #region CrewPosition
        public CrewPositionDTO CreateCrewPosition(CrewPositionDTO_Edit obj)
        {
            var crewPos = _mapper.Map<CrewPosition>(obj);
            crewPos.CreatedDate = DateTime.UtcNow;
            crewPos.UpdatedDate = crewPos.CreatedDate;
            crewPos.isDeleted = false;
            _crewPlanningRepo.CreateCrewPosition(crewPos);

            try
            {
                _context.SaveChanges();
                return _mapper.Map<CrewPositionDTO>(crewPos);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void DeleteCrewPosition(int id)
        {
            var crewPos = _crewPlanningRepo.GetCrewPosition(id);
            if (crewPos == null)
                throw new appException("Crew Position does not exist.");
            crewPos.isDeleted = true;
            _crewPlanningRepo.UpdateCrewPosition(crewPos);
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
        public CrewPositionDTO GetCrewPosition(int id)
        {
            var crewPos = _crewPlanningRepo.GetCrewPosition(id);
            return _mapper.Map<CrewPositionDTO>(crewPos);
        }
        public IEnumerable<CrewPositionDTO> GetAllCrewPosition()
        {
            var crewPos = _crewPlanningRepo.GetAllCrewPosition();
            return _mapper.Map<IEnumerable<CrewPositionDTO>>(crewPos);
        }
        public void UpdateCrewPosition(CrewPositionDTO_Edit obj)
        {
            var crewPos = _crewPlanningRepo.GetCrewPosition(obj.Id);
            if (crewPos == null)
                throw new appException("Crew Position not found.");
            try
            {
                crewPos.PositionName = obj.PositionName ?? crewPos.PositionName;
                crewPos.PositionType = obj.PositionType;

                crewPos.UpdatedDate = DateTime.UtcNow;
                crewPos.UpdatedBy = obj.UpdatedBy;

                _crewPlanningRepo.UpdateCrewPosition(crewPos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region Crew
        public CrewDTO CreateCrew(CrewDTO_Edit obj)
        {
            var crew = _mapper.Map<Crew>(obj);
            crew.CreatedDate = DateTime.UtcNow;
            crew.UpdatedDate = crew.CreatedDate;
            crew.isDeleted = false;
            _crewPlanningRepo.CreateCrew(crew);

            try
            {
                _context.SaveChanges();
                return _mapper.Map<CrewDTO>(crew);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void DeleteCrew(int id)
        {
            var crew = _crewPlanningRepo.GetCrew(id);
            if (crew == null)
                throw new appException("Crew does not exist.");
            crew.isDeleted = true;
            _crewPlanningRepo.UpdateCrew(crew);
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
        public CrewDTO GetCrew(int id)
        {
            var crew = _crewPlanningRepo.GetCrew(id);
            return _mapper.Map<CrewDTO>(crew);
        }
        public IEnumerable<CrewDTO> GetAllCrew()
        {
            var crewPos = _crewPlanningRepo.GetAllCrew();
            return _mapper.Map<IEnumerable<CrewDTO>>(crewPos);
        }
        public IEnumerable<CrewDTO> GetAllCrew_ByCrewPos(int id)
        {
          
            var crew = _crewPlanningRepo.GetAllCrew_ByCrewPos(id);
            return _mapper.Map<IEnumerable<CrewDTO>>(crew);
        }
        public IEnumerable<CrewDTO> GetAllCrew_ByCrewPositionType(PositionTypeEnum positionType)
        {
            var crew = _crewPlanningRepo.GetAllCrew_ByCrewPositionType(positionType);
            return _mapper.Map<IEnumerable<CrewDTO>>(crew);
        }
        public void UpdateCrew(CrewDTO_Edit obj)
        {
            var crew = _crewPlanningRepo.GetCrew(obj.Id);
            if (crew == null)
                throw new appException("Crew not found.");
            try
            {
                crew.FirstName = obj.FirstName ?? crew.FirstName;
                crew.LastName = obj.LastName ?? crew.LastName;
                crew.MiddleName = obj.MiddleName ?? crew.MiddleName;

                crew.Birthdate = obj.Birthdate;
                crew.Gender = obj.Gender ?? crew.Gender;
                crew.PassportNo = obj.PassportNo ?? crew.PassportNo;
                crew.PassportExpiryDate = obj.PassportExpiryDate;

                crew.CrewPositionID = obj.CrewPositionID > 0 ? obj.CrewPositionID : crew.CrewPositionID;

                crew.UpdatedDate = DateTime.UtcNow;
                crew.UpdatedBy = obj.UpdatedBy;

                _crewPlanningRepo.UpdateCrew(crew);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region Crew Schedule
        public CrewScheduleDTO CreateCrewSchedule(CrewScheduleDTO_Edit obj)
        {
            var crew = _mapper.Map<CrewSchedule>(obj);
            crew.CreatedDate = DateTime.UtcNow;
            crew.UpdatedDate = crew.CreatedDate;
            crew.isDeleted = false;
            _crewPlanningRepo.CreateCrewSchedule(crew);

            try
            {
                _context.SaveChanges();
                return _mapper.Map<CrewScheduleDTO>(crew);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public IEnumerable<CrewDTO> SaveCrewSchedule(List<CrewScheduleDTO_Edit> obj,int userid)
        {

            var crewSCheList = _mapper.Map<List<CrewSchedule>>(obj);
            var crewList = new List<CrewDTO>();

           
            foreach (var crew in crewSCheList)
            {
               var current_crewSched = _crewPlanningRepo.GetAllCrewSchedule_byFlightSched(crew.FlightScheduleID);
               
                foreach(var current in current_crewSched)
                {
                    _crewPlanningRepo.DeleteCrewSchedule(current);
                }
                crew.CreatedDate = DateTime.UtcNow;
                crew.UpdatedDate = crew.CreatedDate;
                crew.CreatedBy = userid;
                crew.UpdatedBy = userid;
                crew.isDeleted = false;
                _crewPlanningRepo.CreateCrewSchedule(crew);
               crewList.Add(_mapper.Map<CrewDTO>( _crewPlanningRepo.GetCrew(crew.CrewID)));
            }
            

            try
            {
                _context.SaveChanges();
                return crewList;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        public void DeleteCrewSchedule(int id)
        {
            var crewSched = _crewPlanningRepo.GetCrewSchedule(id);
            if (crewSched == null)
                throw new appException("Crew does not exist.");
            crewSched.isDeleted = true;

            _crewPlanningRepo.UpdateCrewSchedule(crewSched);
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
        public CrewScheduleDTO GetCrewSchedule(int id)
        {
            var crewSched = _crewPlanningRepo.GetCrewSchedule(id);
            return _mapper.Map<CrewScheduleDTO>(crewSched);
        }
        public IEnumerable<CrewScheduleDTO> GetAllCrewSchedule()
        {
            var crewSched = _crewPlanningRepo.GetAllCrewSchedule();
            return _mapper.Map<IEnumerable<CrewScheduleDTO>>(crewSched);
        }
        public IEnumerable<CrewScheduleDTO> GetAllCrewSchedule_withDateRange(ReportFiltersDTO obj)
        {
            var crewSched = _crewPlanningRepo.GetAllCrewSchedule_withDateRange(obj.DateFrom.ToUniversalTime(),obj.DateTo.ToUniversalTime());
            return _mapper.Map<IEnumerable<CrewScheduleDTO>>(crewSched);
        }
        public IEnumerable<CrewsAssignedDTO> NumberOfCrews(CrewsAssignedDTO obj){

            var res = _crewPlanningRepo.CrewsAssigned(obj.DateRequested.ToUniversalTime());
            if (res == null) throw new appException("No Crews Assigned to this Date.");
            List<CrewsAssignedDTO> list_crewsAssigned = new List<CrewsAssignedDTO>();
            CrewsAssignedDTO crewsAssignedDetails = new CrewsAssignedDTO();
            var lastCrewId = 0;
            foreach (var crew in res)
            {
               if(crew.CrewPositionID != 0)
                {
                    if(crew.CrewPositionID == lastCrewId)
                    {

                        crewsAssignedDetails.NumberOfAssigned += 1;

                    }
                    else
                    { 
                        if(crewsAssignedDetails.NumberOfAssigned > 0)
                            list_crewsAssigned.Add(crewsAssignedDetails);

                        crewsAssignedDetails = new CrewsAssignedDTO();
                        lastCrewId = crew.CrewPositionID;
                        CrewPositionDTO crewPosition = _mapper.Map<CrewPositionDTO>(_crewPlanningRepo.GetCrewPosition(lastCrewId));
                        crewsAssignedDetails.PositionName = crewPosition.PositionName;
                        crewsAssignedDetails.NumberOfAssigned = 1;
                        crewsAssignedDetails.PositionType = crewPosition.PositionType;
                        crewsAssignedDetails.DateRequested = obj.DateRequested.ToUniversalTime();
                    }
                }

            }
            return list_crewsAssigned;

        }
        public void UpdateCrewSchedule(CrewScheduleDTO_Edit obj)
        {
            var crewSched = _crewPlanningRepo.GetCrewSchedule(obj.ID);
            if (crewSched == null)
                throw new appException("Crew not found.");
            try
            {
                crewSched.FlightScheduleID = obj.FlightScheduleID > 0 ? obj.FlightScheduleID: crewSched.FlightScheduleID;
                crewSched.CrewID = obj.CrewID > 0 ? obj.CrewID : crewSched.CrewID;

                _crewPlanningRepo.UpdateCrewSchedule(crewSched);
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
