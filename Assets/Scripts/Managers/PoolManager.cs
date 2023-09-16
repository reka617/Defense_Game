using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager 
{
    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();

    int _summonCount = 5;
    public int SummonCount { get { return _summonCount; } } // �������� Ŭ���� ���θ� Ȯ���ϱ� ���� �Ӽ�, ��ȯ Ƚ���� �׾��� �� ī��Ʈ�� ���ϱ� ���ؼ� 
   
    
    Transform _root;

    public void temp()
    {
        //���������� ��ȯ Ƚ�� �Է¹޾Ƽ� ��ȯȰ �� �ֵ��� _summonCount�� �־���
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
        if(_pool.ContainsKey(name) == false) //���ٸ� Ǯ�� ���� �ʰ� ������Ʈ�� �ı���(����ó��)
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

        if (parent == null) // DontDestroyOnLoad�� ���� �������ִ� ������Ʈ���� ������ ���� ���� �ڵ�
            poolable.transform.parent = Camera.main.transform;

        poolable.transform.parent = parent;
        poolable.IsUsing = true;

        return poolable;
    }


}
