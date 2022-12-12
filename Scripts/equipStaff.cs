using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipStaff : MonoBehaviour
{
    public GameObject staff;
    public equipWeapon weaponScript;
    bool staffEquiped;

    void HitByRay()
    {
        staff.SetActive(true);
        gameObject.SetActive(false);
    }
}
