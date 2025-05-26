using UnityEngine;

public class PersistenteUnico : MonoBehaviour
{
    private static PersistenteUnico instancia;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
