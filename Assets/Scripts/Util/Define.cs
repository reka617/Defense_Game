using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public class Student
    {
        int id;
        int hp;
        float power;
        int projectileCount;
        string prefabPath;
        string imageUrl;
    }
    public class Enemy
    {
        int id;
        int hp;
        float power;
        int projectileCount;
        string prefabPath;
        string imageUrl;
    }
   public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Shop,
        StageSelct,
        NormalStage,
        BossStage
    }

    public enum EnemyType
    {
        SniperEnemy,
        CannonEnemy,
        ThreeShotEnemy,
        EliteEnemy
    }

    public enum StudentType
    {
        HandGun,
        Rifle,
        ShotGun,
        SniperRifle,
        MachineGun
    }
}
