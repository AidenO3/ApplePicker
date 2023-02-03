using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public GameObject applePrefab;
    public float dropTime = 1f;
    public float edgeDistance = 30f;
    public float chanceChangeDir = 1;
    public float speed = 5.0f;

    public ScoreCounter scoreCounter;


    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        if (scoreCounter.score >100)
        {
            speed = 0f;
            Vector3 mover = Vector3.zero;
            mover.y = 10f;
            mover.x = Random.Range(-20.0f, 20.0f);
            transform.position = mover;
            Invoke("DropApple", 0);
        }
        else
        {
            dropTime *= 0.99f;
            speed *= 1.04f;
            Invoke("DropApple", dropTime);
        }
    }


    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        Invoke("DropApple", dropTime);
    }

    
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if((pos.x > edgeDistance && speed > 0) || (pos.x < -edgeDistance && speed < 0))
        {
            speed *= -1f;
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (-edgeDistance <= pos.x && pos.x <= edgeDistance && UnityEngine.Random.value < (chanceChangeDir))
        {
            speed *= -1f;
        }
    }
}
