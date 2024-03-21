using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Services.Helpers
{
    public class autoMapperProfile :Profile
    {
        public autoMapperProfile()
        {
            CreateMap<AircraftDTO, Aircraft>();
            CreateMap<Aircraft, AircraftDTO>();

            CreateMap<AircraftDTO_edit, Aircraft>();

            CreateMap<AircraftTypeDTO, AircraftType>();
            CreateMap<AircraftType, AircraftTypeDTO>();

            CreateMap<Schedule_AircraftTypeDTO_edit, AircraftType>();

            CreateMap<AirportCategoryDTO, AirportCategory>();
            CreateMap<AirportCategory, AirportCategoryDTO>();
          
            CreateMap<AirportDTO, Airport>();
            CreateMap<Airport, AirportDTO>();

            CreateMap<AirportDTO_edit, Airport>();

            CreateMap<CityDTO, City>();
            CreateMap<City, CityDTO>();

            CreateMap<CityDTO, City>();

            CreateMap<CountryDTO, Country>();
            CreateMap<Country, CountryDTO>();

            CreateMap<CountryDTO_edit, Country>();

            CreateMap<FlightScheduleDTO, FlightSchedule>();
            CreateMap<FlightSchedule, FlightScheduleDTO>();
            
            CreateMap<RouteDTO, Route>();
            CreateMap<Route, RouteDTO>();

            CreateMap<RouteDTO_Edit, Route>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<AirlineScheduleDTO, AirlineSchedule>();
            CreateMap<AirlineSchedule, AirlineScheduleDTO>();

            CreateMap<AirlineScheduleDTO_edit, AirlineSchedule>();

            CreateMap<Schedule_AircraftTypeDTO, Schedule_AircraftType>();
            CreateMap<Schedule_AircraftType, Schedule_AircraftTypeDTO>();

            CreateMap<Schedule_AircraftTypeDTO_edit, Schedule_AircraftType>();

            CreateMap<AircraftMaintenanceDTO, AircraftMaintenance>();
            CreateMap<AircraftMaintenance, AircraftMaintenanceDTO>();

            CreateMap<AircraftMaintenanceDTO_Edit, AircraftMaintenance>();

            CreateMap<MaintenanceScheduleDTO, MaintenanceSchedule>();
            CreateMap<MaintenanceSchedule, MaintenanceScheduleDTO>();

            CreateMap<MaintenanceScheduleDTO_Edit, MaintenanceSchedule>();

            CreateMap<AircraftScheduleDTO, AircraftSchedule>();
            CreateMap<AircraftSchedule, AircraftScheduleDTO>();

            CreateMap<ScheduleResourceDTO, ScheduleResource>();
            CreateMap<ScheduleResource, ScheduleResourceDTO>();

            CreateMap<CrewPositionDTO, CrewPosition>();
            CreateMap<CrewPosition, CrewPositionDTO>();

            CreateMap<CrewPositionDTO_Edit, CrewPosition>();

            CreateMap<CrewDTO, Crew>();
            CreateMap<Crew, CrewDTO>();

            CreateMap<CrewDTO_Edit, Crew>();
            CreateMap<Crew, CrewDTO_Edit>();

            CreateMap<CrewScheduleDTO, CrewSchedule>();
            CreateMap<CrewSchedule, CrewScheduleDTO>();

            CreateMap<CrewScheduleDTO_Edit, CrewSchedule>();
        }
    }
}
