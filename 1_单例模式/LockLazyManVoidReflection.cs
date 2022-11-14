using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_单例模式
{
    public class LockLazyManVoidReflection
    {
        // 通过标志位来避免反射
        private static bool isReflection = true;

        private LockLazyManVoidReflection()
        {
            lock (o)
            {
                if (isReflection)
                {
                    isReflection = false;
                }
                else
                {
                    throw new Exception("不要试图破坏单例");
                }
            }
        }

        // volatile 容易改变的，不稳定的，不确定的
        // 避免指针重排
        private static volatile LockLazyManVoidReflection _lockLazyMan;

        private static object o = new object();

        public static LockLazyManVoidReflection GetLockLazyMan()
        {
            // 为了尽可能避免锁竞争，造成的资源浪费
            if (_lockLazyMan == null)
            {
                // 当加锁后，第一个线程到来，先拿到一把钥匙进入，没走出房间是不会还钥匙的，第二个线程到达后没有钥匙等待钥匙。
                // lock实际上是语法糖，内部是 Monitor.Enter() Monitor.Exit() ,本质是一个互斥锁。
                lock (o)
                {
                    if (_lockLazyMan == null)
                    {
                        // 这边是有问题的，new 做的三件事：1. 内存中开辟空间 2.执行构造函数，创建对象 3. 把空间指向我创建的对象
                        // 正常顺序是123，但是极端情况下会出现 132，导致对象指向了一段莫名其妙的空间，这种现象称之为指针重排
                        // 为了避免这个问题，在私有静态加上 volatile 关键字，避免指针重排
                        _lockLazyMan = new LockLazyManVoidReflection();
                        Console.WriteLine($"LockLazyManVoidReflection is created by {Thread.CurrentThread.ManagedThreadId}");
                    }
                }
            }
            
            return _lockLazyMan;
        }
    }
}
