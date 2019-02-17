using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed;     /*public float biður um speed input í inspectornum*/
    public Text countText;
    public Text winText;

    private Rigidbody rb;   /*private býr til variable sem hefur bara aðgang að í gegnum skriftu*/
    private int count;

    void Start()            /*void start er kóði keyrður einu sinni í byrjun skriftu*/
    {
        rb = GetComponent<Rigidbody>();     /*rb variable nær í rigidbody component*/
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()      /*FixedUpdate er keyrður í loop til að reikna leikjar physics*/
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);     /*alltaf áður en physics er reiknað er kíkt á hvort að það er input fyrir hreyfingu og það er keyrt*/

        rb.AddForce(movement * speed);      /*speed variable margfaldar hraðan sem er notað til að ýta player object*/
    }

    void OnTriggerEnter(Collider other)     /*OnTriggerEnter er keyrður þegar leikurinn sér að player object hefur snert Collider "other"*/
    {
        if (other.gameObject.CompareTag("Collectable"))     /*Game Object með tag Collectable muna vera de-activateuð*/
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText () /*Þessi void er function*/
    {
        countText.text = "Count: " + count.ToString();

        if (count == 5)
        {
            winText.text = "You Win!";
        }
    }
}