using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    [SerializeField] float m_LifeDuration;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_LifeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Message de collision dans la console
        //Debug.Log(collision.gameObject.name + " COLLIDED WITH " + name);

        //Changement de couleu66r
        MeshRenderer mr = collision.gameObject.GetComponentInChildren<MeshRenderer>();
        if(mr)
            mr.material.color = Random.ColorHSV();
    }
    private void OnTriggerEnter(Collider other)
    {

        other.transform.localScale *= 1.1f;

    }
    private void OnTriggerExit(Collider other)
    {

        other.transform.localScale /= 1.1f;

    }
}
