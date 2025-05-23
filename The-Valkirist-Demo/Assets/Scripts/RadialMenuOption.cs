using UnityEngine;

public class RadialMenuOption : MonoBehaviour
{
    public enum TipoOpcion { Audio, Video, Controles, Salir }
    public TipoOpcion tipo;

    public void Ejecutar()
    {
        switch (tipo)
        {
            case TipoOpcion.Audio:
                Debug.Log("Abrir menú de Audio");
                break;
            case TipoOpcion.Video:
                Debug.Log("Abrir menú de Video");
                break;
            case TipoOpcion.Controles:
                Debug.Log("Abrir menú de Controles");
                break;
            case TipoOpcion.Salir:
                Debug.Log("Saliendo del juego...");
                Application.Quit();
                break;
        }
    }
}
