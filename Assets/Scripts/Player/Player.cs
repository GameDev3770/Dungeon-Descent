using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    
    float health;
    public Body body;
    Rot rot;

    void Start()
    {
        health = MaxHealth;
    }

    public void ApplyRot(int[] flags) {
        rot.ModifyRot(flags);
    }

    public void ChangeBody(Body newBody) {
        this.body = newBody;
    }

    public float damage { set { this.health -= value; } }  // Why, IDK, looks different to do it this way so I did it this way.
    public float heal { set { this.health += value; } }


    public bool IsAlive() {
        return this.health > 0 && this.rot.IsAlive();
    }
}
