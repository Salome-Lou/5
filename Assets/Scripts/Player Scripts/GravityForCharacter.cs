using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForCharacter : MonoBehaviour
{
    private float _ySpeed;
    public float Work(ref CharacterController characterController)
    {
        if (characterController.isGrounded)
        {     
            _ySpeed = 0;
        }
        else
        {
            _ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        return _ySpeed;
    }
}