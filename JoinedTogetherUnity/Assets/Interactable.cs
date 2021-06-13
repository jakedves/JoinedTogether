using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Determines how close the player must be to interact with the object
    public float radius = 3f;
    bool inContactWith;
    public LayerMask playerMask;

    public GameObject door;


    private void Update()
    {
        inContactWith = Physics.CheckSphere(this.transform.position, radius, playerMask);
        if (inContactWith)
        {
            openDoor();
        }
    }


    void openDoor()
    {
        Destroy(door); //Yes
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
