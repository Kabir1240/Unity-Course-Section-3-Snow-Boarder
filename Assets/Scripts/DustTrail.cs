using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrail;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // plays dustrail every time player is on the ground
        if (collision.gameObject.tag == "Ground") 
        {
            dustTrail.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // stops dust trail every time player takes off the ground or is in the air
        if (collision.gameObject.tag == "Ground")
        {
            dustTrail.Stop();
        }
    }
}
