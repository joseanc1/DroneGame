using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{

    public void ButtonDecolarOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
