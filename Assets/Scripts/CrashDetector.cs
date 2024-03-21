using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay;                           // the delay between relaoding scene
    [SerializeField] ParticleSystem crashEffect;                // crash effect particle system reference
    [SerializeField] AudioClip crashSFX;                        // crash sound clip reference

    // check to see if player has crashed or not
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        // if player crashes and has not crashed before
        if (other.tag == "Ground" && !hasCrashed)
        {
            // Debug.Log("you won);
            // set player to have crashed, play audio clip and particle effect, disable controls and reset scene
            hasCrashed = true;
            crashEffect.Play();
            FindObjectOfType<PlayerController>().DisableControls();         // you could use a serialized field for this too.
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    // method to reload scene
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
