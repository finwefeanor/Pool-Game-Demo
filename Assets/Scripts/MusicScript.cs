using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour 
{
    private void Awake() {
        int numMusicPlayers = FindObjectsOfType<MusicScript>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}
