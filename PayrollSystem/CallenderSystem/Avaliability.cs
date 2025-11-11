namespace PayrollSystem.CallenderSystem
{
    public class Avaliability : TimeFrame
    {
        public bool Avaliable { get; set; }

        public Avaliability() : this(true) { } //by efaul avaliable
        public Avaliability(bool avaliability) { Avaliable = avaliability; }
    }
}
