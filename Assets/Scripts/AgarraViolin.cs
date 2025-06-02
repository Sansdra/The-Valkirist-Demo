using Unity.VisualScripting;
using UnityEngine;

public class AgarraViolin : MonoBehaviour, IInteractuable
{

    public static bool DestruirViolin = false;
    public void Interactuar()
    {
        DestruirViolin = true;
        Destroy(gameObject);
    }

    public string MensajeInteractuar()
    {
        return "Presiona E para agarrar el violín";
    }
}
