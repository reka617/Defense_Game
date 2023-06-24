using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    BulletBase _BB;
    Rigidbody _rig;
    Student _ST;
    bool isCollision = false;
    float _bulletDamage;
    

    [SerializeField] float bulletSpeed;
    float _lifeTime = 5;

    public void Init(BulletBase BB)
    {
        _BB = BB;
    }

    public void Init(Student ST)
    {
        _ST = ST;
    }

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    public void BulletMove() 
    {
        _dir = (_ST.StudentPosition.position - transform.position).normalized;
        _rig.AddForce(_dir * bulletSpeed, ForceMode.Impulse);
    }

    public void BulletRemove()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    { 
        if (!isCollision)
        {
            BulletMove();
            BulletRemove();
        }
        else
        {
            Destroy(gameObject);
            _rig.AddForce(Vector3.zero);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Student")
        {
            isCollision = true;
            Debug.Log("충돌!");
            _bulletDamage = gameObject.GetComponent<BulletDamage>().ProjectileDamage;
            Debug.Log("데미지부여");
            Debug.Log(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
