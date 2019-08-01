using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot;
    [SerializeField]
    private VariableJoystick variableJoystickRotate;
    [SerializeField]
    private bool invert;

    [SerializeField]
    private float sensivity;

    [SerializeField]
    private float rool_Speed = 3f;

    private Vector2 look_Angle;

    private Vector2 current_MouseLook;

    public bool isRotate;
    private void Update()
    {
        if (isRotate)
        {
            LookAround();
            print("Rotating..");
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


    void LookAround()
    {
        //for windows
//#if UNITY_EDITOR
        current_MouseLook = new Vector2(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"));
//#endif

        //for Android
       // if (Application.platform==RuntimePlatform.Android)
      //  current_MouseLook = new Vector2(variableJoystickRotate.Vertical, -variableJoystickRotate.Horizontal);
       // else
        //    current_MouseLook = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        look_Angle.x += current_MouseLook.x * sensivity * (invert ? 1f : -1f);
        look_Angle.y += current_MouseLook.y * sensivity ;

        playerRoot.localRotation = Quaternion.Euler(look_Angle.x, look_Angle.y, Time.deltaTime * rool_Speed);
    }


























}//class
