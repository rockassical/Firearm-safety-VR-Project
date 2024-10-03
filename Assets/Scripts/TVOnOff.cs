using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVOnOff : MonoBehaviour
{
    private bool tvPower = true;
    [SerializeField]
    private GameObject tvScreen;
    public 
        void turnOnOff()
    {
        tvPower = !tvPower;
        if (tvPower)
        {
            tvScreen.SetActive(true);
        }
        else
        {
            tvScreen.SetActive(false);
        }
    }

}
