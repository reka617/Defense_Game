using UnityEngine;

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



    void getAimPosition(BulletController BC)
    {
        _BC = BC;
        _mouseAim = _BC.Aim;
    }

    void bulletMove()
    {
        _dir = (_mouseAim - transform.position).normalized;

        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
}
