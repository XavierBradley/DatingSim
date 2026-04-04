using UnityEngine;

public class Walking : MonoBehaviour
{
    private Animator anim;

    private Rigidbody rb;

    //sprint/run mode *OPTIONAL*
    [SerializeField]
    private float RunSpeed = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //arrow keys
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        int direction = 4;

        //if player touches a direction, it will increase one of the inputs therefor making isWalking > 0.
        if (input_x > 0)
        {
            direction = 2;
        }
        else if (input_x < 0)
        {
            direction = 3;
        }
        else if (input_y > 0)
        {
            direction = 1;
        }
        else if (input_y < 0)
        {
            direction = 0;
        }




        anim.SetInteger("direction", direction);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * RunSpeed; //Normalized makes it 1 or 0, the time.deltaTime makes it work the frames, and RunSpeed to make your character sprint.
        }
        else
        {
            transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
        }
    }
}
