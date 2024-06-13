using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject bombParticle;
    private AudioSource audioSource;
    public Rigidbody rb;
    public Animator animator;
    float moveSpeed = 2.0f;
    float distance = 0.9f;
    
    public static bool isBlock = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float stick = Input.GetAxis("Horizontal");
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        isBlock = Physics.Raycast(ray, distance);
        if (isBlock == true)
        {
            //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
            isBlock = true;
            animator.SetBool("isJump", false);
        }
        else
        {
            //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
            animator.SetBool("isJump", true);
        }

        Vector3 v = rb.velocity;
        
        if (GoalScript.isGameClear == false)
        {     
            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                v.x = moveSpeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                v.x = -moveSpeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                v.x = 0;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) && isBlock == true)
            {
                v.y = 8.0f;
                isBlock = false; 
            }
            rb.velocity = v;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || stick > 0 || stick < 0)
            {
                animator.SetBool("mode", true);
            }
            else
            {
                animator.SetBool("mode", false);
            }
        }
        else { 
            v.x = 0.0f;
            animator.SetBool("mode", false);
            animator.SetBool("isJump", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            Instantiate(bombParticle, transform.position, Quaternion.identity);
            GameManegerScript.score += 1;
        }  
    }

}
