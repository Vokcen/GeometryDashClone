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

    private Rigidbody2D rb;
    [SerializeField] private MovementMode currentMode = MovementMode.Jump; // Baþlangýçta Jump modunda


    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform visual;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
            visual.Rotate(Vector3.back * 1);
        }
    }

    private void HoldJump()
    {
        if (Input.GetMouseButton(0))
        {

            rb.velocity = Vector2.up * jumpForce;

        }
    }


    private bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
    }
}
