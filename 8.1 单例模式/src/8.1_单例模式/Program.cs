using _8._1_单例模式;

//for (int i = 1; i < 6; i++)
//{
//    Console.WriteLine($"即将执行获取单例方法 {i}");
//    var sample = Sample01.GetInstance();
//    sample.Show();
//}
//Console.Read();

//for (int i = 1; i < 6; i++)
//{
//    Task.Run(() =>
//    {
//        var sample = Sample01.GetInstance();
//        sample.Show();
//    });
//}
//Console.Read();

//for (int i = 1; i < 6; i++)
//{
//    Task.Run(() =>
//    {
//        var sample = Sample02.GetInstance();
//        sample.Show();
//    });
//}
//Console.Read();


// 单例无法保证多线程数据的安全性
List<Task> taskList = new List<Task>();
for (int i = 1; i < 10000; i++){
    taskList.Add(Task.Run(() =>
    {
        var sample = Sample05.GetInstance();
        sample.AddNum();
    }));
}

Task.WaitAll(taskList.ToArray());

// 全局共用一个实例，num也是一个
var sample2 = Sample05.GetInstance();
Console.WriteLine(sample2.GetNum());
Console.Read();
