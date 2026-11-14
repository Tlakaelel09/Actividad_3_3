using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 3f;
    
    private Rigidbody2D rb;
    private Animator animator;
    private bool enElSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        float movimientoX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        if (movimientoX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoX < 0) transform.localScale = new Vector3(-1, 1, 1);

        if (movimientoX != 0) animator.SetBool("Caminando", true);
        else animator.SetBool("Caminando", false);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && enElSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enElSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }
}