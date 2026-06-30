using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExperience : MonoBehaviour
{
    public void CloseExperience()
    {
        Debug.Log("Application closes.");
        Application.Quit();
    }
}
