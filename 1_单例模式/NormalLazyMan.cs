using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_单例模式
{
    public class NormalLazyMan
    {
        private NormalLazyMan(){}

        private static NormalLazyMan _normalLazyMan;

        public static NormalLazyMan GetNormalLazyMan()
        {
            // 判断是否为空？如果为空则 new 一个，这样就不会在程序启动时直接在内存中开辟额外空间，调用才开
            // 但是这个方法存在多线程竞争的问题
            if (_normalLazyMan == null)
            {
                _normalLazyMan = new NormalLazyMan();
                Console.WriteLine($"LazyMan is created by {Thread.CurrentThread.ManagedThreadId}");
            }

            return _normalLazyMan;
        }
    }
}
