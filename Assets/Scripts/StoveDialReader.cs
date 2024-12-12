using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveDialReader : PhysicsGadgetHingeAngleReader
{
    [SerializeField] private bool heaterOn = true;
    [SerializeField] private GameObject heater;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        if (heater != null)
        {
            heater.SetActive(heaterOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var value = GetValue();
        
        if(value > 0 && heaterOn != true)
        {
            turnHeaterOn(true);
        }
        if(value == -1 && heaterOn != false)
        {
            turnHeaterOn(false);
        }

    }

    void turnHeaterOn(bool onOff)
    {
        if(heater != null)
        {
            heater.SetActive(onOff); heaterOn = onOff;
        }
    }
}
