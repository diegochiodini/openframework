using Game.Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Extentions
{
    public static class GameObjectExtensions
    {
        public static T GetInterface<T>(this GameObject inObj) where T : IGameInterface
        {
            return inObj.GetComponents<Component>().OfType<T>().FirstOrDefault();
        }

        public static IEnumerable<T> GetInterfaces<T>(this GameObject inObj) where T : IGameInterface
        {
            return inObj.GetComponents<Component>().OfType<T>();
        }
    } 
}