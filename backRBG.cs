using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backRBG : MonoBehaviour {
    Camera image;
    byte cont = 10, cont2 = 5, cont3 = 3;
	// Use this for initialization
	void Start () {
        image=GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        if (cont <= 255)
            cont += 10;
        else
            cont -= 10;
        if (cont2 <= 255)
            cont2 += 5;
        else
            cont2 -= 5;
        if (cont3 <= 255)
            cont3 += 3;
        else
            cont3 -= 3;
        image.backgroundColor = new Color32(cont, cont2, cont3, 100);
    }
}
