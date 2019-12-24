using System.Collections.Generic;
using lab3.Models;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace lab3.Database.DAO
{
    class AccidentDAO : DAO<Accident>
    {
        public AccidentDAO(Context context)
            : base(context) { }

        public override void Create(Accident entity)
        {
            context.Accident.Add(entity);
            context.SaveChanges();
        }

        public override Accident Get(long id)
        {
            var query = from accident in context.Accident
                where accident.Record_Number == id
                select accident;
            return query.First();
        }

        public override List<Accident> Get(int page)
        {
            var query = from accident in context.Accident
                select accident;

            return query
                .Include(m => m.Person)
                .Skip(page * 10).Take(10)
                .OrderBy(x => x.Record_Number).ToList();
        }

        public override void Update(Accident entity)
        {
            var upd = context.Accident.Single(x => x.Record_Number == entity.Record_Number);

            upd.Location = entity.Location;
            upd.Damage_Amount = entity.Damage_Amount;
            upd.Date = entity.Date;
            upd.Person = entity.Person;

            context.SaveChanges();
        }

        public override void Delete(long id)
        {
            context.Accident.Remove(context.Accident.Single(x => x.Record_Number == id));
            context.SaveChanges();
        }

        public Accident Search(string str)
        {
            var query = from accident in context.Accident
                        where accident.Location == str
                        select accident;
            return query.First();
        }
    }
}
