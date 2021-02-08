using Framework.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Framework
{
    public class GameMain : MonoBehaviour
    {
        public static readonly string MANAGER_PATH = "Managers/";
        public static readonly string BLUE_BLOCK_PATH = "Characters/Snakes/Blue/";

        void Awake()
        {

        }


        void Update()
        {
            SingleManager<SnakeManager>.Get().UpdateExc();
        }

    }
}
