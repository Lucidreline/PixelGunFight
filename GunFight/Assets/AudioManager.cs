﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    public static AudioManager instance;


    void Awake()
    {

        if(instance == null) 
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        //what this does is basiclly check if instance is == to anything...
        //if this is th first time the code is being ran, then it wont
        //in that case, it will make instance == this right now
        //so the next time instance is checked, instance will no longer be null
        //if its not null then that code will be destroyed
        //static variables are shared with all instances


        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        Sound foundSound = Array.Find(sounds, sound => sound.name == name);
        //      ^ what array to look in
        
        if (sounds == null) {
            Debug.LogWarning("Could not find sound: '" + name + "'");
            return;
        }
        else 
            foundSound.source.Play();
    }  
}