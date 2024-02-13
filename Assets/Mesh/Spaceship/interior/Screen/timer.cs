using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    float countdown=10;
    public TMP_Text tex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown>0){
            countdown-=Time.deltaTime;
        }
        double b=System.Math.Round(countdown,2);
        tex.text=b.ToString();
    }
}
