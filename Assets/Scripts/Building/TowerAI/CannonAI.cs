using System.Collections;
using UnityEngine;
using FG_EnemyAI;


public class CannonAI : MonoBehaviour
{
   [Header("Temp Thingies")] //This is just for testing until ill make a working object pooler
   [SerializeField] private  GameObject cannonBall;
   
   
   [Header("Cannon Objects")]
   [SerializeField] private Transform cannonPivot;
   [SerializeField] private Transform shootPoint;
   [Header("Firing Settings")]
   [SerializeField] private float projectileForce;
   public float fireRate;
   [SerializeField] private float rotationSpeed;
   public float projectileLifespan;
   public float damage;
   public float range;
   
   private float timer  = 0f;
   private float timerMax = 0;
   private Collider[] targets;
   private GameObject target;

   private void Start()
   {
      timerMax  = fireRate; 
   }


  
  

   private void Update()
   {
      timer += Time.deltaTime;
      
      targets = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
      if (targets.Length > 0)
      {
        target = targets[0].gameObject;
        if (timer >= timerMax)
        {
           if (target.GetComponentInParent<EnemyAI>().isDeath == false)
           {
              StartCoroutine(Fire());
              timer = 0.0f;
           }

        }
        RotateCannon();
         
        
      }
   }



   IEnumerator Fire()
   {
      yield return new WaitForSeconds(fireRate);
      GameObject projectile = Instantiate(cannonBall, shootPoint.position, shootPoint.rotation, transform);
      projectile.GetComponent<Rigidbody>().AddForce(shootPoint.forward * projectileForce, ForceMode.Impulse);
      if (targets.Length > 0)
      {
         Collider target = targets[0];
         projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, target.transform.position, 1f);
      }
      Destroy(projectile, projectileLifespan);
   }

   private void RotateCannon()
   {
      Vector3 lookPos = target.transform.position - cannonPivot.position;
      lookPos.y = 0;
      Quaternion rotation = Quaternion.LookRotation(lookPos);
      cannonPivot.rotation = Quaternion.Slerp(cannonPivot.rotation, rotation, rotationSpeed * Time.deltaTime);



   }
}
