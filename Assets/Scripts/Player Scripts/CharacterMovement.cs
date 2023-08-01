using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement: MonoBehaviour
{
    [SerializeField] private float _speed;

    public GravityForCharacter CharacterGravity;
    public Animator Animator;

    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction) 
    {
        if (direction != Vector3.zero) 
        {
            Animator.SetFloat("speed", Vector3.ClampMagnitude(direction, 1f).magnitude);
        }

        Vector3 velocity = direction * _speed;
        velocity.y = CharacterGravity.Work(ref _characterController);
        _characterController.Move(velocity * Time.deltaTime);
    }
}
