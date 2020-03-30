using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    public ProjectileAttack projectileAttackPrefab;

    public static AttackSpawner Instance{
        get => _instance;
        private set => _instance = value;
    }
    private static AttackSpawner _instance;


    // Start is called before the first frame update
    void Awake()
    {   
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public ProjectileAttack SpawnProjectile(Vector3 pos, Vector3 dir , Attack attack){
        var att = Instantiate(projectileAttackPrefab, Vector3.zero , Quaternion.identity);
        att.DoAttack(pos,dir,attack);
        return att;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
