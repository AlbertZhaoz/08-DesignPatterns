using _8._2_简单工厂.Interfaces;

namespace _8._2_简单工厂.Services
{
    // 不死族
    public class Undead : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine($"The King of {this.GetType().Name} is GoStop");
        }
    }
}