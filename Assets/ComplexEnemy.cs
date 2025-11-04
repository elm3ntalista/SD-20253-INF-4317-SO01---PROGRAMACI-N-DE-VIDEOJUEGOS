using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5.0f;
    public float speed = 2.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 direction;
    private Animator anim;

    private string nombreEscenaActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nombreEscenaActual = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Vector3 escalaActual = transform.localScale;

        direction = Vector2.zero;
        movement = Vector2.zero;

        if (distanceToPlayer < detectionRadius)
        {
            direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);
        }

        bool estaMoviendose = movement.x != 0;

        if (direction.x > 0.01f)
        {
            escalaActual.x = -Mathf.Abs(escalaActual.x);
        }
        else if (direction.x < -0.01f)
        {
            escalaActual.x = Mathf.Abs(escalaActual.x);
        }

        transform.localScale = escalaActual;

        if (anim != null)
        {
            anim.SetBool("EstaCorriendo", estaMoviendose);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreEscenaActual);
        }
    }
}