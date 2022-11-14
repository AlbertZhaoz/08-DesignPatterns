using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_单例模式
{
    public class StaticInnerClassHungryClass
    {
        // 静态内部类只有当调用的时候才会被创建，节省了资源。
        public StaticInnerClassHungryClass GetStaticInnerClassHungryClass()
        {
            return InnerClass._staticInnerClassHungryClass;
        }

        public static class InnerClass
        {
            public static readonly StaticInnerClassHungryClass _staticInnerClassHungryClass =
                new StaticInnerClassHungryClass();
        }
    }
}
