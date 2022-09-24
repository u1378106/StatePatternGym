using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (this.gameObject.name == "Ring")
                audioManager.collectAudio.Play();
            else if(this.gameObject.name == "Enemy")
                audioManager.destroyAudio.Play();

            Destroy(this.gameObject);
        }
        
    }
}
