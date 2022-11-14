namespace _1_单例模式
{
    public class CSharpLazySample
    {
        private CSharpLazySample() { }

        private static readonly Lazy<CSharpLazySample> Lazy = new Lazy<CSharpLazySample>(() => new CSharpLazySample());

        public CSharpLazySample GetCSharpLazySample()
        {
            return Lazy.Value;
        }
    }
}
