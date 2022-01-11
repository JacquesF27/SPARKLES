using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    
    public Text dialogText;
    public string dialog;
    public GameObject dialogBox;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetButtonDown("attack") && playerInRange)
		{
            if(dialogBox.activeInHierarchy)
			{
                dialogBox.SetActive(false);
			}
			else
			{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
			}
		}
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            base.OnTriggerExit2D(other);
            dialogBox.SetActive(false);
        }
    }
}
