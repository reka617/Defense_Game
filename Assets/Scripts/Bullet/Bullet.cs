using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    BulletBase _BB;
    Rigidbody _rig;
    GameController _GC;
    bool isCollision = false;
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
        BulletRemove();
        if (!isCollision)
        {
            BulletMove();
        }
        else
        {
            _rig.AddForce(Vector3.zero);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Student")
        {
            isCollision = true;
            _bulletDamage = gameObject.GetComponent<BulletDamage>().ProjectileDamage;
            gameObject.transform.position = Vector3.zero;
            Debug.Log(gameObject);
            Destroy(gameObject);
        }
    }
}
