using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeMoveCamManager : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public float orbitMultiplier = 1;

    private List<float> heights;

    private void Start()
    {
        heights = new List<float>()
        {
            cam.m_Orbits[0].m_Height,
            cam.m_Orbits[0].m_Height,
            cam.m_Orbits[0].m_Height
        };
    }

    // Update is called once per frame
    void Update()
    {
        orbitMultiplier = Input.mouseScrollDelta.y;

        /*
        if (Input.mouseScrollDelta.y > 0)
        {
            orbitMultiplier = 
        }
        cam.m_Orbits[0].m_Height += orbitMultiplier / 10;
        cam.m_Orbits[0].m_Radius += orbitMultiplier;
        cam.m_Orbits[1].m_Height += orbitMultiplier / 10;
        cam.m_Orbits[1].m_Radius += orbitMultiplier;
        cam.m_Orbits[2].m_Height += orbitMultiplier / 10;
        cam.m_Orbits[2].m_Radius += orbitMultiplier;
        */

        orbitMultiplier = 0;
    }
}
