using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._1_单例模式
{
    /// <summary>
    /// 带锁实现 实现方式
    /// 懒汉式-当主动调用时候才会执行，其他静态方法执行不会创建
    /// 单例实现的三个要素：
    /// 1. 私有构造函数，避免被他人错误的实例化，可以减少错误的使用和猜测而定的规则，其他的应用无法构造实例，只能自己构造返回出去。
    /// 2. 对内有一个私有的静态字段，用于赋值实例化结果
    /// 3. 对外提供一个获取实例的公开静态方法/属性
    /// </summary>
    public sealed class Sample02
    {
        private Sample02()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
            }

            Console.WriteLine("当我被构造时，才会执行");
        }

        private static Sample02 _sample02 = null;
        private static readonly object _sample02Lock = new object();

        public static Sample02 GetInstance()
        {
            // 加把锁，只有一个进程能进入，当出去后第二个进程才能再次进入
            // 问题：会增加锁的性能开销
            lock (_sample02Lock)
            {
                if (_sample02 == null)
                {
                    _sample02 = new Sample02();
                }
            }

            return _sample02;
        }

        public void Show()
        {
            Console.WriteLine("我是Show方法");
        }
    }
}
