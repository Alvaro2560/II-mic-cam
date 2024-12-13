using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Necesario para guardar archivos

public class TV : MonoBehaviour
{
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string savePath;
    private int captureCounter = 1;

    void Start()
    {
        tvMaterial = GetComponent<Renderer>().material;
        if (WebCamTexture.devices.Length > 0)
        {
            string cameraName = WebCamTexture.devices[0].name;
            Debug.Log($"Usando la cámara: {cameraName}");
            webcamTexture = new WebCamTexture(cameraName);
        }
        else
        {
            Debug.LogError("No se encontraron cámaras disponibles.");
        }
        savePath = Path.Combine(Application.persistentDataPath, "Capturas");
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    void Update()
    {
        if (Input.GetKey("s") && webcamTexture != null && !webcamTexture.isPlaying)
        {
            webcamTexture.Play();
            tvMaterial.mainTexture = webcamTexture;
            Debug.Log("Captura de video iniciada.");
        }
        if (Input.GetKey("p") && webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Pause();
            Debug.Log("Captura de video pausada.");
        }
        if (Input.GetKey("d") && webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
            Debug.Log("Captura de video detenida.");
        }
        if (Input.GetKeyDown("x") && webcamTexture != null && webcamTexture.isPlaying)
        {
            CaptureFrame();
        }
    }

    void CaptureFrame()
    {
        Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
        snapshot.SetPixels(webcamTexture.GetPixels());
        snapshot.Apply();
        string fileName = Path.Combine(savePath, "Capture_" + captureCounter.ToString() + ".png");
        File.WriteAllBytes(fileName, snapshot.EncodeToPNG());
        Debug.Log($"Fotograma capturado y guardado en: {fileName}");
        captureCounter++;
    }
}