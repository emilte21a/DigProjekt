using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraShake : MonoBehaviour
{



    void Update()
    {
        float x, y, z;
        x = Random.Range(-6, 6);
        y = Random.Range(-6, 6);
        z = Random.Range(-6, 6);
        transform.eulerAngles += new Vector3(x, y, z);


    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Sample Scene");
    }
}
