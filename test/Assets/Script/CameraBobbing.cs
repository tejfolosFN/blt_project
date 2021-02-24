using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraBobbing : MonoBehaviour
{
    public Animator cameraAnimator; //"Camera bobbing" animáció miatt
    bool startsound = false;
    
    void Update()
    {
        if (RigidbodyFirstPersonController.m_IsGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            cameraAnimator.SetBool("isMoving", true);
            if (!startsound) playerrun();
            startsound = true;
        }
        else
        {
            cameraAnimator.SetBool("isMoving", false);
            startsound = false;
            FindObjectOfType<AudioManager>().Pause("PlayerRun");
        }
    }
    void playerrun()
    {
        FindObjectOfType<AudioManager>().Play("PlayerRun");
    }
}
