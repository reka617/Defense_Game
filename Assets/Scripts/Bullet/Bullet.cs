using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _dir;
    Vector3 StudentPosition;

    BulletBase _BB;
    Rigidbody _rig;
    Student _ST;

    bool isCollision = false;
    float _bulletDamage;


    [SerializeField] float bulletSpeed;

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
        StudentPosition = _ST.StudentPosition.position;
        StudentPosition.y += 0.5f;
        _dir = (StudentPosition - transform.position).normalized;
        _rig.AddForce(_dir * bulletSpeed, ForceMode.Impulse);
    }

    public void ParabolaBulletMove()
    {
        float m_InitialAngle = 30f;
        Vector3 velocity = GetComponent<Parabola>().GetVelocity(transform.position, _ST.StudentPosition.position, m_InitialAngle);
        _rig.velocity = velocity;
    }



    public void BulletRemove()
    {
        Managers.Resource.Destroy(gameObject);
    }

    private void Update()
    {
<<<<<<< HEAD
        if (Define.EnemyBulletType.Parabola != _BB.BType) 
=======

        if (!isCollision)
>>>>>>> 37fdd471c0bc94c676017e21559d3d325346942c
        {
            if (isCollision)
            {
                BulletRemove();
            }
        }
        else 
        {
            if(isCollision) 
            {
                BulletRemove();
            }
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
