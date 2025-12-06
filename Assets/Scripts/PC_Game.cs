using UnityEngine;
using UnityEngine.InputSystem;

public class PC_Game : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody rb;   // 플레이어의 rigidbody (Cube에 붙어있음)

    public float speed = 5f;

    private void Awake()
    {
        // 자식에서 Rigidbody 찾기
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Move 액션 이벤트
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }

    // Jump 액션 이벤트
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"{gameObject.name} Jump");
        }
    }

    // Use 액션 이벤트
    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"{gameObject.name} Use");
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, 0);

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}
