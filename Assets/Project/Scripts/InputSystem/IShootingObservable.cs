using System;

namespace Shooter
{
    public interface IShootingObservable 
    {
        event Action OnShooted;
    }
}
