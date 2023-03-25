using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTrigger : MonoBehaviour
{
    [SerializeField] GameObject UsageDisplay;
    [SerializeField] BoxCollider2D playerBoxCollider2D;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == playerBoxCollider2D)
        {

            if (Input.GetKey(KeyCode.Return) == true)
            {
                Debug.Log("brrrr");
                UsageDisplay.SetActive(true);

                FindObjectOfType<AudioManager>().Play("ProductUsage");
            }
        }
    }
}
