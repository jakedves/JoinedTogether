using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public static bool onRedPlate;
    public static bool onPurplePlate;

    // Global player/camera
    public CharacterController controller;
    public Transform cam;

    // Movement for camera
    public float speed = 6f;
    public float smoothing = 0.1f;
    float smoothVelocity;

    public float radius = 3f;

    // For gravity
    public float gravity = -9.81f;
    public float distanceToGround;
    public float jumpHeight = 3f;
    public Transform platform;
    public LayerMask groundMask, playerMask, boxMask;
    Vector3 velocity;
    bool grounded;
    public Transform lookPoint;

    public float distanceOfRays = 40f;

    public Animator animator;

    public bool canInteract = false;
    public bool thisInContactWith, moveable;



    public Rigidbody m_Rigidbody;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        CameraMove();
        ApplyGravity();
    }

    void CheckInteraction()
    {



        //Ray ray = new Ray(lookPoint.position, lookPoint.forward);
        //RaycastHit hit;

        

        thisInContactWith = Physics.CheckSphere(this.transform.position, radius, boxMask);

        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("pushing down");
        }

        if (thisInContactWith) {
            if (Input.GetButtonDown("Interact")) {
                moveable = !moveable;
            }
        } else
        {
            moveable = false;
        }

        if (moveable)
        {
            //transform.position += transform.forward * Time.deltaTime * 100.0f;
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            m_Rigidbody.AddForce(transform.forward * speed);
        }
        
            

            /*
            // If the ray hits
            if (Physics.Raycast(ray, out hit, 4))
            {
                InteractablePressurePlate interactable = hit.collider.GetComponent<InteractablePressurePlate>();

                if (interactable != null)
                {
                    Debug.Log("Successfully interacted with");
                }
            }
            */
        
    }
    
    


    void ApplyGravity()
    {
        // Checks sphere from playerPlatform, with radius distanceToGround and
        // checks if touching the layer with groundMask.
        grounded = Physics.CheckSphere(platform.position, distanceToGround,
            groundMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("jumping", false);
        }
        else
        {
            animator.SetBool("jumping", true);
        }

        // v = root(h * -2 * grav)
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void CameraMove()
    {
        // from -1 to 1
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            // Returns angle between x-axis and direction vector appropriately
            // in radians.
            float targetAngle = Mathf.Atan2(direction.x, direction.y)
                * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                targetAngle, ref smoothVelocity, smoothing);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection;
            if (vertical < 0)
            {
                moveDirection = Quaternion.Euler(0f, targetAngle, 0f)
                * Vector3.back;
            } 
            else
            {
                moveDirection = Quaternion.Euler(0f, targetAngle, 0f)
                * Vector3.forward;
            }

            controller.Move(speed * Time.deltaTime * moveDirection.normalized);

            animator.SetFloat("Speed", (speed * moveDirection.normalized).magnitude);

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }


}
