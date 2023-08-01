using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorCharacterDirection : MonoBehaviour
{  
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _rotationSpeed;

    public CharacterMovement Movement;
   
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        Movement.Move(direction);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
