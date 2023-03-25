using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeDoorTrigger : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerCollider2D;
    [SerializeField] GameObject playerObject;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == playerCollider2D)
        {
            if (Input.GetKey(KeyCode.Return) == true)
            {
                playerObject.SetActive(false);
                //add scene4 transition here

                FindObjectOfType<AudioManager>().Play("DoorEntry");

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
