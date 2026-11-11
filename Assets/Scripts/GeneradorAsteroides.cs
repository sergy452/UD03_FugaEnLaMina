using UnityEngine;

// GeneradorAsteroides — UD03, M05.
// Va en un objeto vacío hijo de la cámara, a la derecha del encuadre: como se
// mueve con la cámara, los asteroides siempre aparecen justo fuera de la vista.
//
// El temporizador ya está hecho. Completa Generar().
public class GeneradorAsteroides : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabAsteroide;
    [SerializeField] private float intervalo = 1.5f;        // segundos entre asteroides
    [SerializeField] private float alturaMinima = 0f;
    [SerializeField] private float alturaMaxima = 6f;

    private float temporizador = 0f;

    private void Start()
    {
        Generar();
    }

    void Update()
    {
        temporizador += Time.deltaTime;
        if (temporizador >= intervalo)
        {
            temporizador = 0f;
            Generar();
        }
    }

    private void Generar()
    {
        // TODO 1: calcula la posición del nuevo asteroide: la del generador,
        //         pero con una altura aleatoria entre alturaMinima y alturaMaxima.

        float altura = Random.Range(alturaMinima, alturaMaxima);
        float posicionX = transform.position.x;

        // TODO 2: crea una copia del prefab del asteroide en esa posición,
        //         sin rotación.

        int asteroideElegido = Random.Range(0, prefabAsteroide.Length); 

        GameObject asteroideClon = Instantiate(prefabAsteroide[asteroideElegido]);
        asteroideClon.SetActive(true);
        asteroideClon.transform.position = new Vector3(posicionX, altura, 0f);
        Rigidbody2D rbAsteroide = asteroideClon.GetComponent<Rigidbody2D>();
        rbAsteroide.linearVelocityX = Random.Range(-6f, -3f);
    }
}
