using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : MonoBehaviour
{
    [SerializeField] private GameObject kidGameObject;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
    public void MoveKid()
    {
        if (kidGameObject != null)
        {
            kidGameObject.transform.position = this.transform.position;
        }
    }
}
