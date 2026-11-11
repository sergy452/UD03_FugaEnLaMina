using TMPro;
using UnityEngine;

// GameManager v1 — UD03, M04, ejercicio final.
//
// Guarda el estado de la partida (vidas, puntos, estado) y decide qué pasa
// cuando el jugador muere: reaparecer o terminar. De momento informa por la
// Console; la interfaz (HUD) llega en la unidad siguiente.
//
// Start() y Reaparecer() ya están hechos. Tu trabajo está en los TODO.

public enum EstadoJuego
{
    Jugando,
    Reapareciendo,
    FinDePartida
}

public class GameManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private PlayerControllerFisicas jugador;
    [SerializeField] private Transform puntoReaparicion;

    [Header("Reglas")]
    [SerializeField] private int vidasIniciales = 3;
    [SerializeField] private float esperaReaparicion = 1.5f;

    [Header("HUD")]
    public TMP_Text numeroVidasTMP;
    public TMP_Text numeroPuntosTMP;
    public int vidas;
    public int puntos;
    private EstadoJuego estado;

    void Start()
    {
        vidas = vidasIniciales;
        puntos = 0;
        estado = EstadoJuego.Jugando;
        Debug.Log("Empieza la partida. Vidas: " + vidas);
    }

    public void SumarPuntos(int cantidad)
    {
        // TODO 1: si la partida no está en estado Jugando, no hagas nada.

        if (estado != EstadoJuego.Jugando)
            return;

        // TODO 2: suma la cantidad a los puntos y muéstralos en la Console.

        if (estado == EstadoJuego.Jugando)
        {
            puntos += cantidad;
            Debug.Log("+ " + cantidad + " punto" + "Cantidad de puntos actuales: " + puntos);
        }
    }

    public void JugadorMuerto()
    {
        // TODO 3: resta una vida y muestra en la Console las que quedan.

        vidas--;

        // TODO 4: si quedan vidas, pasa al estado Reapareciendo y programa la llamada a Reaparecer() para dentro de esperaReaparicion segundos (Invoke).

        if (vidas > 0)
        {
            estado = EstadoJuego.Reapareciendo;
            Invoke("Reaparecer", esperaReaparicion);
        }

        // TODO 5: si no quedan vidas, pasa al estado FinDePartida y muestra en la Console los puntos conseguidos.

        if (vidas <= 0)
        {
            estado = EstadoJuego.FinDePartida;
            Debug.Log("Puntos conseguidos esta partida: " + puntos);
        }
    }

    private void Reaparecer()
    {
        jugador.Reaparecer(puntoReaparicion.position);
        estado = EstadoJuego.Jugando;
    }

    private void Update()
    {
        numeroPuntosTMP.text = "Puntos: " + puntos;
        numeroVidasTMP.text = "Vidas: " + vidas;
    }
}
