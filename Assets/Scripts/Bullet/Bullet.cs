using UnityEngine;
using Utils;

public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    BulletBase _BB;
    [SerializeField] float bulletSpeed;

    private void Update()
    {

    }

    public void Init(BulletBase BB)
    {
        _BB = BB;
    }


    public void BulletMove(Vector3 target)
    {
        _dir = (target - transform.position).normalized;
        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }

}
