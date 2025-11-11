using PayrollSystem.CallenderSystem;

namespace PayrollSystem
{
    public class PayCheck
    {
        private Shift[] ShiftsWorked;

        //Default Constructor
        public PayCheck()
        {
            ShiftsWorked = new Shift[] { };
        }
    }
}

// How can i make it so that this can only exist if it is tied to a specific employee.PayHistory?