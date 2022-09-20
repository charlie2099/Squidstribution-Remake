using System;

namespace Interfaces
{
    public interface IDestructible
    {
        public Action OnDestroyed { set; get; }
    }
}