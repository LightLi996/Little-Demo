using Framework.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    internal static class Singleton
    {
        private static Dictionary<string, IManager> _dictMgrPool = new Dictionary<string, IManager>();
        private static Dictionary<string, IModel> _dictModelPool = new Dictionary<string, IModel>();

        public static T GetManager<T>() where T : IManager
        {
            IManager manager;
            if (!_dictMgrPool.TryGetValue(typeof(T).Name, out manager))
            {
                manager = SetManager<T>();
            }

            return (T) manager;
        }


        public static T GetModel<T>() where T : IModel
        {
            IModel model;
            if (!_dictModelPool.TryGetValue(typeof(T).Name, out model))
            {
                model = SetModel<T>();
            }

            return (T) model;
        }


        public static void ReleaseManager<T>() where T : IManager
        {
            IManager manager;
            string name = typeof(T).Name;
            if (_dictMgrPool.TryGetValue(name, out manager))
            {
                _dictMgrPool.Remove(name);
            }
        }


        public static void ReleaseModel<T>() where T : IModel
        {
            IModel model;
            string name = typeof(T).Name;
            if (_dictModelPool.TryGetValue(name, out model))
            {
                _dictModelPool.Remove(name);
            }
        }


        private static T SetManager<T>() where T : IManager
        {
            string name = typeof(T).Name;
            GameObject go = GameObject.Instantiate(Resources.Load(GameMain.MANAGER_PATH + name)) as GameObject;
            T mgr = go.GetComponent<T>();
            _dictMgrPool.Add(name, mgr);
            return mgr;
        }


        private static T SetModel<T>() where T : IModel
        {
            T model = Activator.CreateInstance<T>();
            model.Construct();
            _dictModelPool.Add(typeof(T).Name, model);
            return model;
        }

    }


    internal static class SingleManager<T> where T : IManager
    {
        private static T _instance;
        private static bool _isCreated = false;

        public static T Get()
        {
            if (!_isCreated)
            {
                _instance = Singleton.GetManager<T>();
                _isCreated = true;
            }

            return _instance;
        }

        public static void Destroy()
        {
            Singleton.ReleaseManager<T>();
            _isCreated = false;
            _instance.Dispose();
        }
    }


    internal static class SingleModel<T> where T : IModel
    {
        private static T _instance;
        private static bool _isCreated = false;

        public static T Get()
        {
            if (!_isCreated)
            {
                _instance = Singleton.GetModel<T>();
                _isCreated = true;
            }

            return _instance;
        }

        public static void Destroy()
        {
            Singleton.ReleaseModel<T>();
            _isCreated = false;
            _instance.Dispose();
        }
    }
}

