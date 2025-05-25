using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float speed = 6f; // Ajusta velocidad para que t = distancia / speed

    void Update()
    {
        // Mover hacia abajo (eje Y)
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Opcional: destruir la nota si pasa la zona de juicio (Y < -1)
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
