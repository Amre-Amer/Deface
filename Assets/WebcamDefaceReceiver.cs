using UnityEngine;
using UnityEngine.UI;

public class WebcamDeFaceReceiver : MonoBehaviour
{
    public RawImage displayImage; // Or assign to a material/Quad
    private WebCamTexture webcamTexture;

    void Start()
    {
        // List devices to find your virtual camera name if needed
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log("Webcam devices: " + devices.Length);
        if (devices.Length > 0)
        {
            for(int n = 0; n < devices.Length; n++)
            {
                Debug.Log(n + ": " + devices[n].name + "\n");
            }
            Debug.Log("source: " + devices[1].name);
            webcamTexture = new WebCamTexture(devices[1].name, 1920, 1080, 30);
            // webcamTexture = new WebCamTexture("Obs Virtual Camera");
            displayImage.texture = webcamTexture;
            webcamTexture.Play();
        }
    }

    void OnDisable()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }
}
