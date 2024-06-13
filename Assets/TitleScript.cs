using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject hitKey;
    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer <=100)
        {
            hitKey.SetActive(true);
        }
        else if(timer>=200)
        {
            hitKey.SetActive(false);
        }
        if (timer >= 200)
        {
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
