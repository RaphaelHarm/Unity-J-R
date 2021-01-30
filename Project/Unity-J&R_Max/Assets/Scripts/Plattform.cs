using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plattform : MonoBehaviour
{
    private GameObject[] plattform;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        plattform = GameObject.FindGameObjectsWithTag("Plattform");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed);
    }
}
