using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2_三大工厂.工厂方法设计模式
{
    public interface IHuman
    {
        void GetColor();
        void Talk();
    }

    [TypeNameToInstance("Black")]
    public class BlackHuman : IHuman
    {
        public void GetColor()
        {
            Console.WriteLine("Black");
        }

        public void Talk()
        {
            Console.WriteLine("Black Language");
        }
    }

    [TypeNameToInstance("Yellow")]
    public class YellowHuman : IHuman
    {
        public void GetColor()
        {
            Console.WriteLine("Yellow");
        }

        public void Talk()
        {
            Console.WriteLine("Yellow Language");
        }
    }

    [TypeNameToInstance("White")]
    public class WhiteHuman : IHuman
    {
        public void GetColor()
        {
            Console.WriteLine("White");
        }

        public void Talk()
        {
            Console.WriteLine("White Language");
        }
    }
}
