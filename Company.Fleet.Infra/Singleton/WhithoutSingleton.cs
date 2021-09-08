using System;

namespace Company.Fleet.Infra.Singleton
{
    public sealed class WithoutSingleton
    {
        public Guid Id {get;} = Guid.NewGuid();
    }
}
