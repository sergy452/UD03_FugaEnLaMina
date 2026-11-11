using UnityEngine;

// PlayerControllerFisicas, versión del ejercicio final — UD03, M04.
// (Misma clase y mismos campos que el del ejercicio 3.4 de M04: al sustituirlo,
// el Inspector conserva lo que ya estaba asignado.)
//
// Sobre el del ejercicio 3.4 (movimiento con la física del motor), añade lo
// del ejercicio final: el astronauta detecta las colisiones con diamantes y
// peligros, avisa al GameManager, muere y reaparece.
//
// Todo está hecho salvo OnTriggerEnter2D: completa los TODO.
public class PlayerControllerFisicas : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadCarrera = 3f;   // unidades por segundo hacia la derecha
    [SerializeField] private float fuerzaImpulso = 25f;     // fuerza de la mochila hacia arriba
    [SerializeField] private float velocidadMaxima = 5f;    // límite de velocidad vertical

    [Header("Piezas del astronauta")]
    [SerializeField] private GameObject llama;
    public Transform cuerpo;
    public Transform mochila;
    [SerializeField] private Animator animator;

    [Header("Sistemas")]
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;
    private bool impulso = false;
    private bool impulsoHorizontal = false;
    private bool vivo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (llama == null)
        {
            llama = transform.Find("Mochila/Llama").gameObject;
        }
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        llama.SetActive(false);
    }

    // Update: leer la entrada y actualizar lo que se ve.
    void Update()
    {
        impulso = vivo && Input.GetButton("Jump") && !Input.GetKey(KeyCode.X);

        impulsoHorizontal = vivo && Input.GetKey(KeyCode.X);

        llama.SetActive(impulso);
        llama.SetActive(impulsoHorizontal);

        if (cuerpo != null)
        {
            if (impulso)
            {
                cuerpo.localRotation = Quaternion.Euler(0f, 0f, 15f);
            }
            else if (impulsoHorizontal)
            {
                cuerpo.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }
            else cuerpo.localRotation = Quaternion.identity;

            mochila.localRotation = impulsoHorizontal ? Quaternion.Euler(0f, 0f, -90f) : Quaternion.identity;
        }

        animator.SetFloat("Velocidad", vivo ? velocidadCarrera : 0f);
        animator.SetBool("Volando", impulso || Mathf.Abs(rb.linearVelocity.y) > 0.1f);
    }

    // FixedUpdate: todo lo que toca la física.
    void FixedUpdate()
    {
        if (!vivo)
        {
            return;
        }

        Vector2 velocidad = rb.linearVelocity;
        velocidad.x = velocidadCarrera;
        rb.linearVelocity = velocidad;

        if (impulso)
        {
            rb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse);
        }
        else if (impulsoHorizontal)
        {
            rb.AddForce(Vector2.right * fuerzaImpulso / 2.5f, ForceMode2D.Impulse);
        }

        velocidad = rb.linearVelocity;
        velocidad.y = Mathf.Clamp(velocidad.y, -velocidadMaxima, velocidadMaxima);
        rb.linearVelocity = velocidad;
    }

    // Los diamantes y los peligros tienen colliders con Is Trigger activado.
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (!vivo)
        {
            return;
        }

        // TODO 1: si lo que has tocado tiene la etiqueta "Diamante", avisa al GameManager para que sume un punto y destruye el diamante.

        if (otro.tag == "Diamante")
        {
            gameManager.SumarPuntos(1);
            Destroy(otro.gameObject);
        }

        // TODO 2: si tiene la etiqueta "Peligro", el astronauta muere.

        if (otro.tag == "Peligro")
        {
            Morir();
        }
    }

    public void Morir()
    {
        vivo = false;
        impulso = false;
        llama.SetActive(false);
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;               // deja de moverse y de chocar
        animator.SetTrigger("Morir");
        gameManager.JugadorMuerto();
    }

    public void Reaparecer(Vector3 posicion)
    {
        transform.position = posicion;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = true;
        animator.SetTrigger("Reaparecer");
        vivo = true;
    }
}
