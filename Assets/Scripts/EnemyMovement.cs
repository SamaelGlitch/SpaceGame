using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public float speed = 5f;
    public int health = 3; // Vida inicial del enemigo
    public float destructionDistance = 0.5f;
    [SerializeField] GameObject fireVFX;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip dieAudio;
     [SerializeField] private AudioClip hurt;
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
        // Movimiento hacia adelante según la orientación del enemigo
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayDeathSound();
            Die();
        }
        else if (other.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(hurt);
            TakeDamageEnemy(1); // Si choca con una bala, reduce la vida en 1
        }
    }

    private void TakeDamageEnemy(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayDeathSound();
            Die();
        }
    }

    private void PlayDeathSound()
    {
        if (dieAudio != null)
        {
            // Crea un objeto temporal de AudioSource en la posición actual del enemigo
            GameObject tempAudioObject = new GameObject("TempAudio");
            AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();
            tempAudioSource.clip = dieAudio;
            tempAudioSource.Play();

            // Inicia la corrutina para silenciar el audio después de 0.5 segundos
            StartCoroutine(FadeOutAndDestroy(tempAudioSource, 0.5f));
        }
    }

    private IEnumerator FadeOutAndDestroy(AudioSource source, float duration)
    {
        yield return new WaitForSeconds(duration);
        source.volume = 0; // Baja el volumen a 0 después de 0.5 segundos
        Destroy(source.gameObject); // Destruye el objeto temporal
    }

    private void Die()
    {
        // Destruir al enemigo
        Destroy(gameObject);
        GameObject explosion = Instantiate(fireVFX, transform.position, transform.rotation);
        Destroy(explosion, 0.75f);
    }
}