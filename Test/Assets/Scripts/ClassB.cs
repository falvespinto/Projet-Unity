using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

using DT = Tools.DebugTools;

public class ClassB : MonoBehaviour
{

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DT.Log("Awake" + " " + this.GetType().ToString());
    }


    private void OnEnable()
    {
        DT.Log("OnEnable" + " " + this.GetType().ToString());
    }


    private void OnDisable()
    {
        DT.Log("OnDisable" + " " + this.GetType().ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        DT.Log("Start" + " " + this.GetType().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        DT.Log("Update" + " " + this.GetType().ToString());
    }


    private void FixedUpdate()
    {
        DT.Log("FixedUpdate" + " " + this.GetType().ToString());
    }


    private void LateUpdate()
    {
        DT.Log("LateUpdate" + " " + this.GetType().ToString());
    }


    private void OnDestroy()
    {
        DT.Log("OnDestroy" + " " + this.GetType().ToString());
    }
}
