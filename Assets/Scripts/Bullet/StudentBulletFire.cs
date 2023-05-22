using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBulletFire : MonoBehaviour
{

    Vector3 _aim;
    public Vector3 Aim { get { return _aim; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            _aim = hit.point;
        }
    }
}
