using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform planet; // reference to the planet's transform
    public float rotationSpeed = 10f; // rotation speed of the planet

    void Update()
    {
        // rotate the planet around the Y-axis based on Time.deltaTime
        planet.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
