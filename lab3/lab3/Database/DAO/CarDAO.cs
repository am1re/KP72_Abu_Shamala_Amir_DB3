using System.Collections.Generic;
using System.ComponentModel.Design;
using lab3.Models;
using Npgsql;
using System.Linq;

namespace lab3.Database.DAO
{
    class CarDAO : DAO<Car>
    {
        public CarDAO(Context context) : base(context) { }

        public override void Create(Car entity)
        {
            context.Car.Add(entity);
            context.SaveChanges();
        }

        public override Car Get(long id)
        {
            var query = from car in context.Car
                where car.VIN == id
                select car;
            return query.First();
        }

        public override List<Car> Get(int page)
        {
            var query = from car in context.Car
                select car;
            return query.Skip(page * 10).Take(10).ToList();
        }

        public override void Update(Car entity)
        {
            var upd = context.Car.Single(x => x.VIN == entity.VIN);
            
            upd.Model = entity.Model;
            upd.Year = entity.Year;
           
            context.SaveChanges();
        }

        public override void Delete(long id)
        {
            context.Car.Remove(context.Car.Single(x => x.VIN == id));
            context.SaveChanges();
        }

        public Car Search(string str)
        {
            var query = from car in context.Car
                where car.Model == str
                select car;
            return query.First();
        }
    }
}
