using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Models
{
    public class CacheModel<T> : MonoBehaviour where T : Object
    {
        [SerializeField]
        private T[] _assets;

        public T Get(int index)
        {
            if (_assets == null)
            {
                return null;
            }

            Assert.IsTrue(index >= 0 && index < _assets.Length);
            return _assets[index];
        }

        public int Length
        {
            get
            {
                if (_assets == null)
                {
                    return 0;
                }
                return _assets.Length;
            }
        }
    }
}