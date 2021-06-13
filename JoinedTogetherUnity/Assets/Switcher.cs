using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;


public class Switcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CinemachineFreeLook cam;
    private bool onPlayer1 = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("F"))
        {
            Switch();
        }
    }

    void Switch()
    {
        onPlayer1 = !onPlayer1;

        if (onPlayer1)
        {
            cam.LookAt = player1.transform;
            cam.Follow = player1.transform;
        }
        else
        {
            cam.LookAt = player2.transform;
            cam.Follow = player2.transform;
        }
        player1.GetComponent<CharacterController>().enabled = onPlayer1;
        player2.GetComponent<CharacterController>().enabled = !onPlayer1;
    }
}
