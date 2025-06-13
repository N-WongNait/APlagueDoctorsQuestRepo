using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _fireForce = 10.0f;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileSpawnPoint;

    private float _timeStamp;
    public bool IsActiveStaff; 

    void Shoot()
    {
        if (IsActiveStaff)
        {
            if (Time.time > _timeStamp + _fireRate)
            {
                _timeStamp = Time.time;

                GameObject instantiatedObject = Instantiate(_projectile, _projectileSpawnPoint.transform.position, _projectileSpawnPoint.transform.rotation);

                Physics.IgnoreCollision(instantiatedObject.GetComponentInChildren<Collider>(), gameObject.GetComponentInChildren<Collider>());
                instantiatedObject.GetComponent<Rigidbody>().velocity = _projectileSpawnPoint.transform.forward * _fireForce;
            }
        }
    }
}
