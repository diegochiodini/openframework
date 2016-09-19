using Game.Abstractions;
using Game.Extentions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class Locator : MonoBehaviour
{
    private static Locator _instance;

    [SerializeField]
    private ScriptableObject[] _assets = null;

    private void Awake()
    {
        _instance = this;
    }

    public static T Get<T>() where T : Component
    {
        T result = _instance.GetComponent<T>();
        Assert.IsNotNull(result);
        return result;
    }

    public static T GetInterface<T>() where T : IGameInterface
    {
        return _instance.gameObject.GetInterface<T>();
    }

    public static T GetModel<T>() where T : IModel
    {
        return GetModels<T>().FirstOrDefault();
    }

    public static IEnumerable<T> GetModels<T>() where T : IModel
    {
        if (_instance._assets == null || _instance._assets.Length == 0)
        {
            throw new System.Exception("Asset not initialised in Locator");
        }

        IEnumerable<T> results = _instance._assets.OfType<T>();
        if (results == null || !results.Any())
        {
            throw new System.Exception("Locator can't find type of: " + typeof(T).Name);
        }

        return results;
    }
}