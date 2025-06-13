using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the potion projectile damaging objects with health and deestroying itself on impact or after 3 seconds
/// </summary>

public class PotionProjectile : MonoBehaviour
{
    [SerializeField] private float _potionDamage = 10f;
    [SerializeField] private float _lifetime = 3f;

    private void Start()
    {
        Invoke("DestroySelf", _lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health objectHealth = collision.gameObject.GetComponent<Health>();

        if (objectHealth != null)
        {
            objectHealth.ApplyDamage(_potionDamage);
        }

        DestroySelf();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    //Maybe for later have it switched and have the plague doctor heal people instead necromancer with both potions
}
