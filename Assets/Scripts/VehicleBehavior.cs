using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VehicleBehavior : MonoBehaviour
{

    HingeJoint UpperLeftMotor;
    HingeJoint UpperRightMotor;
    HingeJoint LowerLeftMotor;
    HingeJoint LowerRightMotor;

    // Start is called before the first frame update
    void Start()
    {
        JointMotor leftMotor = UpperLeftMotor.motor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
