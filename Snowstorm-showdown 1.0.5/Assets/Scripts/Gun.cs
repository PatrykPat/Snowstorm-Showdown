using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject snowballPrefab;
    [SerializeField]
    private GameObject gooipunt;
    [SerializeField]
    private float snowballSpeed = 300;

    [SerializeField]
    private AudioClip shootSound; // Sound clip for shooting

    private void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        _audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the Gun
    }

    private void Update()
    {
        if (_input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    private void Shoot()
    {
        GameObject snowball = Instantiate(snowballPrefab, gooipunt.transform.position, transform.rotation);
        snowball.GetComponent<Rigidbody>().AddForce(transform.forward * snowballSpeed);
        Destroy(snowball, 2);

        if (shootSound != null)
        {
            _audioSource.PlayOneShot(shootSound); // Play the shoot sound
        }
    }
}