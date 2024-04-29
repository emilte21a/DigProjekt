using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerInteractor : MonoBehaviour
{
    [SerializeField] private float pickupRange;

    [SerializeField] private Inventory inventory;

    [SerializeField] TMP_Text text;

    [SerializeField] LayerMask isComputer;

    private Camera cam;

    public GameObject HUD;
    public GameObject ComputerScreen;

    public Transform computerPosition;
    public Transform defaultPosition;

    [SerializeField] ComputerStatus computerStatus;

    private Rigidbody rb;

    private float timer = 2;

    private void Start()
    {
        cam = Camera.main;
        computerStatus = ComputerStatus.notOnComputer;
        ComputerScreen.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, pickupRange, isComputer))
        {
            text.text = "Press F to open computer";
            if (Input.GetKeyDown(KeyCode.F) && computerStatus == ComputerStatus.notOnComputer && hit.transform.tag == "Computer")
            {
                print("HIT!");
                computerStatus = ComputerStatus.onComputer;
            }
        }
        else
            text.text = "";

        if (computerStatus == ComputerStatus.onComputer)
        {
            ComputerScreen.SetActive(true);
            ComputerScreen.GetComponent<Animator>().Play("Computer Open");
            cam.transform.position = computerPosition.position;
            HUD.SetActive(false);
            cam.GetComponent<CameraController>().enabled = false;

            if (Input.GetKeyDown(KeyCode.E))
            {
                ComputerScreen.GetComponent<Animator>().Play("Computer Close");
                StartCoroutine(OnComputerClose());
            }
        }


    }

    IEnumerator OnComputerClose()
    {
        yield return new WaitForSeconds(2);
        ComputerScreen.SetActive(false);
        computerStatus = ComputerStatus.notOnComputer;
        cam.transform.position = defaultPosition.position;
        HUD.SetActive(true);
        cam.GetComponent<CameraController>().enabled = true;
    }

    enum ComputerStatus
    {
        onComputer,
        notOnComputer
    }
}

