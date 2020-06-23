using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public KeyCode pressJ;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        transform.position += movement * Time.deltaTime * moveSpeed;

        //Flip Character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = (float)(-1 * 0.186147);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = (float)(1 * 0.186147);
        }
        transform.localScale = characterScale;
    }

    public void Jump()
    {
        if(Input.GetKeyDown(pressJ))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
    
}