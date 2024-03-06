using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCameraManager : MonoBehaviour
{
    [SerializeField] private GameObject actualCamera;
    [SerializeField] private GameObject imposterCamera;
    [SerializeField] private GameObject finalCameraObj;
    private Camera finalCamera;

    public bool playerTriggered = false;
    private float fov = 75;
    public float zoomInTime = 9.0f;

    public bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        finalCamera = GetComponentInChildren<Camera>();
        finalCamera.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            Invoke(nameof(LoadFinal), 5.0f);
        }
        if (playerTriggered)
        {
            StartCoroutine(CloseUpFOV());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTriggered = true;
            finalCamera.gameObject.SetActive(true);
            actualCamera.SetActive(false);
            imposterCamera.SetActive(false);
        }
    }

    private void LoadFinal()
    {
        SceneManager.LoadScene("FinalScene");
    }

    private IEnumerator CloseUpFOV()
    {
        for(int fovMinus = 75; finalCamera.fieldOfView >= 3.0f; fovMinus--)
        {
            finalCamera.fieldOfView = fov;
            fov -= 0.01f;
            yield return new WaitForSecondsRealtime(zoomInTime);
        }
        gameEnded = true;
    }
}
