using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(mouseRay, out RaycastHit hit, layerMask);

            Vector3 can = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            if (hit.transform.gameObject.tag != "Player")
            {
                transform.position = can;
            }

        }
    }
}
