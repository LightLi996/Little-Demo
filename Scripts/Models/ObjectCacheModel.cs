using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectCache
{
    void Construct();
    void Destruct();
}

public class ObjectCacheModel : IModel
{
    private Dictionary<string, IObjectCache> _dictObjectCache = new Dictionary<string, IObjectCache>();

    public void Construct()
    {
        
    }

    public void Dispose()
    {
        foreach (var cache in _dictObjectCache.Values)
        {
            cache.Destruct();
        }

        _dictObjectCache.Clear();
    }

    public T GetObjectCache<T>() where T : IObjectCache
    {
        IObjectCache oc;
        if (_dictObjectCache.TryGetValue(typeof(T).ToString(), out oc))
        {
            return (T) oc;
        }
        else
        {
            oc = GenObjectCache<T>();
            return (T) oc;
        }
    }

    private T GenObjectCache<T>() where T : IObjectCache
    {
        T oc = Activator.CreateInstance<T>();
        oc.Construct();
        _dictObjectCache.Add(typeof(T).ToString(), oc);
        return oc;
    }
}
