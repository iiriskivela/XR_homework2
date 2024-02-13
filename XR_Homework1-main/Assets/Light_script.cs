using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Light_script : MonoBehaviour
{
    public Light lightComponent;
    private Color originalColor;
    private bool isRed = false;

    public InputActionReference action;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        originalColor = lightComponent.color;

        if (action != null)
        {
            action.action.Enable();
            action.action.performed += ToggleColor;
        }
    }

    // toggle the light color when the action is performed
    void ToggleColor(InputAction.CallbackContext ctx)
    {
        // if the light is currently red, switch it back to the original color
        if (isRed)
        {
            lightComponent.color = originalColor;
            isRed = false;
        }
        else
        {
            // if the light is the original color, change it to red
            lightComponent.color = Color.red;
            isRed = true;
        }
    }
}
