
using System.Threading.Channels;
using _1_单例模式;

#region 饿汉式：1. 私有化构造函数 2. 创建私有只读字段=new HungryMan() 3. 通过静态方法返回私有字段实例
Console.WriteLine("饿汉式");
HungryMan hungryMan1 = HungryMan.GetHungryMan();
HungryMan hungryMan2 = HungryMan.GetHungryMan();
HungryMan hungryMan3 = HungryMan.GetHungryMan();

Console.WriteLine(hungryMan1.GetHashCode());
Console.WriteLine(hungryMan2.GetHashCode());
Console.WriteLine(hungryMan3.GetHashCode());
#endregion

#region 懒汉式：当方法被调用时候才创建
//NormalLazyMan normalLazyMan1 = NormalLazyMan.GetNormalLazyMan();
//NormalLazyMan normalLazyMan2 = NormalLazyMan.GetNormalLazyMan();
//NormalLazyMan normalLazyMan3 = NormalLazyMan.GetNormalLazyMan();

//Console.WriteLine(normalLazyMan1.GetHashCode());
//Console.WriteLine(normalLazyMan2.GetHashCode());
//Console.WriteLine(normalLazyMan3.GetHashCode());

#endregion

#region 懒汉式多线程竞争问题
Console.WriteLine("\n懒汉式多线程竞争问题");
for (int i = 0; i < 10; i++)
{
    new Thread(() => NormalLazyMan.GetNormalLazyMan()).Start();
}
#endregion

#region 懒汉枷锁避免线程竞争问题
Console.WriteLine("\n懒汉枷锁避免线程竞争问题");
for (int i = 0; i < 10; i++)
{
    new Thread(() => LockLazyMan.GetLockLazyMan()).Start();
}
#endregion

