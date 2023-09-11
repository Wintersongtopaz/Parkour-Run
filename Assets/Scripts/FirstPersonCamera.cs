using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    private float xAxis;
    private float yAxis;
    float xAxisTurnRate = 360f;
    float yAxisTurnRate = 360f;
    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        //camera stays in the place where cursor or mouse is 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    //rotates our camera based on mouse input
    void LateUpdate()
    { 
        AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    
        Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0f);
        orientation.rotation = Quaternion.Euler(0, yAxis, 0);
        Camera.main.transform.rotation = newRotation;
    }

    public void AddXAxisInput(float input)
    {
        xAxis -= input * xAxisTurnRate;
        xAxis = Mathf.Clamp(xAxis, -90f, 90f);
    }

    public void AddYAxisInput(float input)
    {
        yAxis += input * yAxisTurnRate;
    }
}
