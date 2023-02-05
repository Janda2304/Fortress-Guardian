using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform shootElement;
    public GameObject bullet;
    public GameObject Enemybug;
    public int Creature_Damage = 10;

    public float Speed;

    // 
    public Transform[] waypoints;
    private int curWaypointIndex;
    public float previous_Speed;
    public Animator anim;
    public EnemyHp Enemy_Hp;
    public Transform target;
    public GameObject EnemyTarget;


    private void Start()
    {
        anim = GetComponent<Animator>();
        Enemy_Hp = Enemybug.GetComponent<EnemyHp>();
        previous_Speed = Speed;
    }

    // Attack

    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Castle")
        {
            Speed = 0;
            EnemyTarget = other.gameObject;
            target = other.gameObject.transform;
            var targetPosition = new Vector3(EnemyTarget.transform.position.x, transform.position.y, EnemyTarget.transform.position.z);
            transform.LookAt(targetPosition);
            anim.SetBool("RUN", false);
            anim.SetBool("Attack", true);
        }
    }

    // Attack
    private void Shooting()
    {
        //if (EnemyTarget)
        // {           
        var с = Instantiate(bullet, shootElement.position, Quaternion.identity);
        с.GetComponent<EnemyBullet>().target = target;
        с.GetComponent<EnemyBullet>().twr = this;
        // }  
    }


    private void GetDamage()

    {
        EnemyTarget.GetComponent<TowerHP>().Dmg_2(Creature_Damage);
    }


    private void Update()
    {
        //Debug.Log("Animator  " + anim);


        // MOVING

        if (curWaypointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * Speed);

            if (!EnemyTarget) transform.LookAt(waypoints[curWaypointIndex].position);

            if (Vector3.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f) curWaypointIndex++;
        }

        else
        {
            anim.SetBool("Victory", true); // Victory
        }

        // DEATH

        if (Enemy_Hp.EnemyHP <= 0)
        {
            Speed = 0;
            Destroy(gameObject, 1f);
            anim.SetBool("Death", true);
        }

        // Attack to Run


        if (EnemyTarget)
            if (EnemyTarget.CompareTag("Castle_Destroyed")) // get it from BuildingHp
            {
                anim.SetBool("Attack", false);
                anim.SetBool("RUN", true);
                Speed = previous_Speed;
                EnemyTarget = null;
            }
    }
}

