using UnityEngine;
using UnityEngine.InputSystem;

public class PC_Game : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody rb;

    public float speed = 5f;

    // 🔥 다른 스크립트에서 접근해야 하므로 public
    [HideInInspector] public IUsablePad currentPad;

    public Vector3 gravityDir = Vector3.down;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Move
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            moveInput = context.ReadValue<Vector2>();
    }

    // Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log($"{gameObject.name} Jump");
    }

    // Use
    public void OnUse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Debug.Log($"{gameObject.name} Use");

        if (currentPad != null)
        {
            currentPad.OnUse(this);
        }
        else
        {
            Debug.Log("현재 밟고 있는 패드가 없음");
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, 0);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        // 커스텀 중력
        rb.AddForce(gravityDir * 9.81f, ForceMode.Acceleration);
    }
}
