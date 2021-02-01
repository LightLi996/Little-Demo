using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    void UpdateExc();
    void Dispose();
}

public interface IModel
{
    void Construct();
    void Dispose();
}


public class GameMain : MonoBehaviour
{
    private static readonly string MANAGER_PATH = "Managers/";
    public static readonly string BLUE_BLOCK_PATH = "Characters/Snakes/Blue/";

    //public static GameMain main;

    private Dictionary<string, IManager> _dictMgrPool;
    private Dictionary<string, IModel> _dictModelPool;

    private bool _inited = false;

    void Awake()
    {
        _dictMgrPool = new Dictionary<string, IManager>();
        _dictModelPool = new Dictionary<string, IModel>();

        LoadManager<SnakeManager>();

        ConstructModel<ObjectCacheModel>();

        _inited = true;
    }


    void Update()
    {
        if(_inited)
        {
            SnakeManager sm = GetManager<SnakeManager>("SnakeManager");
            sm.UpdateExc();
        }
    }


    public T GetManager<T>(string mgrName) where T : IManager
    {
        IManager mgr;
        if(_dictMgrPool.TryGetValue(mgrName, out mgr) == false)
        {
            mgr = LoadManager<T>();
        }

        return (T) mgr;
    }


    public T GetModel<T>() where T : IModel
    {
        IModel model;
        if (_dictModelPool.TryGetValue(typeof(T).ToString(), out model) == false)
        {
            model = ConstructModel<T>();
        }

        return (T) model;
    }


    private T LoadManager<T>() where T : IManager
    {
        string name = typeof(T).ToString();
        GameObject go = Instantiate(Resources.Load(MANAGER_PATH + name)) as GameObject;
        T mgr = go.GetComponent<T>();
        _dictMgrPool.Add(name, mgr);
        return mgr;
    }


    private T ConstructModel<T>() where T : IModel
    {
        T model = Activator.CreateInstance<T>();
        model.Construct();
        _dictModelPool.Add(typeof(T).ToString(), model);
        return model;
    }
}
