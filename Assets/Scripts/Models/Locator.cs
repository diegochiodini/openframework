using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Locator : MonoBehaviour
{
    private static Locator _instance;

    [SerializeField]
    private ScriptableObject[] _assets = null;

    private void Awake()
    {
        _instance = this;
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