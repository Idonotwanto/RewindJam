using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject OptionMenu;
    // Start is called before the first frame update
    void Start()
    {
        OptionMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { OptionMenu.SetActive(!OptionMenu.activeSelf); }
    }
}
