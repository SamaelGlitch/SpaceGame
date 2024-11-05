using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject bulletPrefab;
    public float shootspeed = 10;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip shoot;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, spawnpoint.position, spawnpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * shootspeed;
            audioSource.PlayOneShot(shoot);
            Destroy(bullet, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
