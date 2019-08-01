using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour {

    public static raycast Instance;
    RaycastHit hit;
    public float distance ;
    public  bool istouchit= false;
    // Update is called once per frame
    private void Awake()
    {
        if(Instance==null)
        {
            Instance= this;
        }
    }
    void Update ()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, distance))
        {
           
            istouchit = true;
           
           
        }
        else
        {
            istouchit = false;

        }


        //if(istouchit)
        //{
        //    Debug.LogError("its here do");
        //}
    }
}
