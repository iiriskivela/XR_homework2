using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCamera : MonoBehaviour
{
    public Vector3 originalPosition;   // original position of the camera
    public Vector3 targetPosition;     // position the camera will move to
    public InputActionReference action;  // input action

    public float movementSpeed = 5f;   // speed of camera movement

    private bool isMoving = false;
    private float movementStartTime;    // time when movement started

    private Vector3 currentTarget;      // current target position for the camera

    void Start()
    {
        currentTarget = originalPosition; // set the initial target position to originalPosition

        if (action != null)
        {
            action.action.Enable();
            action.action.performed += ToggleCamera;
        }
    }

    void ToggleCamera(InputAction.CallbackContext context)
    {
        if (!isMoving)
        {
            isMoving = true;
            movementStartTime = Time.time;

            // toggle between originalPosition and targetPosition
            currentTarget = (currentTarget == originalPosition) ? targetPosition : originalPosition;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            float elapsedTime = Time.time - movementStartTime;
            float t = Mathf.Clamp01(elapsedTime / movementSpeed); // Ensure t is between 0 and 1

            transform.position = Vector3.Lerp(transform.position, currentTarget, t);

            if (t >= 1f)
            {
                isMoving = false;
            }
        }
    }
}
