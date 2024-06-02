using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public GameObject effect;

    private CharacterController controller;
    private Animator anim;
    private CapsuleCollider col;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private Text crystalText;
    [SerializeField] private Text crystalText_02;
    [SerializeField] private Text crystalText_03;

    private int lineToMove = 1;
    public float lineDistance = 4;
    public static int crystals;
    public static int crystals_02;
    public static int crystals_03;
    private float maxSpeed = 110;

    private bool slide;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrease());
        col = GetComponent<CapsuleCollider>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
            JumpToTheSide();
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
            JumpToTheSide();
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                Jump();
        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (controller.isGrounded && !slide)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

    }

    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetTrigger("jump");
    }

    private void JumpToTheSide()
    {
        anim.SetTrigger("Jump_To_The_Side");
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (hit.gameObject.tag == "Finish")
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        } else if(hit.gameObject.tag == "Lose")
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crystal")
        {
            crystals++;
            crystalText.text = crystals.ToString();
            Destroy(other.gameObject);
        }
            //Instantiate(effect, other.gameObject.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        

        if (other.gameObject.tag == "Crystal_02")
        {
            crystals_02++;
            crystalText_02.text = crystals_02.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Crystal_03")
        {
            crystals_03++;
            crystalText_03.text = crystals_03.ToString();
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(1);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }

    private IEnumerator Slide()
    {
        col.center = new Vector3(0, 0.5f, 0);
        col.height = 1.2f;
        slide = true;
        anim.SetTrigger("slide");

        yield return new WaitForSeconds(1);

        col.center = new Vector3(0, 0.875908f, 0);
        col.height = 1.840869f;
        slide = false;
    }
}