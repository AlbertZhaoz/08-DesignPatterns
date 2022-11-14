﻿
using System.Threading.Channels;
using _1_单例模式;
using BindingFlags = System.Reflection.BindingFlags;

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
//Console.WriteLine("\n懒汉枷锁避免线程竞争问题");
//for (int i = 0; i < 10; i++)
//{
//    new Thread(() => LockLazyMan.GetLockLazyMan()).Start();
//}
#endregion

#region 通过反射破坏懒汉
Console.WriteLine("\n通过反射破坏懒汉");
Type type = Type.GetType("_1_单例模式.LockLazyMan");
var constructor =  type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
var lazyManInstance1 = (LockLazyMan)constructor[0].Invoke(null);
var lazyManInstance2 = (LockLazyMan)constructor[0].Invoke(null);
Console.WriteLine(lazyManInstance1.GetHashCode());
Console.WriteLine(lazyManInstance2.GetHashCode());
#endregion

#region 通过标志位来解决反射破坏
//Console.WriteLine("\n通过标志位来解决反射破坏");
//Type typeVoidReflection = Type.GetType("_1_单例模式.LockLazyManVoidReflection");
//var constructorVoidReflection = typeVoidReflection.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
//var lazyManInstanceVoidReflection1 = (LockLazyManVoidReflection)constructorVoidReflection[0].Invoke(null);
//var lazyManInstanceVoidReflection2 = (LockLazyManVoidReflection)constructorVoidReflection[0].Invoke(null);
//Console.WriteLine(lazyManInstanceVoidReflection1.GetHashCode());
//Console.WriteLine(lazyManInstanceVoidReflection2.GetHashCode());
#endregion

#region 尝试破坏Lazy<T>

Console.WriteLine("通过反射破坏 Lazy<T>");
var typeTest = Type.GetType("_1_单例模式.CSharpLazySample");
var cons = typeTest.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
var lazyCSharpVersion1 = (CSharpLazySample)cons[0].Invoke(null);
var lazyCSharpVersion2 = (CSharpLazySample)cons[0].Invoke(null);
var lazyCSharpVersion3 = (CSharpLazySample)cons[0].Invoke(null);
Console.WriteLine(lazyCSharpVersion1.GetHashCode());
Console.WriteLine(lazyCSharpVersion2.GetHashCode());
Console.WriteLine(lazyCSharpVersion3.GetHashCode());
#endregion

