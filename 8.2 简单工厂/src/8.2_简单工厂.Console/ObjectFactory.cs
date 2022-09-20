using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _8._2_简单工厂.Interfaces;
using _8._2_简单工厂.Services;
using Microsoft.Extensions.Configuration;

namespace _8._2_简单工厂.Console
{
    /// <summary>
    /// GOF 23种设计模式里面不包含简单工厂
    /// 简单工厂：包含一组需要创建的对象，通过一个工厂类来实例化对象
    /// 好处：去掉上端对细节的依赖，保证上端的稳定
    /// 缺陷：没有消除依赖，只是转移了依赖，甚至还集中了依赖
    /// </summary>
    public class ObjectFactory
    {
        public static IRace CreateInstance(RaceType raceType)
        {
            IRace race = null;
            switch (raceType)
            {
                case RaceType.Human:
                    race = new Human();
                    break;
                case RaceType.NE:
                    race = new NE();
                    break;
                case RaceType.ORC:
                    race = new ORC();
                    break;
                case RaceType.Undead:
                    race = new Undead();
                    break;
                default:
                    throw new Exception("Wrong racetype");
            }
            return race;
        }

        // Factory+配置文件
        public static IRace CreateInstanceConfig()
        {
            // 配置文件
            // 安装 Microsoft.Extensions.Configuration
            // Microsoft.Extensions.Configuration.Json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", true, true)
                .Build();

            // 反射
            Assembly assembly = Assembly.Load(configuration["ReflectionDll"]);
            // Why reflect need full type name?
            // https://stackoverflow.com/questions/52337361/why-do-i-have-to-specify-the-namespace-in-the-parameter-for-assembly-gettype
            Type type = assembly.GetTypes().SingleOrDefault(t => t.Name == configuration["IRace"]);
            return (IRace)Activator.CreateInstance(type);
        }
    }

    public enum RaceType{
        Human,
        NE,
        ORC,
        Undead
    }
}
