using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class State
    {
        public virtual void OnEnter() { }
        public virtual void MainLoop() { }
    }

    public class ReadJson
    {
        public static T LoadJson<T>(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            return JsonUtility.FromJson<T>(textAsset.text);
        }

        public static T LoadJsonList<T>(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            return JsonConvert.DeserializeObject<T>(textAsset.text);
        }

        public static Dictionary<T, T2> LoadJsonDict<T, T2>(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            return JsonConvert.DeserializeObject<Dictionary<T, T2>>(textAsset.text);
        }
    }
}

    
