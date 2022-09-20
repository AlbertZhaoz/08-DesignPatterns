using _8._2_简单工厂.Interfaces;

namespace _8._2_简单工厂.Services
{
    // 蛮族
    public class ORC:IRace
    {
        public void ShowKing()
        {
            Console.WriteLine($"The King of {this.GetType().Name} is Grabby");
        }
    }
}