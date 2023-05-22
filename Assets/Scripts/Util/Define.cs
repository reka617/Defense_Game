namespace Define 
{
    public class Student
    {
        public int id;
        public float hp;
        public float power;
        public int projectileCount;
        public string prefabPath;
        public string imageUrl;
    }
    public class Enemy
    {
        public int id;
        public float hp;
        public float power;
        public int projectileCount;
        public string prefabPath;
        public string imageUrl;
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

    public enum EnemyBulletType
    {
        Laser,
        Parabola,
        ThreeShot,
    }
}
