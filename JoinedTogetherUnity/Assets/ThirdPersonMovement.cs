using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float smoothing = 0.1f;
    float smoothVelocity;

    // Update is called once per frame
    void Update()
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

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f)
                * Vector3.forward;

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }


    }
}
