using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Attack
{
    public enum Type{
        BEAM,
        PROJECTILE,
        AREA,
        MELEE,
        SPAWN
    }

    public enum DamageType{
        BRUTE = 1,
        MAGIC = 2,
        PIERCE = 4,
        BLUNT = 8
    }
    
    public readonly float lenght;

    public readonly float speed;

    public readonly float damage;

    public readonly float radius;

    public readonly int spawnObjectId;

    public readonly bool useGravity;

    public readonly Type attackType;

    public readonly DamageType damageType;

    public Attack(Type type , DamageType damageType , float lenght , float speed , float damage, float radius, int spawnObjectId, bool useGravity){
        attackType = type;
        this.damageType = damageType;
        this.lenght = lenght;
        this.speed = speed;
        this.damage = damage;
        this.radius = radius;
        this.spawnObjectId = spawnObjectId;
        this.useGravity = useGravity;
    }
}
