using UnityEngine;

namespace Interfaces
{
    public interface IThrowable
    {
        public void Throw();
        public void Pickup(GameObject obj);
        public void Drop();
    }
}
