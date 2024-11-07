using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player_Moviment : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float walkSpeed = 10f;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    Vector2 moveInput;
    Rigidbody myRigidbody;
    public Transform orientation;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Handle drag
        if (grounded)
        {
            myRigidbody.linearDamping = groundDrag;
        }
        else
        {
            myRigidbody.linearDamping = 0;
        }
    }

    void FixedUpdate()
    {
        Run();
        SpeedControl();
       
    }

    void Run()
    {
        Vector3 moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;
        myRigidbody.AddForce(moveDirection.normalized * walkSpeed * 10f, ForceMode.Force);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(myRigidbody.linearVelocity.x, 0f, myRigidbody.linearVelocity.z);

        //Limita a velocidade se necessario
        if (flatVel.magnitude > walkSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * walkSpeed;
            myRigidbody.linearVelocity = new Vector3(limitedVel.x, myRigidbody.linearVelocity.y, limitedVel.z);
        }
    }
}
