using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Camera;
    public AudioManager manager;
    public Pause_Menu pause_Menu;
    public SpriteRenderer spriteRendererModel;
    public SpriteRenderer spriteRendererHat;
    public SpriteRenderer spriteRendererAccessory;
    public SpriteRenderer spriteRendererTop;
    public SpriteRenderer spriteRendererBottom;
    public SpriteRenderer spriteRendererShoes;
    public TextMeshProUGUI winloseText;

    void Start()
    {
        manager = GetComponent<AudioManager>();
    }

    void Update()
    {
        if (manager.isPlaying == (false))
        {
            if (pause_Menu.Paused != (true))
            {
                Canvas.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                spriteRendererModel.sortingLayerName = "UI";
                spriteRendererHat.sortingLayerName = "UI";
                spriteRendererAccessory.sortingLayerName = "UI";
                spriteRendererTop.sortingLayerName = "UI";
                spriteRendererBottom.sortingLayerName = "UI";
                spriteRendererShoes.sortingLayerName = "UI";
                spriteRendererModel.sortingOrder = 6;
                spriteRendererHat.sortingOrder = 7;
                spriteRendererAccessory.sortingOrder = 7;
                spriteRendererTop.sortingOrder = 7;
                spriteRendererBottom.sortingOrder = 7;
                spriteRendererShoes.sortingOrder = 7;
                pause_Menu.enabled = false;
            }
        }
    }

    public void handleAllDone()
    {
        winloseText.text = "Great Job!";
    }
}
