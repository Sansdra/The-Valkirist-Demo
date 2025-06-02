using UnityEngine;

public class TapaGira : MonoBehaviour, IInteractuable
{
    public float rotationDegrees = 90f;
    public float rotationSpeed = 200f;

    private bool isRotating = false;
    private bool yaFueUsado = false;
    private Quaternion targetRotation;

    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    public void Interactuar()
    {
        if (yaFueUsado || isRotating) return;

        targetRotation = Quaternion.Euler(transform.eulerAngles.x + rotationDegrees, transform.eulerAngles.y, transform.eulerAngles.z);
        isRotating = true;
        yaFueUsado = true;
    }

    public string MensajeInteractuar()
    {
        return yaFueUsado ? "" : "Presiona E para girar";
    }
}
