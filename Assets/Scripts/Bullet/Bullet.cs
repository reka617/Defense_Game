using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    BulletBase _BB;
    Rigidbody _rig;
    GameController _GC;
    float _bulletDamage;
    

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

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        
    }

    public void BulletMove() 
    {
        _dir = (_GC.Target.position - transform.position).normalized;
        _rig.AddForce(_dir * bulletSpeed, ForceMode.Impulse);
    }

    public void BulletRemove()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        BulletMove();
        BulletRemove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Student")
        {
            _bulletDamage = gameObject.GetComponent<BulletDamage>().ProjectileDamage;
            Destroy(gameObject);
        }
    }
}
