using _8._2_简单工厂.Console;
using _8._2_简单工厂.Interfaces;
using _8._2_简单工厂.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ObjectFactory = _8._2_简单工厂.Console.ObjectFactory;

Player player = new Player()
{
    Id = 1,
    Name = "Albertzhaoz"
};

// 这边依赖了具体的细节，并不想依赖细节，但是又需要对象
// IRace race = new Human();

var race1 = ObjectFactory.CreateInstance(RaceType.Human);
player.Play(race1);

Console.WriteLine("****************************");

var race2 = ObjectFactory.CreateInstanceConfig();
player.Play(race2);


Console.Read();