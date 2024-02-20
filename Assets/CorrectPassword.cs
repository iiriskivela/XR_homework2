using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPassword : MonoBehaviour
{
    private int[] result, correctCombination;

    private void Start()
    {
        result = new int[]{5,5,5,5};
        correctCombination = new int[] { 1, 2, 3, 4 };
        Rotation.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "Ruller1":
                result[0] = number;
                break;

            case "Ruller2":
                result[1] = number;
                break;

            case "Ruller3":
                result[2] = number;
                break;

            case "Ruller4":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            Debug.Log("Opened!");
        }
    }

    private void OnDestroy()
    {
        Rotation.Rotated -= CheckResults;
    }
}
