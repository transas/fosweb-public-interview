namespace Transas.Examples.GetHashCode
{
    public class Test1
    {
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return new Random().Next(1000);
        }
    }

    public class Test2
    {
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return 1000;
        }
    }
}
