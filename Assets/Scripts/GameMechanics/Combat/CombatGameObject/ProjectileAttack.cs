using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    private Rigidbody _rb;
    
    private Attack attack;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    public void DoAttack(Vector3 pos, Vector3 dir, Attack attack)
    {   this.attack = attack;
        gameObject.transform.localScale = new Vector3(this.attack.radius,this.attack.radius,this.attack.radius);
        dir.Normalize();
        _rb.isKinematic = false;
        _rb.transform.position = pos;
        _rb.useGravity = attack.useGravity;
        _rb.rotation = Quaternion.LookRotation(dir, Vector3.up);
        _rb.AddForce(dir * attack.speed, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    void Update()
    {
        
    }
}
