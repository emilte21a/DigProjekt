using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 movement;
    Rigidbody rb;

    [Header("Animator")]
    public Animator camAnimator;

    [Header("Variables")]
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float runSpeed = 10;
    [SerializeField] float crouchSpeed = 2.5f;
    [SerializeField] float jumpForce = 100;
    public float stamina = 5f;
    [SerializeField] private float staminaMultiplier = 1f;



    public Transform orientation;

    [Header("State"), SerializeField]
    private MovementState movementState;

    Vector3 moveDirection;

    float speed;

    public float staminaResetTimer = 2f;

    private float timeForStaminaReset = 1f; //en sekund

    [Header("Collision Detection")]
    public LayerMask layerMask;
    public float playerHeight;

    enum MovementState
    {
        idle,
        walking,
        running,
        crouching,
        air
    }

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        rb.freezeRotation = true;
        stamina = 5f * staminaMultiplier;
    }

    void Update()
    {
        float sidewaysX = Input.GetAxisRaw("Horizontal");
        float forwardZ = Input.GetAxisRaw("Vertical");

        camAnimator.SetBool("isCrouching", false);
        movementState = MovementState.idle;

        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && stamina > 0)
        {
            stamina -= Time.deltaTime;
            speed = runSpeed;
            movementState = MovementState.running;
            staminaResetTimer = timeForStaminaReset;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
            movementState = MovementState.crouching;

            camAnimator.SetBool("isCrouching", true);
        }
        else
        {
            speed = walkSpeed;
            movementState = MovementState.walking;
            staminaResetTimer -= timeForStaminaReset * Time.deltaTime;
            if (stamina < 5 * staminaMultiplier && staminaResetTimer < 0)
                stamina += 0.01f;

            Mathf.Clamp(stamina, 0, 5 * staminaMultiplier);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        movement = new Vector3(sidewaysX * walkSpeed, 0, forwardZ * speed) * Time.deltaTime;

        moveDirection = new Vector3(0, orientation.eulerAngles.y, 0);

        transform.eulerAngles = moveDirection;
        transform.Translate(movement);
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.up * -1, playerHeight, layerMask))
        {
            return true;
        }
        return false;
    }

    bool ShouldRecharge()
    {
        if (staminaResetTimer == 0 && movementState != MovementState.running)
            return true;

        return false;
    }
}
