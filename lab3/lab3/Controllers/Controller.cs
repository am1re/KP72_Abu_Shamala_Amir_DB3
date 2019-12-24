using System;
using lab3.Database;
using lab3.Database.DAO;
using lab3.Models;
using lab3.Views;
using lab3.Views.CrudViews;

namespace lab3.Controllers
{
    class Controller
    {
        private readonly DAO<Person> _personDAO;
        private readonly DAO<Car> _carDAO;
        private readonly DAO<Accident> _accidentDAO;

        public Controller(Context context)
        {
            _personDAO = new PersonDAO(context);
            _carDAO = new CarDAO(context);
            _accidentDAO = new AccidentDAO(context);
        }

        public void Start()
        {
            StartCrud();
        }

        private void StartCrud()
        {
            while (true)
            {
                var entity = MenuView.ShowEntities();
                if (entity == Entities.None)
                    break;
                if (entity == Entities.Accident)
                    ExecuteCrud(new AccidentView(_personDAO), _accidentDAO);
                if (entity == Entities.Car)
                    ExecuteCrud(new CarView(), _carDAO);
                if (entity == Entities.Person)
                    ExecuteCrud(new PersonView(_carDAO), _personDAO);
            }
        }

        private void ExecuteCrud<T>(CrudView<T> view, DAO<T> dao)
        {
            var page = 0;
            while (true)
            {
                var com = view.Start(dao.Get(page), page);

                if (com == CrudOperations.None)
                    break;

                if (com == CrudOperations.PageLeft && page > 0)
                    page--;

                if (com == CrudOperations.PageRight)
                    page++;
                   
                if (com == CrudOperations.Create)
                    dao.Create(view.Create());

                if (com == CrudOperations.Read)
                    view.ShowReadResult(dao.Get(view.Read()));

                if (com == CrudOperations.Update)
                    dao.Update(view.Update(dao.Get(view.Read())));

                if (com == CrudOperations.Delete)
                     dao.Delete(view.Read());

                if (com == CrudOperations.Search)
                    ExecuteSearch(view, dao);

                if (com == CrudOperations.Create || com == CrudOperations.Delete || com == CrudOperations.Update) 
                    view.OperationStatusOutput(true);
            }
        }

        private void ExecuteSearch<T>(CrudView<T> view, DAO<T> dao)
        {
            var type = typeof(T);

            if (type == typeof(Accident))
            {
                var v = view as AccidentView;
                var d = dao as AccidentDAO;
                v.ShowReadResult(d.Search(v.Search()));
            }

            if (type == typeof(Person))
            {
                var v = view as PersonView;
                var d = dao as PersonDAO;
                v.ShowReadResult(d.Search(v.Search()));
            }

            if (type == typeof(Car))
            {
                var v = view as CarView;
                var d = dao as CarDAO;
                v.ShowReadResult(d.Search(v.Search()));
            }
        }
    }
}