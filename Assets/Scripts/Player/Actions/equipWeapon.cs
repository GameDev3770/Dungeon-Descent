using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipWeapon : MonoBehaviour
{
    public GameObject sword;

    void HitByRay()
    {
        sword.SetActive(true);
        Destroy(gameObject);
    }
}
