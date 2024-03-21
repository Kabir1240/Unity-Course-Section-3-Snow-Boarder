using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay;                       // delay between loading scenes
    [SerializeField] ParticleSystem finishEffect;           // finish line partice effect reference

    bool hasFinished = false;                               // bool to check if player has already finished

    void OnTriggerEnter2D(Collider2D other) 
    {
        // if plyaer goes through finish line and has not finished before
        if (other.tag == "Player" && !hasFinished)
        {
            // Debug.Log("you won");
            // mark player as finished, play effects and audio, disable controls and change scene
            hasFinished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke("ReloadScene", loadDelay);
        }
    }

    // reload scene
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
