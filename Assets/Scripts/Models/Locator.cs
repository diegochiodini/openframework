using Game.Abstractions;
using UnityEngine;
using Game.Extentions;
using UnityEngine.Assertions;

public class Locator : MonoBehaviour
{
    private static Locator _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static T Get<T>() where T :Component
    {
        T result = _instance.GetComponent<T>();
        Assert.IsNotNull(result);
        return result;
    }

    public static T GetInterface<T>() where T :IGameInterface
    {
        T result = _instance.gameObject.GetInterface<T>();
        //Assert.IsNotNull<T>(result);
        return result;
    }
}