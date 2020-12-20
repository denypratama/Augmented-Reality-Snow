using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    public float maxDistanceRay = 10f;
    public static RaycastController instance;
    public Text snowName;
    public Transform arrowSound;
    public float arrRate = 1.6f;
    private bool nextShot = true;
    private string objName = "";

    AudioSource audio;
    public AudioClip[] clips;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void playSound(int sound)
    {
        audio.clip = clips[sound];
        audio.Play();
    }

    void Start()
    {
        // StartCoroutine(spawnNewBird());
        // StartCoroutine(playSound(2));
        // playSound(2);
    }

    void Update()
    {

    }

     public void arrowShot()
    {
        if (nextShot)
        {
            StartCoroutine(takeShot());
            // takeShot();
            // playSound();
            nextShot = false;
        }
    }

    private IEnumerator takeShot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        GameObject arrSound = Instantiate(Resources.Load("arrowsound", typeof(GameObject))) as GameObject;
        arrSound.transform.position = arrowSound.position;

        yield return new WaitForSeconds(arrRate);
        nextShot = true;
        // playSound(2);
        // audio.Play();
        audio = GetComponent<AudioSource>();
        audio.Play(0);
    }

    // private IEnumerator spawnNewBird()
    // {
    //     yield return new WaitForSeconds(3f);
    //     GameObject newBird = Instantiate(Resources.Load("Bird_Asset", typeof(GameObject))) as GameObject;

    //     newBird.transform.parent = GameObject.Find("ImageTarget").transform;
        
    //     newBird.transform.localScale = new Vector3(10f, 10f, 10f);

    //     Vector3 temp;
    //     temp.x = Random.Range(-2.5f, 2.5f);
    //     temp.y = Random.Range(0.4f, 1f);
    //     temp.z = Random.Range(-2.5f, 2.5f);
    //     newBird.transform.position = new Vector3(temp.x, temp.y-6.5f, temp.z);
    // }
    
}
