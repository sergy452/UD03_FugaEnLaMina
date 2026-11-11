using UnityEngine;

// ZonaDestruccion — UD03, M05.
// Va en un objeto vacío hijo de la cámara, con un BoxCollider2D con Is Trigger,
// colocado justo a la izquierda del encuadre y tan alto como la pantalla. Como
// es hijo de la cámara, avanza con ella: todo lo que sale de la pantalla por la
// izquierda entra en la zona.
//
// Solo avisan los objetos con Rigidbody2D (los asteroides); el suelo, el techo,
// los diamantes y los aliens no lo tienen, así que la zona no los toca.
//
// Completa el TODO.
public class ZonaDestruccion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        // TODO: destruye el objeto que ha entrado en la zona.
    }
}
