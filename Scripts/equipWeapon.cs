using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipWeapon : MonoBehaviour
{
    public GameObject sword;
    public equipStaff staffScript;
    bool weaponEquiped;

    void HitByRay()
    {
        
        sword.SetActive(true);
        gameObject.SetActive(false);
    }
}
