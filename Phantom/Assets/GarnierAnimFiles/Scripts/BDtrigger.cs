using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDtrigger : MonoBehaviour
{

    [SerializeField] GameObject BDDisplay;
    [SerializeField] GameObject stamp;
    [SerializeField] GameObject shampoo;
    [SerializeField] GameObject bdAud;
    [SerializeField] BoxCollider2D playerBoxCollider2D;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision == playerBoxCollider2D)
        {
            
            if(Input.GetKey(KeyCode.Return) == true)
            {
                Debug.Log("brrrr");
                BDDisplay.SetActive(true);
                shampoo.SetActive(false);
                stamp.SetActive(false);


                FindObjectOfType<AudioManager>().Play("BDTrigger");

            }
            
        }
    }
}
