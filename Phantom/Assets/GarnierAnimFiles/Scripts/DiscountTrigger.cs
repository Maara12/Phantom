using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountTrigger : MonoBehaviour
{
    [SerializeField] GameObject DiscountDisplay;
    [SerializeField] GameObject shampoo;
    [SerializeField] GameObject stamp;
    [SerializeField] BoxCollider2D playerBoxCollider2D;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == playerBoxCollider2D)
        {

            if (Input.GetKey(KeyCode.Return) == true)
            {
                Debug.Log("brrrr");
                DiscountDisplay.SetActive(true);
                shampoo.SetActive(true);
                stamp.SetActive(true);

                FindObjectOfType<AudioManager>().Play("BDTrigger");
            }
        }
    }
}
