using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [Header("Translation & Rotation")]
    [SerializeField] float m_TranslationSpeed;
    [Tooltip("rotation speed in °/s")]
    [SerializeField] float m_RotSpeed;

    [Header("Ball Shot")]
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPoint;
    [SerializeField] float m_BallInitTranslationSpeed;
    [SerializeField] float m_BallShotCooldownDuration;


    float m_BallShotNextTime;


    Transform m_Transform;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_BallShotNextTime = Time.time;
    }
    //
    //Update is called once per frame
    //void Update()
    //{
    //    float hAxis = Input.GetAxis("Horizontal");
    //    float vAxis = Input.GetAxis("Vertical");
    //    //Vector3 moveVect = m_Transform.forward * m_TranslationSpeed * Time.deltaTime;
    //    Vector3 moveVect = vAxis*Vector3.forward* m_TranslationSpeed * Time.deltaTime;
    //    //transform.position += moveVect;
    //    m_Transform.Translate(moveVect, Space.Self);

    //    float rotAngle = hAxis * m_RotSpeed * Time.deltaTime;
    //    m_Transform.Rotate(m_Transform.up, rotAngle, Space.World);
    //}

    //void Update()
    //{
    //    float hAxis = Input.GetAxis("Horizontal");
    //    float vAxis = Input.GetAxis("Vertical");

    //    Vector3 moveVect =Vector3.ClampMagnitude(new Vector3(hAxis,0,vAxis),1) * m_TranslationSpeed * Time.deltaTime;

    //    m_Transform.Translate(moveVect, Space.Self);


    //}

    private void FixedUpdate()
    {
        //comportement dynamique
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        bool isFiring = Input.GetButton("Fire1");


        //Translation
        //Vector3 moveVect =vAxis * m_Transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;
        //m_Rigidbody.MovePosition(m_Rigidbody.position+moveVect);


        Vector3 newVelocity = vAxis * m_Transform.forward * m_TranslationSpeed;
        Vector3 deltaVelocity = newVelocity - m_Rigidbody.velocity;
        m_Rigidbody.AddForce(deltaVelocity, ForceMode.VelocityChange);

        //Rotation
        //1

        //float rotAngle = hAxis * m_RotSpeed * Time.fixedDeltaTime;

        //Quaternion qRot = Quaternion.AngleAxis(rotAngle, m_Transform.up);
        //Quaternion targetOrientation = qRot * m_Rigidbody.rotation;

        //Quaternion qStraightRotQuaternion = Quaternion.FromToRotation(m_Transform.up, Vector3.up);


        //Quaternion newOrientation = Quaternion.RotateTowards(targetOrientation, qStraightRotQuaternion, Time.fixedDeltaTime);
        ////Quaternion.Lerp(m_Rigidbody.rotation, qStraightRot * qRot * m_Rigidbody.rotation, Time.fixedDeltaTime*4);
        //m_Rigidbody.MoveRotation(targetOrientation);


        //2

        Vector3 newAngularVelocity =hAxis* m_Transform.up * m_RotSpeed*Mathf.Deg2Rad;
        Vector3 deltaAngularVelocity = newAngularVelocity - m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(deltaAngularVelocity, ForceMode.VelocityChange);



        //Firing Balls

        if (isFiring && Time.time > m_BallShotNextTime)
        {
            ShootBall();
            m_BallShotNextTime = Time.fixedTime+m_BallShotCooldownDuration;
        }
            
    }

    void ShootBall()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnPoint.position;
        Rigidbody newBallRB = newBallGO.GetComponent<Rigidbody>();
        newBallRB.AddForce(m_BallSpawnPoint.forward * m_BallInitTranslationSpeed, ForceMode.VelocityChange);

    }

}
