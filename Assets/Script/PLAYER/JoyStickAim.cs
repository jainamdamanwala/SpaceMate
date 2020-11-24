using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickAim : MonoBehaviour
{
    public CharacterController2D dir;
    public Joystick joystick;
    public Transform twistpoint;

    public float returnTime = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
    public void Aim()
    {
        Vector3 angle = twistpoint.transform.localEulerAngles;

        float HorizontalAxis = joystick.Horizontal;
        float VerticalAxis = joystick.Vertical;

        if (dir.m_FacingRight)
        {
            if(HorizontalAxis == 0f && VerticalAxis == 0f)
            {
                Vector3 currentRotation = twistpoint.transform.localEulerAngles;
                Vector3 homeRotation;

                if(currentRotation.z > 180f)
                {
                    homeRotation = new Vector3(0f, 0f, 359.999f);
                }
                else
                {
                    homeRotation = Vector3.zero;
                }
                twistpoint.transform.localEulerAngles = Vector3.Slerp(currentRotation, homeRotation, Time.deltaTime * returnTime);
            }

            else
            {
                twistpoint.transform.localEulerAngles = new Vector3(0f,0f,Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180/Mathf.PI + 90f);
            }

            if(angle.z > 90 && angle.z < 200)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 89));
                dir.Flip();
            }            
            if(angle.z < 270 && angle.z > 200)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 271));
                dir.Flip();
            }

           
        }
        if (dir.m_FacingRight == false)
        {
            if (HorizontalAxis == 0f && VerticalAxis == 0f)
            {
                Vector3 currentRotation = twistpoint.transform.localEulerAngles;
                Vector3 homeRotation;

                if (currentRotation.z > 180f)
                {
                    homeRotation = new Vector3(0f, 0f, 359.999f);
                }
                else
                {
                    homeRotation = Vector3.zero;
                }
                twistpoint.transform.localEulerAngles = Vector3.Slerp(currentRotation, homeRotation, Time.deltaTime * returnTime);
            }

            else
            {
                twistpoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);
            }

            if (angle.z > 90 && angle.z < 200)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 89));
                dir.Flip();
            }
            if (angle.z < 270 && angle.z > 200)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 271));
                dir.Flip();
            }
        }
    }
}
