using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    GameObject player;

    private void Start()
    {
        findPlayer();
    }

    private void Update()
    {
        updatePosition();
    }

    private void OnValidate()
    {
        findPlayer();
        updatePosition();
    }

    private void findPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    // Camera should be slightly above player, facing down at about 10 degrees.
    // The camera should tilt left or right depending on context. When enemies are on the screen, the camera should tilt towards their average position.
    private void updatePosition()
    {

    }

}
