using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{

    private Animator anim;
    public LootTable potLoot;
    int destroyCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        destroyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MakeLoot()
    {
        if (potLoot != null)
        {
            Powerup current = potLoot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void Smash()
	{
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
        if (destroyCount == 0)
		{
            MakeLoot();
        }
        destroyCount = 1;
    }

    IEnumerator breakCo()
	{
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
	}
}
