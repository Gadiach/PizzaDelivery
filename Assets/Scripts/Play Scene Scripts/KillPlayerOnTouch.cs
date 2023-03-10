using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillPlayerOnTouch : MonoBehaviour
{   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerScript>() != null)
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
