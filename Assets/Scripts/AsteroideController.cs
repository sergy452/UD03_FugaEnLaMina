using UnityEngine;

// AsteroideController — UD03, M05. Va en el objeto padre del Prefab Asteroide
// (Rigidbody2D Kinematic, collider con Is Trigger, tag Peligro).
// Avanza hacia la izquierda con la física. No hace nada más:
// - el giro lo hace un clip de animación en el hijo con el sprite;
// - el astronauta muere al tocarlo por el tag Peligro (su script de M04);
// - la ZonaDestruccion lo destruye al salir de la pantalla.
//
// RequireComponent: al añadir este script, Unity añade también un Rigidbody2D
// (si el objeto no lo tiene) y no deja quitarlo mientras el script esté puesto.
// El que añade es Dynamic: cámbialo a Kinematic, o el asteroide caerá.
//
// Este script está completo.
[RequireComponent(typeof(Rigidbody2D))]
public class AsteroideController : MonoBehaviour
{
    DetectorContactos contactos;

    [SerializeField] private float velocidad = 4f;   // unidades por segundo hacia la izquierda

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        contactos = FindAnyObjectByType<DetectorContactos>();

        // Velocidad constante: basta con fijarla una vez (Rigidbody2D Kinematic,
        // sin gravedad ni fuerzas que la cambien).
        rb.linearVelocity = Vector2.left * velocidad;
    }

    private void Update()
    {
        if (contactos.muerte)
        {
            contactos.muerte = false;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
            Destroy(gameObject);
    }
}
