namespace PayrollSystem
{
    internal class Admin : Employee
    {
        public Admin() : base()
        {
            Privliage = 2; //Privliage of an admin is allways level 2
        }
    }
}