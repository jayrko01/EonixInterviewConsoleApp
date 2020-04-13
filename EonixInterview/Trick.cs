namespace EonixInterview
{
    public class Trick
    {
        public string trickName { get; }
        public TrickType trickType { get; }

        public Trick(string trickName, TrickType trickType)
        {
            this.trickName = trickName;
            this.trickType = trickType;
        }
    }
}