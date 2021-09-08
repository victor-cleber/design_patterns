using System;

namespace Company.Fleet.Infra.Singleton
{
    public class SingletonContainer
    {
        public Guid Id {get;} = Guid.NewGuid();
    }
}
