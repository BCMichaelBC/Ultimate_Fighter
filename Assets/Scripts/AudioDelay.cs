using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioDelay : MonoBehaviour
{

    [SerializeField] public float delaytime;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        yield return new WaitForSeconds(delaytime);
        audio.Play();


    }
}