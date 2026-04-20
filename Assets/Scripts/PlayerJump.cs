using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    public float jumpHeight = 1.5f;

    public float gravity = -18f;

    public InputActionReference jumpActionRight;

    public Transform RestartTrans;

    public Material skybox;

    private CharacterController cc;
    private Vector3 verticalVelocity = Vector3.zero;

    private bool isGrounded;
    private float lastJumpTime = 0f;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        jumpActionRight?.action.Enable();
    }

    private void OnEnable()
    {
        if (jumpActionRight != null)
            jumpActionRight.action.started += OnJumpPressed;
    }

    private void OnDisable()
    {
        if (jumpActionRight != null)
            jumpActionRight.action.started -= OnJumpPressed;
    }

    private void Update()
    {
        isGrounded = cc.isGrounded;

        if (isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }

        verticalVelocity.y += gravity * Time.deltaTime;

        cc.Move(verticalVelocity * Time.deltaTime);
    }

    private void OnJumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            if (Time.time - lastJumpTime > 0.1f) 
            {
                verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                lastJumpTime = Time.time;
            }
        }
    }

    public void SetPlayerToRestart()
    {
        transform.position = RestartTrans.position;
    }

    public void Switchsky()
    {
        RenderSettings.skybox = skybox;
    }
}