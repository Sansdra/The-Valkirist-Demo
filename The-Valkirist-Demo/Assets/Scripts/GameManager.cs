using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public GameObject jugador;
    public GameObject camara;

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(jugador);
        DontDestroyOnLoad(camara);
    }
}
