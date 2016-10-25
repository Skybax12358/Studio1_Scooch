using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CarEngine
{
    public int maxRPM = 7000;
    public int minRPM = 700;
    public float currentRPM;
    public CarControl m_Car;
    float tmpRPM;

    //float speedRang;
    public void updateCurrentRPM()
    {
        tmpRPM = (m_Car.speedInKmH * m_Car.car.transmission.getCurrentGearRatio() *
           m_Car.car.transmission.differentialRatio *(1000/60))
           /
           (m_Car.car.motorWheels[0].wheelCollider.radius* 2*Mathf.PI);
        currentRPM = Mathf.Lerp(currentRPM, tmpRPM, Time.deltaTime +0.1f);
        if (currentRPM < minRPM)
            currentRPM = minRPM;
        if (currentRPM > maxRPM)
            currentRPM = maxRPM;
    }


    public float getEngineTorque()
    {
        if (m_Car.car.hp > 0)
        {
            return getEngineTorque(currentRPM);
        }
        else
        {
            return m_Car.car.RPM_Curve.Evaluate(currentRPM);
        } 
    }

    public float getEngineTorque(float rpm)
    {
        if (rpm > maxRPM)
        {
            return 0;
        }
        else
        {
            return m_Car.car.hp * 5252 / rpm;
        } 
    }
    float currentWheelToreq;

    public float getWheelsTorque()
    {
        currentWheelToreq = getEngineTorque() *
           m_Car.car.transmission.getCurrentGearRatio() *
           m_Car.car.transmission.differentialRatio;

        return currentWheelToreq;
    }
}