using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_单例模式
{
    // 为什么要单例模式？ 节省资源
    // 什么叫单例模式：有且只有唯一一个对象（痴情设计模式）
    // 如何保证唯一?
    // 1. 构造函数私有化，则无法在外部 new 对象了
    // 2. 那如何给外部传递这个对象呢？在内部通过静态字段来 new 对象
    // 饿汉式单例模式，在程序创建时，便将食物做好，递给饿汉（反正也不管他饿不饿，先做好再说）
    public class HungryMan
    {
        private HungryMan(){}

        // new 做了三件事：
        // 1. 在内存中开辟一块空间
        // 2.执行构造函数并创建对象
        // 3.把空间指向创建的对象

        private static readonly HungryMan _hungryMan = new HungryMan();

        public static HungryMan GetHungryMan()
        {
            return _hungryMan;
        }
    }
}
