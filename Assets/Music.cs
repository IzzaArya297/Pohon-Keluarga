using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
    //90 detik, 0-30% start, 30%-80% middle, sisanya outro
{

    public AudioSource BGM;

    public AudioClip[] BGM_Gameplay;

    public float game_timer = 90;

    public float timer = 0;

    public float persen_start = 30;
    public float persen_mid = 80;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayBGM(game_timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayBGM(float game_timer)
    {
        float length = BGM_Gameplay[0].length;
        BGM.clip = BGM_Gameplay[0];
        BGM.Play();
        float time_start = ((int)((game_timer * persen_start / 100) / length) + 1) * length;

        while (timer < time_start)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

        length = BGM_Gameplay[1].length;
        BGM.clip = BGM_Gameplay[1];
        BGM.Play();

        float time_end = (((int)(((game_timer * persen_mid / 100) - time_start) / length) + 1) * length) + time_start;
        while (timer < time_end)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

        length = BGM_Gameplay[2].length;
        BGM.clip = BGM_Gameplay[2];
        BGM.Play();

        while (timer < game_timer)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

        BGM.clip = BGM_Gameplay[3];
        BGM.loop = false;
        BGM.Play();
        BGM.loop = false;

        BGM.Stop();
    }
}
