using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    BulletBase _BB;
    Rigidbody _rig;
    GameController _GC;
    

    [SerializeField] float bulletSpeed;
    float _lifeTime = 5;

    public void Init(BulletBase BB)
    {
        _BB = BB;
    }

    public void Init(GameController GC)
    {
        _GC = GC;
    }


    public void BulletMove() //업데이트로 해줘야함
    {
        _rig = GetComponent<Rigidbody>();
        _dir = (_GC.Target.position - transform.position).normalized;
        _rig.AddForce(_dir * bulletSpeed, ForceMode.Impulse);
    }

    public void BulletRemove()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        BulletRemove();
    }

}
