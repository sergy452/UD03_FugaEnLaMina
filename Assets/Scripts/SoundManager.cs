using UnityEngine;

// SoundManager — UD03, M05.
//
// Es el único que reproduce sonidos del juego. No decide CUÁNDO suenan
// (eso lo decide el GameManager), solo CÓMO: qué clip y por qué altavoz.
//
// Reproducir() y ReproducirDiamante() ya están hechos. Completa los TODO.
public class SoundManager : MonoBehaviour
{
    [Header("Altavoces")]
    [SerializeField] private AudioSource fuenteMusica;    // el AudioSource del hijo MusicSource
    [SerializeField] private AudioSource fuenteEfectos;   // el AudioSource del hijo FXSource

    [Header("Efectos")]
    [SerializeField] private AudioClip sonidoDiamante;
    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private AudioClip sonidoReaparecer;
    [SerializeField] private AudioClip sonidoFinPartida;

    public void ReproducirDiamante()
    {
        Reproducir(sonidoDiamante);
    }

    // TODO 1: método público ReproducirMuerte(), que reproduce sonidoMuerte.

    // TODO 2: método público ReproducirReaparecer(), que reproduce sonidoReaparecer.

    // TODO 3: método público ReproducirFinPartida(), que para la música y
    //         reproduce sonidoFinPartida.

    // PlayOneShot permite que varios efectos se solapen en el mismo altavoz
    // sin cortarse entre sí.
    private void Reproducir(AudioClip clip)
    {
        if (clip != null)
        {
            fuenteEfectos.PlayOneShot(clip);
        }
    }
}
