using System.Collections;
using System.Collections.Generic;using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public Camera magnifyingCamera; // Reference to the camera attached to the magnifying glass
    public Camera mainCamera; // Reference to the main camera

    void Update()
    {
        // Make sure both cameras are not null
        if (mainCamera != null && magnifyingCamera != null)
        {
            // Match the position and rotation of the magnifying glass to the main camera
            magnifyingCamera.transform.position = mainCamera.transform.position;
        }
        else
        {
            Debug.LogError("Main camera or magnifying camera is not assigned!");
        }
    }
}
