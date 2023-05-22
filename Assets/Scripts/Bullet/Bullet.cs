using UnityEngine;
using Utils;

public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    BulletBase _BB;
    BulletController _BC;
    [SerializeField] int bulletSpeed;

    private void Update()
    {
        bulletMove();
    }

    public void Init(BulletBase BB)
    {
        _BB = BB;
    }

    void bulletMove()
    {
        _dir = ( - transform.position).normalized;
        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
}
