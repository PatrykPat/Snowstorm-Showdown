using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject snowballPrefab;
    [SerializeField]
    private GameObject gooipunt;
    [SerializeField]
    private float snowballSpeed = 300;
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>(); // Fixed typo in GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    void Shoot()
    {
        GameObject snowball = Instantiate(snowballPrefab, gooipunt.transform.position, transform.rotation);
        snowball.GetComponent<Rigidbody>().AddForce(transform.forward * snowballSpeed);
        Destroy(snowball, 2);
            }
}