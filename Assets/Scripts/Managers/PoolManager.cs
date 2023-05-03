using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();
    Transform _root;

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

    Stack<Poolable> _poolStack = new Stack<Poolable>();

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
