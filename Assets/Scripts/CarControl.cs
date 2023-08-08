using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{

    private bool checkpoint0;
    private bool checkpoint1;
    private bool checkpoint2;
    private bool checkpoint3;

    public bool Checkpoint0 { get { return this.checkpoint0; } set { this.checkpoint0 = value; } }
    public bool Checkpoint1 { get { return this.checkpoint1; } set { this.checkpoint1 = value; } }
    public bool Checkpoint2 { get { return this.checkpoint2; } set { this.checkpoint2 = value; } }
    public bool Checkpoint3 { get { return this.checkpoint3; } set { this.checkpoint3 = value; } }

    //Переменные для чтения инпутов
    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;

    //Тормозная сила и поворот колеса
    private float currentbreakForce;
    private float currentSteerAngle;

    //Параметры машины
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;


    //Указать колеса машины
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    
    [SerializeField] private GameObject rearLeftWheelEffect;
    [SerializeField] private GameObject rearRightWheelEffect;

    [SerializeField] private ParticleSystem rearLeftWheelSmoke;
    [SerializeField] private ParticleSystem rearRightWheelSmoke;

    //Центр массы
    private Vector3 _centerOfMass;
    private void Start()
    {
        checkpoint0=false;
        checkpoint1=false;
        checkpoint2=false;
        checkpoint3=false;
        GetComponent<Rigidbody>().centerOfMass=_centerOfMass;
    }


    //Вызов всех методов
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        WheelEffects();
    }
    
    //Чтение инпутов
    private void GetInput()
    {
        //Чтение осей
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");

        //Чтение тормоза
        isBreaking=Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        //крутящий момент двигателя, опираясь на выставленные параметры
        frontLeftWheelCollider.motorTorque=verticalInput*motorForce;
        frontRightWheelCollider.motorTorque=verticalInput*motorForce;
        
        //Если нажат тормоз, тормозной момент равен выставленной тормозной силе, иначе нулю
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    //Торможение
    private void ApplyBreaking()
    {
        rearLeftWheelCollider.brakeTorque=currentbreakForce;
        rearRightWheelCollider.brakeTorque=currentbreakForce;
        
    }

    //Поворот колес
    private void HandleSteering()
    {
        currentSteerAngle=maxSteerAngle*horizontalInput;
        frontLeftWheelCollider.steerAngle=Mathf.Lerp(frontLeftWheelCollider.steerAngle,currentSteerAngle,0.6f);
        frontRightWheelCollider.steerAngle=Mathf.Lerp(frontRightWheelCollider.steerAngle,currentSteerAngle,0.6f);
    }


    private void UpdateWheels()
    {
        //Движение колес в точности как их коллайдеры
        UpdateSingleWheel(frontLeftWheelCollider,frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider,frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider,rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider,rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        //Получение положений колес в пространстве 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position=pos;
        wheelTransform.rotation=rot;
    }

    private void WheelEffects() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rearLeftWheelEffect.GetComponentInChildren<TrailRenderer>().emitting=true;
            rearRightWheelEffect.GetComponentInChildren<TrailRenderer>().emitting=true;

            rearLeftWheelSmoke.Emit(1);
            rearRightWheelSmoke.Emit(1);
        }
        else
        {
            rearLeftWheelEffect.GetComponentInChildren<TrailRenderer>().emitting=false;
            rearRightWheelEffect.GetComponentInChildren<TrailRenderer>().emitting=false;
        }
    }
}
