using System.Collections.Generic;
using System.Data;
using lab3.Models;
using Npgsql;
using System.Linq;
using System.Linq.Expressions;

namespace lab3.Database.DAO
{
    internal class PersonDAO : DAO<Person>
    {
        public PersonDAO(Context db) : base(db) { }

        public override void Create(Person entity)
        {
            context.Person.Add(entity);
            context.SaveChanges();
        }

        public override Person Get(long id)
        {
            var query = from person in context.Person
                where person.Id == id
                select person;
            return query.First();
        }

        public override List<Person> Get(int page)
        {
            var query = from person in context.Person
                select person;
            return query.Skip(page * 10).Take(10).ToList();
        }

        public override void Update(Person entity)
        {
            var upd = context.Person.Single(x => x.Id == entity.Id);
           
            upd.Address = entity.Address;
            upd.Name = entity.Name;
            upd.Phone = entity.Phone;
            upd.Car = entity.Car;

            context.SaveChanges();
        }

        public override void Delete(long id)
        {
            context.Person.Remove(context.Person.Single(x => x.Id == id));
            context.SaveChanges();
        }

        public Person Search(string str)
        {
            var query = from person in context.Person
                where person.Name == str
                select person;
            return query.First();
        }
    }
}