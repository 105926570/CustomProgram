namespace PayrollSystem
{
    public class PayCheck
    {

        private WorkedShift[] ShiftsWorked;

        //Default Constructor
        public PayCheck() 
        {
            ShiftsWorked = new WorkedShift[] { };
        }

    }
}

// How can i make it so that this can only exist if it is tied to a specific employee.PayHistory?