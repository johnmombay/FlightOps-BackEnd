using AutoMapper;
using FlightOperations.Model;
using FlightOperations.Model.DTO;
using FlightOperations.Model.Entity;
using FlightOperations.Repository;
using FlightOperations.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightOperations.Services
{
    public interface ImaintenanceServices
    {
        CountryDTO CreateCountry(CountryDTO_edit obj);
        void DeleteCountry(int id);
        CountryDTO GetCountry(int id);
        IEnumerable<CountryDTO> GetAllCountry();
        void UpdateCountry(CountryDTO_edit obj);

        CityDTO CreateCity(CityDTO obj);
        void DeleteCity(int id);
        CityDTO GetCity(int id);
        IEnumerable<CityDTO> GetAllCity();
        void UpdateCity(CityDTO obj);

        UserDTO Authenticate(string username, string password);
        UserDTO CreateUser(UserDTO obj);
        void DeleteUser(int id);
        IEnumerable<UserDTO> GetAllUser();
        UserDTO GetUser(int id);
        void UpdateUser(UserDTO obj);
    }
    public class maintenanceServices:ImaintenanceServices
    {
        private FlightOperationsContext _context;
        private IMapper _mapper;
        private maintenanceRepository _maintenanceRepo;

        public maintenanceServices(FlightOperationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _maintenanceRepo = new maintenanceRepository(_context);
        }
        #region Country
        public CountryDTO CreateCountry(CountryDTO_edit obj)
        {
            var country = _mapper.Map<Country>(obj);

            country.CreatedDate = DateTime.UtcNow;
            country.UpdatedDate = country.CreatedDate;

            country.isDeleted = false;
            _maintenanceRepo.CreateCountry(country);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
            return _mapper.Map<CountryDTO>(country);
        }
        public void DeleteCountry(int id)
        {
            var country = _maintenanceRepo.GetCountry(id);
            if (country != null)
            {
                country.isDeleted = true;
                _maintenanceRepo.UpdateCountry(country);
                _context.SaveChanges();
            }
        }
        public CountryDTO GetCountry(int id)
        {
            var country = _maintenanceRepo.GetCountry(id);
            return _mapper.Map<CountryDTO>(country);
        }
        public IEnumerable<CountryDTO> GetAllCountry()
        {
            var country = _maintenanceRepo.GetAllCountries();
            return _mapper.Map<IEnumerable<CountryDTO>>(country);
        }
        public void UpdateCountry(CountryDTO_edit obj)
        {
            var country = _maintenanceRepo.GetCountry(obj.Id);
            if (country == null)
                throw new appException("No country found.");
            try
            {
                country.CountryCode = obj.CountryCode ?? country.CountryCode;
            country.CountryName = obj.CountryName ?? country.CountryName;
            country.Region = obj.Region ?? country.Region;

            country.UpdatedDate = DateTime.UtcNow;
            country.UpdatedBy = obj.UpdatedBy;

            /*
            foreach(var cities in country.Cities)
            {
                var exist = obj.Cities.Where(p => p.Id == cities.Id).ToList();
                if (exist.Count <= 0)
                {
                    _context.Cities.Remove(cities);
                }

            }
            foreach(var cities in obj.Cities)
            {
                var item = _maintenanceRepo.GetCity(cities.Id);
                if(item == null)
                {
                    item = new City();
                    item.CreatedBy = obj.CreatedBy;
                    item.CreatedDate = DateTime.Now;
                }
                item.UpdatedBy = obj.UpdatedBy;
                item.UpdatedDate = DateTime.Now;
                item.CityCode = cities.CityCode;
                item.CityName = cities.CityName;
                item.CountryId = cities.CountryId;


                if (item.Id <= 0)
                {
                    _maintenanceRepo.CreateCity(item);
                }
                else
                {
                    _maintenanceRepo.CreateCity(item);
                }

            }
            */

            _maintenanceRepo.UpdateCountry(country);
          
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region City
        public CityDTO CreateCity(CityDTO obj)
        {
            var city = _mapper.Map<City>(obj);

            city.CreatedDate = DateTime.UtcNow;
            city.UpdatedDate = city.CreatedDate;
            city.isDeleted = false;
            _maintenanceRepo.CreateCity(city);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
            return _mapper.Map<CityDTO>(city);
        }
        public void DeleteCity(int id)
        {
            var city = _maintenanceRepo.GetCity(id);
            if (city == null) 
                    throw new appException("No city found.");
            city.isDeleted = true;
            _maintenanceRepo.UpdateCity(city);

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
        public CityDTO GetCity(int id)
        {
            var city = _maintenanceRepo.GetCity(id);
            return _mapper.Map<CityDTO>(city);
        }
        public IEnumerable<CityDTO> GetAllCity()
        {
            var city = _maintenanceRepo.GetAllCities();
            return _mapper.Map<IEnumerable<CityDTO>>(city);
        }
        public void UpdateCity(CityDTO obj)
        {
             var city = _maintenanceRepo.GetCity(obj.Id);
            if (city == null)
                throw new appException("No city found.");
            try
            {
                city.CityCode = obj.CityCode ?? city.CityCode;
            city.CityName = obj.CityName ?? city.CityName;
            city.UpdatedDate = DateTime.UtcNow;
            city.UpdatedBy = obj.UpdatedBy;
            _maintenanceRepo.UpdateCity(city);

           
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion
        #region User
        public UserDTO Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _maintenanceRepo.GetUser_ByUsername(username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO CreateUser(UserDTO obj)
        {
            var user = _mapper.Map<User>(obj);

            user.CreatedDate = DateTime.UtcNow;
            user.UpdatedDate = user.CreatedDate;
            user.isDeleted = false;

            // validation
            if (string.IsNullOrWhiteSpace(obj.Password))
                throw new appException("Password is required");

            if (_context.Users.Any(x => x.Username == obj.Username))
                throw new appException("Username \"" + obj.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(obj.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _maintenanceRepo.CreateUser(user);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return _mapper.Map<UserDTO>(user);
        }
        public void DeleteUser(int id)
        {
            var user = _maintenanceRepo.GetUser(id);
            if (user == null) throw new appException("User does not exist.");

            user.isDeleted = true;
                _maintenanceRepo.UpdateUser(user);

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
        public UserDTO GetUser(int id)
        {
            var user = _maintenanceRepo.GetUser(id);
            return _mapper.Map<UserDTO>(user);
        }
        public IEnumerable<UserDTO> GetAllUser()
        {
            var user = _maintenanceRepo.GetAllUser();
            return _mapper.Map<IEnumerable<UserDTO>>(user);
        }
        public void UpdateUser(UserDTO obj)
        {
            var user = _maintenanceRepo.GetUser(obj.Id);
            if (user == null)
                throw new appException("User not found.");

            try
            {
            user.FirstName = obj.FirstName ?? user.FirstName;
            user.LastName = obj.LastName ?? user.LastName;
            
            if(user.Username != obj.Username)
            {
               if (_context.Users.Any(x => x.Username == obj.Username))
               throw new appException("Username \"" + obj.Username + "\" is already taken");
            }
            user.Username = obj.Username ?? user.Username;
            user.UserRole = obj.UserRole ?? user.UserRole;
            user.UpdatedDate = DateTime.UtcNow;
            user.UpdatedBy = obj.UpdatedBy;

             // validation
            if (!string.IsNullOrWhiteSpace(obj.Password))
            {
                if (!VerifyPasswordHash(obj.Password, user.PasswordHash, user.PasswordSalt))
                {
                   byte[] passwordHash, passwordSalt;
                   CreatePasswordHash(obj.Password, out passwordHash, out passwordSalt);

                   user.PasswordHash = passwordHash;
                   user.PasswordSalt = passwordSalt;
                }                 

            }                                 
                _maintenanceRepo.UpdateUser(user);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
        #endregion

        #region Password Hash
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        #endregion
    }
}
