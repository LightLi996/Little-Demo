using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDispose
{
    void UpdateExc();
    void Dispose();
}


public class GameMain : MonoBehaviour
{
    private static readonly string MANAGER_PATH = "Managers/";
    public static readonly string BLUE_BLOCK_PATH = "Characters/Snakes/Blue/";

    private Dictionary<string, IDispose> _dictMgrPool;

    private bool _inited = false;

    void Awake()
    {
        _dictMgrPool = new Dictionary<string, IDispose>();

        LoadManager<SnakeManager>("SnakeManager");

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


    public T GetManager<T>(string mgrName) where T : IDispose
    {
        IDispose mgr;
        if(_dictMgrPool.TryGetValue(mgrName, out mgr) == false)
        {
            mgr = LoadManager<T>(mgrName);
        }

        return (T)mgr;
    }


    private T LoadManager<T>(string mgrName) where T : IDispose
    {
        GameObject go = Instantiate(Resources.Load(MANAGER_PATH + mgrName)) as GameObject;
        T mgr = go.GetComponent<T>();
        _dictMgrPool.Add(mgrName, mgr);
        return mgr;
    }
     

}
