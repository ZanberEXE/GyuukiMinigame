using UnityEngine;
using UnityEngine.UI;

public class GyuukiBehaviour : MonoBehaviour
{
    //public Vector3 gyuukiVelocity;
    public float gyuukiSpeed = 3.0f;

    private Rigidbody2D rb;
    private Collider2D col;
    private GameObject gyuukiPlayer;
    private GameObject controllerToggle;

    private Vector3 destMousePos;
    

    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        col = GetComponentInChildren<Collider2D>();

        gyuukiPlayer = GetComponent<GameObject>();
        controllerToggle = GameObject.Find("ToggleKBM"); //Find Toggle for Controller

        destMousePos = transform.position;
    }

    void Update()
    {
        if(controllerToggle.GetComponent<Toggle>().isOn == true)
            MoveGyuukiKeys();   //KeyboardMovement
        else 
            MoveGyuukiToMouse(); //MouseMovement
    }

    private void MoveGyuukiToMouse()
    {
        if (Input.GetMouseButton(0)) 
        {
            destMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destMousePos.z = transform.position.z;  
        }
        transform.position = Vector3.MoveTowards(transform.position, destMousePos, gyuukiSpeed * Time.deltaTime);
    }

    private void MoveGyuukiKeys()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        rb.velocity = Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * gyuukiSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * gyuukiSpeed * Time.deltaTime);
        }
        
        destMousePos = transform.position;
    }
}
