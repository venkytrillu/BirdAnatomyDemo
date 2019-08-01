using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    public GameObject target;
    public float rotateSpeed;
    Quaternion rot;
    Touch[] touch;
    public bool isRotate, isScale;
    private void Update()
    {
        if (isRotate)
        {
            RotateObj();
            print("Rotating..");
        }
       
    }

    void RotateObj()
    {

        if (fixedJoystick.Horizontal != 0)
        {
            rot = Quaternion.Euler(target.transform.rotation.x,
                                   target.transform.rotation.y + fixedJoystick.Horizontal * rotateSpeed, 
                                   target.transform.rotation.z);
            target.transform.rotation = rot;
        }
    }


    public void Drag()
    {
        isRotate = true;
    }

    public void Exit()
    {
        isRotate = false;
    }

















}//class
