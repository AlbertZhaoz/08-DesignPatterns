
using _2_三大工厂.工厂方法设计模式;

var humanFactory = new HumanFactory();

Console.WriteLine("造出黑人");
var blackHuman = humanFactory.CreateHuman<BlackHuman>();
blackHuman.GetColor();
blackHuman.Talk();

Console.WriteLine("造出白人");
var whiteHuman = humanFactory.CreateHuman<WhiteHuman>();
whiteHuman.GetColor();
whiteHuman.Talk();

Console.WriteLine("造出黄人");
var yellowHuman = humanFactory.CreateHuman<YellowHuman>();
yellowHuman.GetColor();
yellowHuman.Talk();

Console.WriteLine("我是延迟加载");
ProductFactoryDelay pro = new ProductFactoryDelay();
var human = pro.GetHuman("Yellow");
human.GetColor();
human.Talk();

Console.WriteLine("简单工厂设计模式");
var yellowHumanSimple = HumanFactorySimple.createHuman<YellowHuman>();
yellowHumanSimple.GetColor();
