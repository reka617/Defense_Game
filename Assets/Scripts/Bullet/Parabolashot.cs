using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Parabolashot : MonoBehaviour
{
    Transform Target;
    Vector3 bulletStartPosition;
    Rigidbody _rig;

    float firingAngle = 45f;
    float gravity = 9.8f;
    float flightDuration;
    float Vx;
    float Vy;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Student").transform;
        _rig = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        bulletStartPosition = GetComponent<Bullet>().EnemyCurrentPosition;
        ParabolaMethod();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.LookRotation(Target.position - gameObject.transform.position);

        float elapse_time = 0;

        gameObject.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

        elapse_time += Time.deltaTime;

        if (elapse_time < flightDuration)
        {
            return;
        }
    }

    void ParabolaMethod()
    {
        gameObject.transform.position = transform.position + new Vector3(0, 0.0f, 0);


        float target_Distance = Vector3.Distance(gameObject.transform.position, Target.position);


        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);


        Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        flightDuration = target_Distance / Vx;
    }
}