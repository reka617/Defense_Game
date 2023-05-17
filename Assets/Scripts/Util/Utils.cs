using Newtonsoft.Json;
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

    public class GenericSingleton<T> where T : MonoBehaviour
    {
        private static T _instance;
        public static T getInstance()
        {
            if (_instance == null)
            {
                GameObject temp = new GameObject();
                _instance = temp.AddComponent<T>();
                Object.DontDestroyOnLoad(temp);
            }
            return _instance;
        }
    }
}


