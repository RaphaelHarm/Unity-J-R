using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeMoveCamManager : MonoBehaviour
{
    public CinemachineFreeLook cam;

    private int scrollCount = 5;

    public CinemachineFreeLook.Orbit[] orbits;

    void Start()
    {
        orbits = new CinemachineFreeLook.Orbit[3];
        for (int i = 0; i < 3; i++)
        {
            orbits[i].m_Height = cam.m_Orbits[i].m_Height;
            orbits[i].m_Radius = cam.m_Orbits[i].m_Radius;
        }
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0 && scrollCount > 0)
        {
            cam.m_Orbits[0].m_Height -= orbits[0].m_Height / 10;
            cam.m_Orbits[0].m_Radius -= orbits[0].m_Radius / 10;
            cam.m_Orbits[1].m_Height -= orbits[1].m_Height / 10;
            cam.m_Orbits[1].m_Radius -= orbits[1].m_Radius / 10;
            cam.m_Orbits[2].m_Height -= orbits[2].m_Height / 10;
            cam.m_Orbits[2].m_Radius -= orbits[2].m_Radius / 10;
            scrollCount--;
        }
        else if (Input.mouseScrollDelta.y < 0 && scrollCount < 10)
        {
            cam.m_Orbits[0].m_Height += orbits[0].m_Height / 10;
            cam.m_Orbits[0].m_Radius += orbits[0].m_Radius / 10;
            cam.m_Orbits[1].m_Height += orbits[1].m_Height / 10;
            cam.m_Orbits[1].m_Radius += orbits[1].m_Radius / 10;
            cam.m_Orbits[2].m_Height += orbits[2].m_Height / 10;
            cam.m_Orbits[2].m_Radius += orbits[2].m_Radius / 10;
            scrollCount++;
        }
        print(scrollCount);
    }
}
