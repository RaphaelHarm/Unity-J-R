using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    #region ChangeCam
    public Camera thirdPerson;
    public Camera firstPerson;
    public bool isFirstPerson;
    #endregion

    #region FirstPersonCameraMovement
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    #endregion

    #region ThirdPersonMovement
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    #endregion

    #region ThirdPersonScrolling
    public CinemachineFreeLook freeLookCam;

    private int scrollCount = 5;

    private CinemachineFreeLook.Orbit[] orbits;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region ChangeCam
        thirdPerson.enabled = false;
        firstPerson.enabled = true;
        isFirstPerson = true;
        #endregion

        #region FirstPersonCameraMovement
        Cursor.lockState = CursorLockMode.Locked;
        #endregion

        #region ThirdPersonScrolling
        orbits = new CinemachineFreeLook.Orbit[3];
        for (int i = 0; i < 3; i++)
        {
            orbits[i].m_Height = freeLookCam.m_Orbits[i].m_Height;
            orbits[i].m_Radius = freeLookCam.m_Orbits[i].m_Radius;
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region ChangeCam
        if (Input.GetKeyDown(KeyCode.C))
        {
            thirdPerson.enabled = !thirdPerson.enabled;
            firstPerson.enabled = !firstPerson.enabled;
            isFirstPerson = !isFirstPerson;
        }
        #endregion

        if (isFirstPerson)
        {
            #region FirstPersonCameraMovement
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            firstPerson.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            #endregion

            #region FirstPersonMovement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
            #endregion
        }
        else
        {
            #region ThirdPersonScrolling
            freeLookCam.m_Orbits = orbits;
            if (Input.mouseScrollDelta.y > 0 && scrollCount > 0)
            {
                freeLookCam.m_Orbits[0].m_Height -= orbits[0].m_Height / 10;
                freeLookCam.m_Orbits[0].m_Radius -= orbits[0].m_Radius / 10;
                freeLookCam.m_Orbits[1].m_Height -= orbits[1].m_Height / 10;
                freeLookCam.m_Orbits[1].m_Radius -= orbits[1].m_Radius / 10;
                freeLookCam.m_Orbits[2].m_Height -= orbits[2].m_Height / 10;
                freeLookCam.m_Orbits[2].m_Radius -= orbits[2].m_Radius / 10;
                scrollCount--;
            }
            else if (Input.mouseScrollDelta.y < 0 && scrollCount < 10)
            {
                freeLookCam.m_Orbits[0].m_Height += orbits[0].m_Height / 10;
                freeLookCam.m_Orbits[0].m_Radius += orbits[0].m_Radius / 10;
                freeLookCam.m_Orbits[1].m_Height += orbits[1].m_Height / 10;
                freeLookCam.m_Orbits[1].m_Radius += orbits[1].m_Radius / 10;
                freeLookCam.m_Orbits[2].m_Height += orbits[2].m_Height / 10;
                freeLookCam.m_Orbits[2].m_Radius += orbits[2].m_Radius / 10;
                scrollCount++;
            }
            #endregion

            #region ThirdPersonMovement
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            #endregion
        }


    }
}
