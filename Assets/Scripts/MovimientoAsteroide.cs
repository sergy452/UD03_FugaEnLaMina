using UnityEngine;

public class MovimientoAsteroide : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.left * velocidad;
    }
}

