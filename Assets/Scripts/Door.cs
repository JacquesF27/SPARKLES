using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
	public Inventory playerInventory;
	public SpriteRenderer doorSprite;
	public BoxCollider2D physicsCollider;


	private void Update()
	{
		if (Input.GetButtonDown("attack"))
		{
			if (playerInRange && thisDoorType == DoorType.key)
			{
				//does player have key?
				if(playerInventory.numberOfKeys > 0)
				{
					//remove a player key
					playerInventory.numberOfKeys--;
					//if so, then call the open method
					Open();
				}

			}
		}
	}
	public void Open()
	{
		//turn off the doors sprite renderer
		doorSprite.enabled = false;
		//set open to true
		open = true;
		//turn off the door's box collider
		physicsCollider.enabled = false;
	}

    public void Close()
	{
		//turn off the doors sprite renderer
		doorSprite.enabled = true;
		//set open to true
		open = false;
		//turn off the door's box collider
		physicsCollider.enabled = true;
	}
}

public enum DoorType {key, enemy, button }
