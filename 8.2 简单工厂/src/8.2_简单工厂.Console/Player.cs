using _8._2_简单工厂.Interfaces;

namespace _8._2_简单工厂.Console
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Play(IRace race)
        {
            System.Console.WriteLine("*************************");
            System.Console.WriteLine($"{this.Name} is playing {race.GetType().Name}");
            race.ShowKing();
        }
    }
}
