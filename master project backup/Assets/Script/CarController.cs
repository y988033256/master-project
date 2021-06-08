using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;

    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";

    public float horizontalInput;
    public float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;


    GameObject lift;
    public float x;
    public float z;
    public float y;
    public float liftrange = 0.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        LiftControl();
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL) * 10;
        verticalInput = Input.GetAxis(VERTICAL) * 10;
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void LiftControl()
    {
        lift = GameObject.FindWithTag("lift");
        x = lift.transform.position.x;
        z = lift.transform.position.z;
        y = lift.transform.position.y;

        if (Input.GetKey(KeyCode.Q))
        {
            if (liftrange < 50.0f)
            {
                y = lift.transform.position.y + 0.2f;
                lift.transform.position = new Vector3(x, y, z);
                liftrange += 0.2f;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (liftrange > 0.8f)
            {
                y = lift.transform.position.y - 0.2f;
                lift.transform.position = new Vector3(x, y, z);
                liftrange -= 0.2f;
            }
        }
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
