using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._1_单例模式
{
    /// <summary>
    /// 普通实现方式
    /// 单例实现的三个要素：
    /// 1. 私有构造函数，避免被他人错误的实例化，可以减少错误的使用和猜测而定的规则，其他的应用无法构造实例，只能自己构造返回出去。
    /// 2. 对内有一个私有的静态字段，用于赋值实例化结果
    /// 3. 对外提供一个获取实例的公开静态方法/属性
    /// 4. 通常会写一个密封类，让其他类无法继承
    /// </summary>
    public sealed class Sample01
    {
        private Sample01()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
            }

            Console.WriteLine("当我被构造时，才会执行");
        }

        private static Sample01 _sample01 = null;

        public static Sample01 GetInstance()
        {
            if(_sample01 == null)
            {
                _sample01 = new Sample01();
            }

            return _sample01;
        }

        public void Show()
        {
            Console.WriteLine("我是Show方法");
        }
    }
}
