using PayrollSystem.CallenderSystem;

namespace PayrollSystem
{
    public class PayCheck
    {
        private Shift[] ShiftsWorked;
        public float Rate { get; set; }

        //Default Constructor
        public PayCheck(float rate)
        {
            ShiftsWorked = new Shift[] { };
            Rate = rate;
        }
    }
}

// How can i make it so that this can only exist if it is tied to a specific employee.PayHistory?