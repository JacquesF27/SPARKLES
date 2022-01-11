using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChangeMax;
    public Vector2 cameraChangeMin;
    public Vector3 playerChange;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    //public Vector3 playerChangeMin;
    private CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam.minPosition += cameraChangeMin;
            cam.maxPosition += cameraChangeMax;
            other.transform.position += playerChange;

            if (needText)
			{
                StartCoroutine(placeNameCo());
			}
		}
	}

    private IEnumerator placeNameCo()
	{
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
	}
}
