using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    public float speed = 50f;
    private Transform player;
    public AudioClip crabDeathSound;
    public float attackRange = 1.5f;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
   {
        if (player != null)
        {
            MoveTowardsPlayer();

            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                Attack();
            }
        }


    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
        
    //     if (other.CompareTag("Bullets"))
    //     {
            
    //         audioSource.PlayOneShot(crabDeathSound);
    //         Destroy(gameObject);
    //     }
    // }
}
