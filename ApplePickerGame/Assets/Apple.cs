using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);

            ApplePicker apSCript = Camera.main.GetComponent<ApplePicker>();
            apSCript.AppleMissed();
        }
    }
}
