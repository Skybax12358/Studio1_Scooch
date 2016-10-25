﻿using UnityEngine;
using System.Collections;

public delegate void OnTCSHandler(Wheel wheel);

[System.Serializable]
public class Wheel
{

    public event OnTCSHandler handleTCS;

    public WheelCollider wheelCollider;
    public Transform wheelTransform;
    public bool isMotor;

    public bool isFront;
    public Car car;

    public float diffrenceForwardFrictionEextremumSlip;
   // public bool is_tcs;

    public CarControl m_Car;


    public float engineTorquePercent = 0.5f; //for AWD Drivetype change this to 0.25f or debending on how much torque the front and back wheels should have

    public float currentengineTorquePercen;

    public Brake brake;



    public void onStart(float brake_force)
    {
        brake = new Brake(this, brake_force, car.accessories.hasABS);
        currentengineTorquePercen = engineTorquePercent;
        diffrenceForwardFrictionEextremumSlip = wheelCollider.forwardFriction.asymptoteSlip 
            - wheelCollider.forwardFriction.extremumSlip;
       // wheelCollider.ConfigureVehicleSubsteps(100, 30, 100);
    }

    public void update()
    {
        updateSpeed();
        updateSpeedInKmH();
        updateSlipRatio();
    }

    public void setTCS_ON()
    {
      //  is_tcs = true;
      if(handleTCS!=null)
        handleTCS(this);
    }
    public void setTCS_OFF()
    {
       // is_tcs = false;
    }

    public void applyLocalPositionToVisuals()
    {
        Transform visualWheel = wheelTransform;
        Vector3 position; Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        visualWheel.rotation = rotation;
        visualWheel.position = position;
    }

    public float speed = 0;
    public void updateSpeed()
    {
        speed = Mathf.Abs( wheelCollider.rpm * wheelCollider.radius * 2 * Mathf.PI) ;
    }
    public float speedInKmH = 0;
    public void updateSpeedInKmH()
    {
        speedInKmH = (speed * 60) / 1000;
    }

    public void applyMotorTorque(float motorTorque)
    {
        wheelCollider.motorTorque = motorTorque * currentengineTorquePercen;
    }

    public float slipRatio=0;
    float maxSpeed;
    public void updateSlipRatio()
    {
        maxSpeed = speedInKmH >= m_Car.speedInKmH ? speedInKmH : m_Car.speedInKmH;

        if (maxSpeed == 0)

            slipRatio = 0;
        else
            slipRatio =Mathf.Abs((speedInKmH- m_Car.speedInKmH) / maxSpeed);
        //Debug.Log(slipRatio);
    }

}