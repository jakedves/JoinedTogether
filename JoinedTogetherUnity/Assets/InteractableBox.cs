using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public bool thisInContactWith, moveable;
    public float radius = 3f;
    public LayerMask playerMask
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        thisInContactWith = Physics.CheckSphere(this.transform.position, radius, playerMask);

        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("pushing down");
        }

        if (thisInContactWith)
        {
            if (Input.GetButtonDown("Interact"))
            {
                moveable = !moveable;
            }
        }
        else
        {
            moveable = false;
        }

        if (moveable)
        {
            //transform.position += transform.forward * Time.deltaTime * 100.0f;
            m_Rigidbody.AddForce(transform.forward * 10f);
        }
        m_Rigidbody.AddForce(transform.up * 10);
    }
}
