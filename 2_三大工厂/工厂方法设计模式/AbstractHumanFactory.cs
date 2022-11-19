using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2_三大工厂.工厂方法设计模式
{
    // 抽象工厂抽象类
    public abstract class AbstractHumanFactory
    {
        public abstract T CreateHuman<T>() where T:class,IHuman;
    }

    // 具体生产Human类型的工厂子类
    public class HumanFactory : AbstractHumanFactory
    {
        public override T CreateHuman<T>()
        {
            try
            {
                var human = Activator.CreateInstance(typeof(T)) as T;
                return human;
            }
            catch (Exception e)
            {
                Console.WriteLine("excep=" + e.ToString());
                return null;
            }
        }
    }

    // 简单工厂模式，又称为静态工厂模式
    public class HumanFactorySimple
    {
        //直接用 static
        public static T createHuman<T>() where T : class, IHuman
        {
            IHuman human = null;
            try
            {
                human = Activator.CreateInstance<T>() as IHuman;
            }
            catch (Exception e)
            {
                Console.WriteLine("e=" + e.ToString());
            }
            return human as T;
        }
    }

    public class TypeNameToInstance:Attribute
    {
        public string TypeName { get; } // 用于获取类型名字

        public TypeNameToInstance(string s)
        {
            this.TypeName = s;
        }
    } 

    public class ProductFactoryDelay
    {
        private static Dictionary<string, IHuman> dic = new Dictionary<string, IHuman>();

        public IHuman GetHuman(string typeName)
        {
            if (dic.ContainsKey(typeName))
            {
                return dic[typeName];
            }

            return null;
        }

        public ProductFactoryDelay()
        {
            // 1. 拿到当前正在运行的程序集
                Assembly assembly = Assembly.GetExecutingAssembly();
                // 2. 拿到所有类型，包含三大人种
                foreach (var item in assembly.GetTypes())
                {
                    // 3. 判断反射获得的类型是否实现了 IHuman 接口并且不是自身
                    if (typeof(IHuman).IsAssignableFrom(item) && !item.IsInterface)
                    {
                        // 4. 获取该类型的特性，看字典中是否包含，如果不包含则添加到字典中
                        TypeNameToInstance tNTI = item.GetCustomAttribute<TypeNameToInstance>();
                        if (!string.IsNullOrEmpty(tNTI.TypeName))
                        {
                            dic[tNTI.TypeName] = Activator.CreateInstance(item) as IHuman;
                        }
                    }
                }
        }
    }
}
