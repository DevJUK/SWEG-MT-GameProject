using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Move : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axess = RotationAxis.MouseXandY;

    public Transform Cam;

    public float sensitivityHor;
    public float sensitivityVer;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    public float rotationY = 0;

    internal Quaternion CamOriginalRotation;

    Rigidbody rigid;

	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        if (rigid != null)
            rigid.freezeRotation = true;
	}
	
	
	void Update ()
    {
		if (axess == RotationAxis.MouseX)
        {
            //transform.Rotate(0, Input.GetAxis ("Mouse X") * sensitivityHor, 0);
        }
       // else if (axess == RotationAxis.MouseY)
       // {
       //     rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
       //     rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
       //
       //     float rotationY = Cam.localEulerAngles.y;
       //
       //     Cam.localEulerAngles = new Vector3(rotationX, rotationY, 0);
       // }
        else
        {
            rotationY -= Input.GetAxis("Mouse Y") * sensitivityVer;
            rotationY = Mathf.Clamp(rotationY, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationX = transform.localEulerAngles.y + delta;

            Cam.localEulerAngles = new Vector3(rotationY, Cam.rotation.y, 0);
            transform.localEulerAngles = new Vector3(transform.rotation.x, rotationX, 0);
        }
	}
}
