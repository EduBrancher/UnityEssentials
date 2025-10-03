using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    [SerializeField] float rotationSpeed = 30f;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] float audioDelayTimer;
    [SerializeField] GameObject dirtModel;
    [SerializeField] GameObject onCollectEffect;
    float audioDelay = 0f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        audioDelay -= Time.deltaTime;
        
    }

    void OnTriggerEnter(Collider other) {
        if (audioDelay > 0) {
            return;
        }
        if (!other.CompareTag("Player")) {
            return;
        }
        audioSource.PlayOneShot(audioSource.clip);
        audioDelay = audioDelayTimer;
        dirtModel.SetActive(false);
        Instantiate(onCollectEffect, transform.position, transform.rotation);
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
