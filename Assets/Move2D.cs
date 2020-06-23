using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool triggerEntered;
    public bool canEnterLowRoom;
    public bool get_comp;
    public bool get_instruction;


    public KeyCode pressE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (triggerEntered && Input.GetKeyDown(pressE))
        {
            triggerEntered = false;

            SceneManager.LoadScene(1);
        }
        if (get_comp && SceneManager.GetActiveScene().buildIndex == 2)
        {
            get_comp = false;

            SceneManager.LoadScene(3);
        }
        if (get_instruction && SceneManager.GetActiveScene().buildIndex == 0)
        {
            get_instruction = false;

            SceneManager.LoadScene(5);
        }
        if (canEnterLowRoom && Input.GetKeyDown(pressE))
        {
            canEnterLowRoom = false;

            SceneManager.LoadScene(4);
        }


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        transform.position += movement * Time.deltaTime * moveSpeed;

        //Flip Character
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = (float)(-1 * 0.862056);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = (float)(1 * 0.862056);
        }
        transform.localScale = characterScale;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portal")
        {
            triggerEntered = true;
        }
        if (collision.tag == "Computer")
        {
            get_instruction = true;
            get_comp = true;
        }
        if (collision.tag == "Portal3")
        {
            canEnterLowRoom = true;
        }
    }
}
