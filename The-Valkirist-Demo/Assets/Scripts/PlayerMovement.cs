using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 10f;
    public float runSpeed = 20f;
    public float rotationSmoothTime = 1f;

    [Header("Referencias")]
    public Transform cameraTransform;

    private CharacterController controller;
    private Animator anim;
    private float rotationVelocity;
    private Vector2 input;
    private bool isRunning;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        // Buscar cámara si no se asignó en el Inspector
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // 1. Leer input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 inputDir = new Vector3(input.x, 0f, input.y).normalized;
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        anim.SetBool("Corriendo", isRunning);

        if (inputDir.magnitude >= 0.1f)
        {
            // 2. Calcular ángulo hacia donde moverse (en base a cámara)
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationVelocity, rotationSmoothTime);

            // 3. Rotar personaje
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // 4. Mover en esa dirección
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);

            // 5. Animaciones: convertir dirección de movimiento al espacio local del personaje
            Vector3 cameraForward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
            Vector3 cameraRight = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
            Vector3 worldMoveDir = (cameraForward * input.y + cameraRight * input.x).normalized;

            Vector3 localDir = transform.InverseTransformDirection(worldMoveDir);

            anim.SetFloat("VelX", localDir.x, 0.1f, Time.deltaTime);
            anim.SetFloat("VelY", localDir.z, 0.1f, Time.deltaTime);
        }
        else
        {
            // 6. Si no hay input, poner blend tree en idle
            anim.SetFloat("VelX", 0f, 0.1f, Time.deltaTime);
            anim.SetFloat("VelY", 0f, 0.1f, Time.deltaTime);
        }
    }
}
