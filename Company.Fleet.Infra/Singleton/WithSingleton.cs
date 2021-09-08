using System;

namespace Company.Fleet.Infra.Singleton
{
    public sealed class WithSingleton
    {
        public Guid Id {get;} = Guid.NewGuid();

        private static WithSingleton instance = null;

        private WithSingleton(){}

        public static WithSingleton Instance
        {
            get {
                if (instance == null){
                    instance = new WithSingleton();
                }
                return instance;
            }
        }
    }
}
