using UnityEngine;


public class Scr_PlayerCarInput : MonoBehaviour
{
    private CarControl m_Car; 

    float input_H;
    float accel;
    float brake;
    float handbrake;
    float revears;
    bool toggleDriftSystem;
    const string Horizontal_KEY = "Horizontal_Stick";
    const string Vertical_KEY = "Acceleration";
    const string NITRO_KEY = "Fire2";
    const string HANDBRAKE_KEY = "Handbreak";
    //const string DRIFT_SYSTEM_KEY = KeyCode.A;
    bool activeNitro;

    
    void Start()
    {
        m_Car = GetComponent<CarControl>();
    }

    void Update()
    {
        toggleDriftSystem = Input.GetKeyUp(KeyCode.A);
        if (toggleDriftSystem)
        {
            m_Car.toggleDriftSystem();
        }    
    }

 

    void FixedUpdate()
    {
        input_H =  Input.GetAxis(Horizontal_KEY) ;
        accel = brake = Input.GetAxis(Vertical_KEY) ;

        //Activate handbreak
        handbrake = Input.GetAxis(HANDBRAKE_KEY);
        
        //Pass the input to the car!
        m_Car.Move(input_H, accel, brake, handbrake);

        //Activate nitro
        activeNitro = Input.GetButton(NITRO_KEY);
        m_Car.nitro(activeNitro);
    }
}

