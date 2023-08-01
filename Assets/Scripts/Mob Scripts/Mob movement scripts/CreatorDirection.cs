using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorDirection : MonoBehaviour
{
    public Transform TargetTransform;
    public PhysicsMovement physicsMovement;
    void Update()
    {
        transform.LookAt(new Vector3(TargetTransform.position.x,transform.position.y, TargetTransform.position.z));
        physicsMovement.Move(transform.forward);       
    }
}
