using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform playerBody;
    private float[] verticalLimits = { -45, 45 };
    [SerializeField] float rotationSpeed;
    private float[] horizontalLimits = { -360, 360 };
    float verticalAngle;
    float horizontalAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateHorizontal();
        RotateVertical();
        transform.localRotation = Quaternion.Euler(verticalAngle, 0,0);
        playerBody.localRotation = Quaternion.Euler(0, horizontalAngle, 0);

    }

    void RotateVertical()
    {
        verticalAngle += -Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalAngle = Mathf.Clamp(verticalAngle, verticalLimits[0], verticalLimits[1]);
    }
    void RotateHorizontal()
    {
        horizontalAngle += Input.GetAxis("Mouse X") * rotationSpeed;
        horizontalAngle = Mathf.Clamp(horizontalAngle, horizontalLimits[0], horizontalLimits[1]);
    }
}
