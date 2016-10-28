/*using UnityEngine;
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
            switch (other.gameObject.tag)
            {
                case "PickUpYellow":
                    break;
                case "PickUpGreen":
                    speed *= 3;
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
                    if (rnd.Next(1, 3) <= 1) rb2d.gravityScale = 1;
                    else rb2d.gravityScale = -1;
                    StartCoroutine(speedTimeBlue());
                    break;
                case "PickUpOrange":
                    invertCheck++;
                    StartCoroutine(speedTimeOrange());
                    break;
                case "PickUpPurple":
                    float scale1 = 0.75F;
                    transform.localScale += new Vector3(scale1, scale1, scale1);
                    StartCoroutine(speedTimePurple());
                    break;
                case "PickUpMagenta":
                    float scale2 = 0F;
                    transform.localScale = new Vector3(scale2, scale2, scale2);
                    StartCoroutine(speedTimeMagenta());
                    break;
                default:
                    break;
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            audioSbackground.Stop();
            audioSwin.PlayOneShot(winSound, 1F);
            winText.text = "You Win!";
        }
    }

    IEnumerator speedTimeGreen()
    {
        yield return new WaitForSeconds(10);
        speed /= 3;
    }

    IEnumerator speedTimeBlue()
    {
        yield return new WaitForSeconds(10);
        rb2d.gravityScale = 0;
    }

    IEnumerator speedTimeOrange()
    {
        yield return new WaitForSeconds(30);
        invertCheck = 0;
    }

    IEnumerator speedTimePurple()
    {
        yield return new WaitForSeconds(15);
        float scale = -0.75F;
        transform.localScale += new Vector3(scale, scale, scale);
    }

    IEnumerator speedTimeMagenta()
    {
        yield return new WaitForSeconds(10);
        float scale = 0.75F;
        transform.localScale = new Vector3(scale, scale, scale);
    }


}*/