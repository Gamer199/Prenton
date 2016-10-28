using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Collections;

public class PlayerControll : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public AudioClip countSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    public AudioClip backgroundSound;

    private Rigidbody2D rb2d;
    private int count;
    private System.Random rnd = new System.Random();
    private int invertCheck = 0;
    private float MoveHorizontal;
    private float MoveVertical;
    private AudioSource audioScount;
    private AudioSource audioSlose;
    private AudioSource audioSwin;
    private AudioSource audioSbackground;
    private float lowRange = 0.75F;
    private float highRange = 1F;

    void Awake()
    {
        audioScount = GetComponent<AudioSource>();
        audioSlose = GetComponent<AudioSource>();
        audioSwin = GetComponent<AudioSource>();
        audioSbackground = GetComponent<AudioSource>();
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        //Generel.currentScore = 0;
        winText.text = "";
        SetCountText();
        audioSbackground.PlayOneShot(backgroundSound, 0.5F);
    }
    void FixedUpdate()
    {
        if (invertCheck == 0)
        {
            MoveHorizontal = Input.GetAxis("Horizontal");
            MoveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            MoveHorizontal = Input.GetAxis("Vertical");
            MoveVertical = Input.GetAxis("Horizontal");
        }
        Vector2 movement = new Vector2(MoveHorizontal, MoveVertical);
        rb2d.AddForce(movement * speed);
        if (audioSbackground.isPlaying == false)
        {
            audioSbackground.PlayOneShot(backgroundSound, 1F);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        String[] pool = new String[] { "PickUpYellow", "PickUpGreen", "PickUpBlue", "PickUpOrange", "PickUpPurple", "PickUpMagenta", "PickUpCyan", "PickUpLime" };
        if (other.gameObject.tag.Substring(0, 6) == "PickUp")
        {
            other.gameObject.SetActive(false);
            //Generel.currentScore++;
            if (other.gameObject.tag != "PickUpRed")
            {
                count++;
                SetCountText();
                float vol = UnityEngine.Random.Range(lowRange, highRange);
                audioScount.PlayOneShot(countSound, vol);
            }
            if (other.gameObject.tag == "PickUpBlack") other.gameObject.tag = pool[rnd.Next(0, pool.Length)];
                switch (other.gameObject.tag)
            {
                case "PickUpYellow":
                    break;
                case "PickUpGreen":
                    StartCoroutine(speedTimeGreen());
                    break;
                case "PickUpRed":
                    audioSlose.PlayOneShot(loseSound, 1F);
                    winText.text = "You Died!";
                    float scale3 = 0.001F;
                    transform.localScale = new Vector3(scale3, scale3, scale3);
                    rb2d.isKinematic = true;
                    break;
                case "PickUpBlue":
                    StartCoroutine(speedTimeBlue());
                    break;
                case "PickUpOrange":
                    StartCoroutine(speedTimeOrange());
                    break;
                case "PickUpPurple":
                    StartCoroutine(speedTimePurple());
                    break;
                case "PickUpMagenta":
                    StartCoroutine(speedTimeMagenta());
                    break;
                case "PickUpCyan":
                    //count = count +  9;
                    SetCountText();
                    break;
                case "PickUpLime":
                    StartCoroutine(speedTimeLime());
                    break;
                default:
                    break;
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 21)
        {
            audioSbackground.Stop();
            audioSwin.PlayOneShot(winSound, 1F);
            winText.text = "You Win!";
        }
    }

    IEnumerator speedTimeGreen()
    {
        speed *= 3;
        yield return new WaitForSeconds(15);
        speed /= 3;
    }

    IEnumerator speedTimeBlue()
    {
        if (rnd.Next(1, 3) <= 1) rb2d.gravityScale = 1;
        else rb2d.gravityScale = -1;
        yield return new WaitForSeconds(10);
        rb2d.gravityScale = 0;
    }

    IEnumerator speedTimeOrange()
    {
        invertCheck++;
        yield return new WaitForSeconds(30);
        invertCheck = 0;
    }

    IEnumerator speedTimePurple()
    {
        float scale1 = 0.75F;
        transform.localScale += new Vector3(scale1, scale1, scale1);
        yield return new WaitForSeconds(15);
        float scale = 0.75F;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    IEnumerator speedTimeMagenta()
    {
        float scale2 = 0F;
        transform.localScale = new Vector3(scale2, scale2, scale2);
        yield return new WaitForSeconds(10);
        float scale = 0.75F;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    IEnumerator speedTimeLime()
    {
        int r1 = rnd.Next(1, 7);
        int r2 = rnd.Next(50, 100);
        int r3 = rnd.Next(0, 2);
        int r4;
        if (r3 == 0) { r4 = r1; }
        else { r4 = r2; }
        Camera.main.orthographicSize = r4;
        yield return new WaitForSeconds(10);
        Camera.main.orthographicSize = 16.5F;
    }


}