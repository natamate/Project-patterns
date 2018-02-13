using ACLDatabase.Model;
using ACLDatabase.UI;

namespace ACLDatabase.Company
{
    public class CompanyController<T> where T : ModelContext
    {
        private IView _view;
        private T _context;

        public CompanyController(IView view, T context)
        {
            _view = view;
            _context = context;
        }

        public void SetView(IView view)
        {
            _view = view;
        }

        public void SetModel(T context)
        {
            _context = context;
        }

        //if return 0 if ok, return 1 when exit
        public int DisplayFinancyFromEmployerView()
        {
            var myAuthFactory = new AuthFactory<T>();
            _view.ClearView();
            _view.DrawGreetings();
            //From UI make a choice for type connection
            var type = _view.GetTypeOfConnection();
            if (type == "exit")
                return 1;

            //Get type of IAuthentication by Factory
            //1. Normal
            //2. Aspect
            var myAuth = myAuthFactory.GetAuthentication(type);

            //From UI make a choice for user
            //TODO make real choise
            var user = _view.GetUser();

            //Authenticate user
            myAuth.Authenticate(user,_context);

            //Display data on the screen
            _view.DrawTable();

            return 0;
        }

    }
}