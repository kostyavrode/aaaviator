using UnityEngine;
using System.Collections;

public class TP_RotatingScript : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;

    public float SpeedRotation = 5f;

    private Vector3 _currentRotation;

    void Start()
    {
        _currentRotation = gameObject.transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (Time.timeScale>0.1f)
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation), SpeedRotation);
    }
}
