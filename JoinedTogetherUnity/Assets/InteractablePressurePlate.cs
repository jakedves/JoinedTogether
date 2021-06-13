using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePressurePlate : MonoBehaviour
{
    // Determines how close the player must be to interact with the object
    public float radius = 0f;
    public static bool thisInContactWith;

    public LayerMask playerMask, boxMask;

    public string plateColour;

    public GameObject door;


    private void Update()
    {
        thisInContactWith = Physics.CheckSphere(this.transform.position, radius, boxMask);


        if (thisInContactWith)
        {
            openDoor();
        }


        /*
        

        if (plateColour == "Red") {
            if (thisInContactWith)
            {
                Debug.Log("Red: " + ThirdPersonMovement.onRedPlate);
                ThirdPersonMovement.onRedPlate = true;
            } else
            {
                ThirdPersonMovement.onRedPlate = false;
            }
        } else
        {
            if (thisInContactWith)
            {
                ThirdPersonMovement.onPurplePlate = true;
                Debug.Log("Purple: " + ThirdPersonMovement.onPurplePlate);
            }
            else
            {
                ThirdPersonMovement.onPurplePlate = false;
            }
        }

        if (ThirdPersonMovement.onRedPlate && ThirdPersonMovement.onPurplePlate)
        {
            openDoor();
        }
        */
        
    }


    void openDoor()
    {
        Destroy(door); //Yes
    }
}
