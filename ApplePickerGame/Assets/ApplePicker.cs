using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    public GameObject BasketPrefab;
    public int height = -10;
    public Lives livescounter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject basketGO = Instantiate<GameObject>(BasketPrefab);
        Vector3 pos = Vector3.zero;
        pos.y = height;
        BasketPrefab.transform.position = pos;
        GameObject livesGO = GameObject.Find("Lives");
        livescounter = livesGO.GetComponent<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AppleMissed()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in apples)
        {
            Destroy(tempGO);
        }
        livescounter.lives += -1;
        if (livescounter.lives == 0)
        {
            SceneManager.LoadScene("mainGame");
        }
    }
    
}
