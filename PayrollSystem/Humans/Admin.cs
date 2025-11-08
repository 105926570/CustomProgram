namespace PayrollSystem
{
    internal class Admin : Employee
    {
        private int _privliage;

        public Admin() : base()
        {
            _privliage = 2; //Privliage of an admin is level 2
        }

        public int Privliage
        {
            get { return _privliage; }
            set { _privliage = value; } //Problematic. May not be best idea to change privliage without any other security system in place.
        }
    }
}