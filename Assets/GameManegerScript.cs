using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManegerScript : MonoBehaviour
{
    public GameObject block;

    public GameObject backGroundBlock;

    public GameObject coin;

    public GameObject goal;

    public GameObject goalParticle;

    public GoalScript f;

    public TextMeshProUGUI scoreText;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;

        int[,] map =
        {
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,3,0,1,1,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,3,0,1,0,1,0,0,3,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
            {1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,3,0,0,1,0,0,0,1,0,0,0,1 },
            {1,0,0,0,0,0,0,0,3,0,1,1,1,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,3,0,0,0,0,0,1,1,1,0,0,0,0,0,0,1,1,1,1,1 },
            {1,0,0,0,0,3,0,1,1,0,0,0,0,0,0,1,3,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,1 },
            {1,0,0,0,1,1,0,0,0,0,0,0,0,3,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };

        int LenY = map.GetLength(0);
        int LenX = map.GetLength(1);

        Vector3 position = Vector3.zero;
        
        
        for(int x = 0; x < map.GetLength(1); x++)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                position.y = -y + 5;
                position.x = x;
                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                if (map[y, x] == 2)
                {
                    goal.transform.position = position;
                    goalParticle.transform.position = position;
                }
                if (map[y, x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }

            }
                
        }

        for(int y = 0; y < LenY; y++)
        {
            for(int x=0; x < LenX; x++)
            {
                position.x = x;
                position.y = -y + 5;
                position.z = 3;
                Instantiate(backGroundBlock, position, Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        scoreText.text = "SCORE " + score;

    }
}
