using UnityEngine;
using UnityEngine.InputSystem;

public class PC_Game : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody rb;

    public float speed = 5f;

    [HideInInspector] public IUsablePad currentPad;

    public Vector3 gravityDir = Vector3.down;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            moveInput = context.ReadValue<Vector2>();
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (currentPad != null)
            currentPad.OnUse(this);
    }

    private void FixedUpdate()
    {
        float newX = rb.position.x + moveInput.x * speed * Time.fixedDeltaTime;
        Vector3 newPos = new Vector3(newX, rb.position.y, rb.position.z);

        rb.MovePosition(newPos);

        rb.AddForce(gravityDir * 9.81f, ForceMode.Acceleration);
    }
}
