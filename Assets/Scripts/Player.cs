using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed;
    public KeyCode rightKey, leftKey, upKey, downKey;
    public GameObject trashObj;
    public Transform[] emitters;
    public float initFireRate;
    private float fireRate;
    bool isShooting = true;
    public float trashSpeed;

    public float bottomOfScreen = -5f;
    // Use this for initialization
    void Start()
    {
        fireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (transform.position.y > bottomOfScreen)
        {
            if (gameObject.tag == "player1"){
                SceneManager.LoadScene("endScene");
            }
            else
            {
                SceneManager.LoadScene("endScene2");
            }

        }
        if (fireRate > 0)
        {
            fireRate -= Time.deltaTime;
            isShooting = false;
        }

    }

    void MovePlayer()
    {
        if (fireRate <= 0)
        {
            isShooting = true;
            fireRate = initFireRate;


            if (Input.GetKey(rightKey))
            {
                GameObject newTrash = (GameObject)Instantiate(trashObj, emitters[2].position, Quaternion.identity);
                Rigidbody2D r = newTrash.GetComponent<Rigidbody2D>();
                r.velocity = transform.right * trashSpeed;
                Debug.Log(r.velocity);
            }
            if (Input.GetKey(leftKey))
            {
                GameObject newTrash = (GameObject)Instantiate(trashObj, emitters[3].position, Quaternion.identity);
                Rigidbody2D r = newTrash.GetComponent<Rigidbody2D>();
                r.velocity = -transform.right * trashSpeed;
            }
            if (Input.GetKey(upKey))
            {
                GameObject newTrash = (GameObject)Instantiate(trashObj, emitters[0].position, Quaternion.identity);
                Rigidbody2D r = newTrash.GetComponent<Rigidbody2D>();
                r.velocity = transform.up * trashSpeed;
            }

            if (Input.GetKey(downKey))
            {
                GameObject newTrash = (GameObject)Instantiate(trashObj, emitters[1].position, Quaternion.identity);
                Rigidbody2D r = newTrash.GetComponent<Rigidbody2D>();
                r.velocity = -transform.up * trashSpeed;
            }

        }

    }

}
