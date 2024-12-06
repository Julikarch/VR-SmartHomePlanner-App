using System;
using UnityEngine;

namespace scripst
{
    public class SpawnedObject
    {
        public SpawnedObject()
        {
        }

        public GameObject gameObject { get; set; }
        public string name { get; set; }
        public TypVonObject objectType { get; set; }

        //Blinds
        public float width { get; set; } = 0;
        public float height { get; set; } = 0;
    }

    public enum TypVonObject
    {
        LAMP,
        BLIND,
        AIRSENSOR,
        AIRPURIFIER,
        CONTROLSYSTEM,
        SPEAKER,
        AIRCONDITIONER,
        LIGHTSWITCH,
        BLINDSWITCH,
        MOTIONSENSOR,
        TV,
        COFFEE,
        NONE
    }
}

