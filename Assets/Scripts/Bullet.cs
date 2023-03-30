using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    EnemyController EC;

    [SerializeField]
    float bulletSpeed;

    Vector3 _aim;
    //target
    Transform _target = null;

    Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void init()
    { 
        
    }

    void bulletMove()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _aim = hit.point;
            }
        }

        _dir = (_aim - transform.position).normalized;

        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
}
