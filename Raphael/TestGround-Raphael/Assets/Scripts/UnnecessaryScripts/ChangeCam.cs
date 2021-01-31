using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera thirdPerson;
    public Camera firstPerson;
    public bool isFirstperson;

    // Start is called before the first frame update
    void Start()
    {
        thirdPerson.enabled = false;
        firstPerson.enabled = true;
        isFirstperson = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            thirdPerson.enabled = !thirdPerson.enabled;
            firstPerson.enabled = !firstPerson.enabled;
            isFirstperson = !isFirstperson;
        }
    }
}
