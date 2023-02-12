using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private ParticleSystem explosion;
    [Header("Audio")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip explosionSoundEffect;
    [Header("Other Scripts")]
    [SerializeField] private CannonAI _cannon;
    private bool impact;


    void Start()
    {
        _cannon = GetComponentInParent<CannonAI>();
        source = GetComponentInParent<AudioSource>();
        explosion.Pause(true);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer is 6)
        {
            explosion.Play(true);
            source.PlayOneShot(explosionSoundEffect);
            Destroy(gameObject, 0.2f);
        }
        if (collision.gameObject.layer is 10)
        {
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(_cannon.projectileDamage);
            explosion.Play(true);
            source.PlayOneShot(explosionSoundEffect);
            Destroy(gameObject, 0.1f);
        }
        
    }
      
      
        
         
        
    
}
