using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnitController;

public abstract class StdUnit : Unit
{

    protected NavMeshAgent agent;

    public virtual void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
            Debug.LogWarning("Unit " + GetHashCode() + " has no NavMeshAgent all MoveTo commands will be ignored");
    }

    public override void MoveTo(Vector3 pos)
    {
        if(agent == null || !agent.isOnNavMesh) return;
        agent.SetDestination(pos);
    }

    public override void Move(Vector3 dir)
    {
        if(isGrounded){
            rb.AddForce(rb.transform.forward * moveSpeed , ForceMode.VelocityChange);
        }
        rb.rotation = Quaternion.Lerp(rb.rotation,  Quaternion.LookRotation(dir, Vector3.up),Time.deltaTime * 15);

        float projectedSpeed = Vector3.Dot(rb.velocity, transform.forward);
        if(projectedSpeed > maxMoveSpeed){
            Vector3 projectedVector = (transform.forward * projectedSpeed).normalized * maxMoveSpeed;
            projectedVector.y = rb.velocity.y;
            rb.velocity = projectedVector;
        }
    }

    public override void DoStop()
    {
        if(!isGrounded) return;
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }
    
    public override void Jump()
    {
        if(isGrounded)
            rb.velocity += Vector3.up * jumpSpeed;
    }
}
