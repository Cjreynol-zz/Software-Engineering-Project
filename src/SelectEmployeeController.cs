using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class SelectEmployeeController
    {
        private DBConnector dbc;
        private MainController mcp;
        private SelectEmployeeForm seform;

        public SelectEmployeeController(DBConnector dbc, MainController mcp)
        {
            this.dbc = dbc;
            this.mcp = mcp;
        }

        public void Start()
        {
            seform = new SelectEmployeeForm(this);
            seform.Populate(dbc.GetEmployees());
        }

        public void Submit(User user)
        {
            seform.Destroy();
            mcp.StartAlterAvailability(user);
        }

    }
}
