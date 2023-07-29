using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    Vector3 _mouseAim;
    Vector3 _enemyCurrentPosition;

    public Vector3 EnemyCurrentPosition { get { return _enemyCurrentPosition; } }

    BulletBase _BB;
    Rigidbody _rig;
    Student _ST;
    Enemy _enemy;

    bool isCollision = false;
    float _bulletDamage;


    [SerializeField] float bulletSpeed;

    public void Init(BulletBase BB)
    {
        _BB = BB;
    }

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        _enemyCurrentPosition = _enemy.CurrentPosition;
    }


    public void BulletRemove()
    {
        Managers.Resource.Destroy(gameObject);
    }

    private void Update()
    {
        if (Define.EnemyBulletType.Parabola != _BB.BType) 
        {
            if (isCollision)
            {
                BulletRemove();
            }
            else
            {
                float time = 0;
                time += Time.deltaTime;
                if(time > 8)
                {
                    BulletRemove();
                }
            }
        }
        else 
        {
            if(isCollision) 
            {
                BulletRemove();
            }
            else
            {
                float time = 0;
                time += Time.deltaTime;
                if (time > 8)
                {
                    BulletRemove();
                }
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
            BulletRemove();
        }
    }
}
