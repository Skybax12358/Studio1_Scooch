using UnityEngine;


[System.Serializable]
public class HandBraking
{

  
    public bool isHandBraked = false;
    public CarControl m_Car;
    public float handBrakeForwardStifftness = 0.5f;// forward stifftness While Hand Braking
    public float handBrakeSideStifftness = 0.2f;// sideward stifftness While Hand Braking

    public void beforStartHandBrakeSimulator()
    {
        for (int i = 0; i < 2; i++)
        {
                m_Car.car.frontWheels[i].wheelCollider.brakeTorque = float.MaxValue;
        }
        isHandBraked = true;
    }

    public void doHandBrake( )
    {
        //wheelsHandBrake(m_Car.car.backWheels);

        wheelsHandBrake(m_Car.car.backWheels);

        isHandBraked = true;
    }

    public void wheelsHandBrake(Wheel[] wheels)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].wheelCollider.brakeTorque = float.MaxValue;

            //Reduce stiffness (Real wheel)
            WheelFrictionCurve frictionCurve = wheels[i].wheelCollider.sidewaysFriction;
            frictionCurve.stiffness = 0.4f;//whatver you want
            wheels[i].wheelCollider.sidewaysFriction = frictionCurve;
        }
    }

    public void releaseHandBrake()
    {
        if(isHandBraked)
        {
            Debug.Log("Handbreak up");
            for (int i = 0; i < 2; i++)
            {
                m_Car.car.backWheels[i].wheelCollider.brakeTorque = 0;

                m_Car.car.frontWheels[i].wheelCollider.brakeTorque = 0;

                Debug.Log("Reset stiffness");

                //Reduce stuffness (Rear wheel)
                WheelFrictionCurve frictionCurve = m_Car.car.backWheels[i].wheelCollider.sidewaysFriction;
                frictionCurve.stiffness = 0.7f;//whatver you want
                m_Car.car.backWheels[i].wheelCollider.sidewaysFriction = frictionCurve;

                //frictionCurve = m_Car.car.frontWheels[i].wheelCollider.sidewaysFriction;
                //frictionCurve.stiffness = 0.7f;//whatver you want
                //m_Car.car.frontWheels[i].wheelCollider.sidewaysFriction = frictionCurve;

            }
            isHandBraked = false;
        }
    }
}
