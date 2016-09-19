using Game.Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Extentions
{
    public static class GameObjectExtensions
    {
        public static T GetInterface<T>(this GameObject sourceObject) where T : IGameInterface
        {
            return GetInterfaces<T>(sourceObject).FirstOrDefault();
        }

        public static IEnumerable<T> GetInterfaces<T>(this GameObject sourceObject) where T : IGameInterface
        {
            IEnumerable<T> results = sourceObject.GetComponents<Component>().OfType<T>();
            if (results == null || !results.Any())
            {
                throw new System.Exception(sourceObject.name + " can't find type of: " + typeof(T).Name);
            }
            return results;
        }
    } 
}