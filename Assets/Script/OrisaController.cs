using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrisaController : MonoBehaviour {
    public float speed;
    float horizontal, vertical,mouseHorizontal,mouseVertical;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mouseHorizontal = Input.GetAxisRaw("Mouse X");
        mouseVertical = Input.GetAxisRaw("Mouse Y");

        OrisaTranslate(new Vector3(horizontal,0,vertical) * speed * Time.deltaTime);
        OrisaCameraMove(new Vector3(-mouseVertical, mouseHorizontal, 0) * 30 * Time.deltaTime);
    }


    void OrisaTranslate(Vector3 translation)
    {
        transform.Translate(translation);
    }

    void OrisaCameraMove(Vector3 rotation)
    {
        transform.Rotate(rotation,Space.Self);
    }
   
}
