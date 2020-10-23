using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] float m_TranslationSpeed;
    [Tooltip("rotation speed in °/s")]
    [SerializeField] float m_RotSpeed;

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
        
    }

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

        //Vector3 moveVect =vAxis * m_Transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;

        //m_Rigidbody.MovePosition(m_Rigidbody.position+moveVect);


        Vector3 newVelocity = vAxis * m_Transform.forward * m_TranslationSpeed;
        Vector3 deltaVelocity = newVelocity - m_Rigidbody.velocity;
        m_Rigidbody.AddForce(deltaVelocity, ForceMode.VelocityChange);

        //Rotation
        //1

        float rotAngle = hAxis * m_RotSpeed * Time.fixedDeltaTime;

        Quaternion qRot = Quaternion.AngleAxis(rotAngle, m_Transform.up);
        Quaternion targetOrientation = qRot * m_Rigidbody.rotation;

        Quaternion qStraightRotQuaternion = Quaternion.FromToRotation(m_Transform.up, Vector3.up);


        Quaternion newOrientation = Quaternion.RotateTowards(targetOrientation, qStraightRotQuaternion, Time.fixedDeltaTime);
        //Quaternion.Lerp(m_Rigidbody.rotation, qStraightRot * qRot * m_Rigidbody.rotation, Time.fixedDeltaTime*4);
        m_Rigidbody.MoveRotation(targetOrientation);


        //2

        //Vector3 newAngularVelocity =hAxis* m_Transform.up * m_RotSpeed*Mathf.Deg2Rad;
        //Vector3 deltaAngularVelocity = newAngularVelocity - m_Rigidbody.angularVelocity;
        //m_Rigidbody.AddTorque(deltaAngularVelocity, ForceMode.VelocityChange);
    }

}
