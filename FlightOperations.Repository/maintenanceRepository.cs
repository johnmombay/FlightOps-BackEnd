using FlightOperations.Model;
using FlightOperations.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Repository
{
    public interface ImaintenanceRepository
    {
        void CreateCountry(Country obj);
        void DeleteCountry(Country obj);
        IEnumerable<Country> GetAllCountries();
        Country GetCountry(int id);
        void UpdateCountry(Country obj);

        void CreateCity(City obj);
        void DeleteCity(City obj);
        IEnumerable<City> GetAllCities();
        City GetCity(int id);
        void UpdateCity(City obj);

        void CreateUser(User obj);
        void DeleteUser(User obj);
        IEnumerable<User> GetAllUser();
        User GetUser(int id);
        void UpdateUser(User obj);
    }
    public class maintenanceRepository:ImaintenanceRepository
    {
        FlightOperationsContext _context;
        public maintenanceRepository(FlightOperationsContext foContext)
        {
            _context = foContext;
        }
        #region Country
        public void CreateCountry(Country obj)
        {
            _context.Countries.Add(obj);
        }
        public void DeleteCountry(Country obj)
        {
            _context.Countries.Remove(obj);
        }
        public IEnumerable<Country> GetAllCountries()
        {
            var x= _context.Countries
                .Include(c => c.Cities)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public Country GetCountry(int id)
        {
            var x= _context.Countries
                .Include(c => c.Cities)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateCountry(Country obj)
        {
            _context.Countries.Update(obj);
        }
        #endregion

        #region City
        public void CreateCity(City obj)
        {
            _context.Cities.Add(obj);
        }
        public void DeleteCity(City obj)
        {
            _context.Cities.Remove(obj);
        }
        public IEnumerable<City> GetAllCities()
        {
            var x = _context.Cities
                .Include(c => c.Country)
                .Where(p => p.isDeleted == false);
            return x;
        }
        public City GetCity(int id)
        {
            var x = _context.Cities
                .Include(c => c.Country)
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public void UpdateCity(City obj)
        {
            _context.Cities.Update(obj);
        }
        #endregion

        #region User
        public void CreateUser(User obj)
        {
            _context.Users.Add(obj);
        }
        public void DeleteUser(User obj)
        {
            _context.Users.Remove(obj);
        }
        public IEnumerable<User> GetAllUser()
        {
            var x = _context.Users
                .Where(p => p.isDeleted == false);
            return x;
        }
        public User GetUser(int id)
        {
            var x = _context.Users
                .Where(p => p.isDeleted == false && p.Id == id).FirstOrDefault();
            return x;
        }
        public User GetUser_ByUsername(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public void UpdateUser(User obj)
        {
            _context.Users.Update(obj);
        }
        #endregion
    }
}
