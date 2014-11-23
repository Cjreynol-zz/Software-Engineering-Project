using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class AlterAvailabilityController
    {
        private DBConnector dbc;
        private MainController mcp;
        private AlterAvailabilityForm aaForm;

        public AlterAvailabiltyController(DBConnector dbc, MainController mcp)
        {
            this.dbc = dbc;
            this.mcp = mcp;
        }

        public void Start(User user)
        {
            aaForm = new aaForm(this);
            aaForm.PopulateData((dbc.GetAvailability(user)));
        }
        public void Submit()
        {
            if (Validate(aaForm.GetAvailability()))
                Save(aaForm.GetAvailibility());
            else
                aaForm.DisplayMessage(errorMessage);
        }
        public void Back()
        {
            aaForm.Destroy();
            mcp.DisplayMainMenu();
        }

        public bool Validate()
        {
            return true;
        }
    }
}
