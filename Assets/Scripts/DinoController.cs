using UnityEngine;
using UnityEngine.InputSystem;

public class DinoController : MonoBehaviour
{
    public float moveSpeed;
    private float velocity;
    public InputSystem_Actions dinoActions;
    public Camera dinoCamera;
    private Vector2 move;
    private Vector3 moveDirection;

    void Awake()
    {
        dinoActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        dinoActions.Enable();
    }

    void OnDisable()
    {
        dinoActions.Disable();
    }

    void Update()
    {
        Movement();
        Gravity();
        LookAtDirection();
        Collision();
        //Debug.Log(IsGrounded());
        //Debug.Log($"The baryonyx's position is {transform.position}");
    }

    void Gravity()
    {
        if (!IsGrounded())
        {
            velocity += -9.81f * Time.deltaTime;
        }
        else
        {
            velocity = 0;
        }
    }

    void Movement()
    {
        move = dinoActions.Player.Move.ReadValue<Vector2>();

        Vector3 forward = dinoCamera.transform.forward;
        Vector3 right = dinoCamera.transform.right;

        right.y = 0;
        right = right.normalized;

        forward.y = 0;
        forward = forward.normalized;

        Vector3 forwardInput = forward * move.y;
        Vector3 rightInput = right * move.x;

        moveDirection = forwardInput + rightInput + new Vector3(0, velocity, 0); // defined up here for LookAt()
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void LookAtDirection()
    {
        if (dinoActions.Player.Move.ReadValue<Vector2>().sqrMagnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);//instead of changing rigidbody we change tranform
        }
    }

    void Collision()
    {
        if (IsCollided())
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 2.5f;
        }
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position + transform.up * 0.25f, -transform.up, 0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsCollided()
    {
        if (Physics.Raycast(transform.position, transform.forward, 3f))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.orange);
            return true;
        }
        else
        {
            return false;
        }
    }
}