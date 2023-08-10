using System;
using UnityEngine;

public enum MovementMode
{
    Jump,
    Hold
}

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float flyForce;

    private Rigidbody2D rb;
    [SerializeField] private MovementMode currentMode = MovementMode.Jump;


    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform visual;



    private float rotationSpeed = 5.0f;
    private float maxRotationAngle = 30.0f;

    private void OnEnable()
    {
        EventManager.OnTriggerPortal += OnTriggerPortal;
    }



    private void OnDisable()
    {
        EventManager.OnTriggerPortal -= OnTriggerPortal;

    }

    private void OnTriggerPortal(object sender, MovementMode cubeNewMovementMode)
    {
        currentMode = cubeNewMovementMode;

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.instance.GetState() != GameState.Game) return;

        MoveCharacter();

        PerformJump();
    }

    private void MoveCharacter()
    {
        rb.position += Vector2.right * moveSpeed * Time.deltaTime;
    }

    private void RotateCharacter()
    {

    }

    private void PerformJump()
    {
        if (currentMode == MovementMode.Jump)
        {
            JumpOnInput();
        }
        else if (currentMode == MovementMode.Hold)
        {
            HoldJump();
        }
    }

    private void JumpOnInput()
    {
        if (OnGround())
        {
            Vector3 Rotation = visual.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            visual.rotation = Quaternion.Euler(Rotation);
            if (Input.GetMouseButtonDown(0))
            {


                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);



            }
        }
        else
        {
            visual.Rotate(Vector3.back, 452.415f * Time.deltaTime);
        }
    }

    private void HoldJump()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up * flyForce;


        }
        Vector2 direction = rb.velocity.normalized;

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Clamp the angle within the range of -maxRotationAngle to +maxRotationAngle
            angle = Mathf.Clamp(angle, -maxRotationAngle, maxRotationAngle);

            // Calculate target rotation based on the clamped angle
            Quaternion targetRot = Quaternion.Euler(0, 0, angle);

            // Smoothly interpolate the rotation using Quaternion.Slerp
            visual.rotation = Quaternion.Slerp(visual.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }


    private bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
    }
}
