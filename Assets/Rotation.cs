using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotation : MonoBehaviour
{
    public KeyCode pressR;
    public KeyCode pressT;
    //public KeyCode pressRight;

    Rigidbody2D myrb2d;
    public float speed;
    public KeyCode pressF;
    public KeyCode pressE;

    public GameObject bullet;
    public float bulletForce;
    public GameObject explosion;
    //public bool isR_Pressed = true;
    //public bool isT_Pressed = true;
    private bool triggerEntered = false;

    GameManagerScript gm;
    // Start is called before the first frame update
    void Start()
    {
        myrb2d = this.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
    }
    void Update()
    {

        if (triggerEntered && (gm.capsule.Equals(0)))
        {
            triggerEntered = false;

            SceneManager.LoadScene(0);
        }
        if (triggerEntered && (gm.capsule.Equals(1)))
        {
            triggerEntered = false;

            SceneManager.LoadScene(2);
        }
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    temp = 1;
        //}

        //Debug.Log("Message Here");
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Message Here1");

            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up, (UnityEngine.ForceMode2D)bulletForce);
            Destroy(newBullet, 5.0f);
        }

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = (float)(-1 * 0.1709884);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = (float)(1 * 0.1709884);
        }
        transform.localScale = characterScale;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
  
        if (Input.GetKeyDown(pressR))
        {

            myrb2d.AddTorque(speed, ForceMode2D.Force);
            //isR_Pressed = false;
            //isT_Pressed = true;
        }
        if (Input.GetKeyDown(pressT))
        {
            myrb2d.AddTorque(-speed, ForceMode2D.Force);
            //isT_Pressed = false;
            //isR_Pressed = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Capsule")
        {
            gm.capsuleCollected();
            Destroy(collision.gameObject);
            Debug.Log("Capsule collected");

        }
        if (collision.tag == "Portal")
        {
              triggerEntered = true;
        }




    }

}
