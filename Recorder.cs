using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private string microphone;
    private bool isRecording = false;

    private AudioClip recordedClip;

    public List<AudioSource> speakers;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            microphone = Microphone.devices[0]; // Usar el primer micrófono disponible
            Debug.Log($"Micrófono seleccionado: {microphone}");
        }
        else
        {
            Debug.LogError("No hay micrófonos disponibles en este dispositivo.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isRecording)
            {
                StartRecording();
            }
            else
            {
                StopRecordingAndPlay();
            }
        }

    }

    private void StartRecording()
    {
        if (microphone != null)
        {
            Debug.Log("Iniciando grabación...");
            isRecording = true;
            recordedClip = Microphone.Start(microphone, false, 20, 44100);
        }
    }

    private void StopRecordingAndPlay()
    {
        if (microphone != null && isRecording)
        {
            Debug.Log("Deteniendo grabación...");
            isRecording = false;
            Microphone.End(microphone);
            foreach (AudioSource speaker in speakers)
            {
                speaker.clip = recordedClip;
                speaker.Play();
            }
            Debug.Log("Reproduciendo audio grabado desde los altavoces.");
        }
    }
}