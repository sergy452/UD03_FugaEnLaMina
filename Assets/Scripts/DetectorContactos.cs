using System.Collections;
using TMPro;
using UnityEngine;

public class DetectorContactos : MonoBehaviour
{
    GameManager gameManager;
    PlayerControllerFisicas player;
    Animator animator;

    Coroutine numeros;
    Vector2 posicionInicial;
    public bool muerte;

    private void Start()
    {
        player = GetComponent<PlayerControllerFisicas>();
        animator = GetComponentInChildren<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
        posicionInicial = transform.position;
    }
    void OnCollisionEnter2D(Collision2D colision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        switch (colision.tag)
        {
            case "Coleccionable":
                //Debug.Log("Has obtenido un " + colision.gameObject.name);
                //numeros = StartCoroutine(AnimacionNumeros(gameObject));
                gameManager.puntos += 100;
                Destroy(colision.gameObject);
                break;

            case "Peligro":
                muerte = true;
                if (gameManager.vidas <= 0)
                    break;
                Debug.Log("Te ha golpeado un " + colision.gameObject.name);
                gameManager.vidas--;
                if (gameManager.vidas > 0)
                {
                    transform.position = posicionInicial;
                }
                else
                {
                    //gameManager.finDePartida.gameObject.SetActive(true);
                    player.velocidadCarrera = 0f;
                    animator.Play("Morir");
                    player.GetComponentInChildren<Collider2D>().isTrigger = true;
                    player.cuerpo.localRotation = Quaternion.Euler(0f, 0f, 0f);
                }

                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    //public IEnumerator AnimacionNumeros(GameObject objetoRecogido)
    //{
    //    Color opacidadInicial = new Color(0, 0, 0, 0);
    //    Color opacidadFinal = new Color(0, 0, 0, 1);
    //    gameManager.puntos += 100;
    //    gameManager.puntosObtenidosTMP.transform.position = objetoRecogido.transform.position;
    //    gameManager.puntosObtenidosTMP.enabled = true;

    //    float timer = 0f;

    //    while (timer < 0.5f)
    //    {
    //        gameManager.puntosObtenidosTMP.color = 
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }

    //    yield return null;
    //}
}
