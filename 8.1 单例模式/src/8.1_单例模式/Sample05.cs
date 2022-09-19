using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._1_单例模式
{
    /// <summary>
    /// Lazy<T> 实现实现方式--完全延时加载
    /// 饿汉式-只要用到这个类就会执行
    /// 单例实现的三个要素：
    /// 1. 私有构造函数，避免被他人错误的实例化，可以减少错误的使用和猜测而定的规则，其他的应用无法构造实例，只能自己构造返回出去。
    /// 2. 对内有一个私有的静态字段，用于赋值实例化结果
    /// 3. 对外提供一个获取实例的公开静态方法/属性
    /// </summary>
    public sealed class Sample05
    {
        private Sample05()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
            }

            Console.WriteLine("当我被构造时，才会执行");
        }

        // 由CLI保证，第一次使用这个类型之前，自动被调用且只调用一次
        private static readonly Lazy<Sample05> _sample05 = new Lazy<Sample05>(()=>new Sample05());

        public static Sample05 GetInstance()
        {
            return _sample05.Value;
        }

        public void Show()
        {
            Console.WriteLine("我是Show方法");
        }

        private int num = 0;

        public void AddNum()
        {
            num++;
        }

        public int GetNum()
        {
            return num;
        }
    }
}
