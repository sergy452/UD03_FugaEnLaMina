using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject objetoASeguir;
    public float offset;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(objetoASeguir.transform.position.x + offset, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
