using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarId = 1, BrandId = 2, ColorId = 3, ModelYear = 2012, DailyPrice= 365000, Description="Aciklama1"},
                new Car { CarId = 2, BrandId = 2, ColorId = 2, ModelYear = 2022, DailyPrice= 958000, Description="Aciklama2"},
                new Car { CarId = 3, BrandId = 4, ColorId = 1, ModelYear = 2012, DailyPrice= 452500, Description="Aciklama3"},
                new Car { CarId = 4, BrandId = 5, ColorId = 8, ModelYear = 2012, DailyPrice= 864000, Description="Aciklama4"},
                new Car { CarId = 5, BrandId = 7, ColorId = 7, ModelYear = 2012, DailyPrice= 756000, Description="Aciklama5"},
                new Car { CarId = 6, BrandId = 8, ColorId = 3, ModelYear = 2012, DailyPrice= 126000, Description="Aciklama6"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public void Remove(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }
        }
    }
}
