using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager 
{
    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();

    int _summonCount = 5;
    public int SummonCount { get { return _summonCount; } } // 스테이지 클리어 여부를 확인하기 위한 속성, 소환 횟수와 죽었을 때 카운트와 비교하기 위해서 
   
    
    Transform _root;

    public void temp()
    {
        //스테이지별 소환 횟수 입력받아서 소환활 수 있도록 _summonCount에 넣어줌
    }


    public void Init()
    {
        if(_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void CreatePool(GameObject original, int count = 5)
    {
        Pool pool = new Pool();
        pool.Init(original, count);
        pool.Root.parent = _root;

        _pool.Add(original.name, pool);
    }

    public void Push(Poolable poolable)
    {
        string name = poolable.gameObject.name;
        if(_pool.ContainsKey(name) == false) //없다면 풀에 넣지 않고 오브젝트를 파괴함(예외처리)
        {
            GameObject.Destroy(poolable.gameObject);
        }
        _pool[name].Push(poolable);
    }

    public Poolable Pop(GameObject original, Transform parent = null)
    {
        if (_pool.ContainsKey(original.name) == false)
            CreatePool(original);

        return _pool[original.name].Pop(parent);
    }

    public GameObject GetOriginal(string name)
    {
        if (_pool.ContainsKey(name) == false)
            return null;
        return _pool[name].Original;
    }

    public void Clear()
    {
        foreach(Transform child in _root)
        {
            GameObject.Destroy(child.gameObject);
        }

        _pool.Clear();
    }
}

class Pool
{
    public GameObject Original { get; private set; }
    public Transform Root { get; set; }

    public Stack<Poolable> _poolStack = new Stack<Poolable>();

    public void Init(GameObject original, int count)
    {
        Original = original;
        Root = new GameObject().transform;
        Root.name = $"{original.name}_Root";

        for (int i = 0; i < count; i++)
        {
            Push(Create());
        }
    }

    Poolable Create()
    {
        GameObject go = Object.Instantiate<GameObject>(Original);
        go.name = Original.name;
        return go.GetOrAddComponent<Poolable>();
    }

    public void Push(Poolable poolable)
    {
        if (poolable == null)
            return;

        poolable.transform.parent = Root;
        poolable.gameObject.SetActive(false);
        poolable.IsUsing = false;

        _poolStack.Push(poolable);
    }

    public Poolable Pop(Transform parent)
    {
        Poolable poolable;
        if (_poolStack.Count > 0)
            poolable = _poolStack.Pop();
        else
            poolable = Create();

        poolable.gameObject.SetActive(true);

        if (parent == null) // DontDestroyOnLoad로 인해 내려가있는 오브젝트들을 빼내기 위해 만든 코드
            poolable.transform.parent = Camera.main.transform;

        poolable.transform.parent = parent;
        poolable.IsUsing = true;

        return poolable;
    }


}
