using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : GameButton,Saveable
{
    // Start is called before the first frame update

    private Animator _animator;
    private bool isOpen;
    private SpriteRenderer _spriteRenderer;
    public Sprite chestOpenImage,chestCloseImage;
    public Transform coinSpawnPoint;
    public GameObject coinGameOjbect;
    public int maxMoneyInChest;
    public int minMoneyInChest;

    private int money;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        money = Random.Range(minMoneyInChest, maxMoneyInChest);
        isOpen = false;
    }

    protected override void interactSpecific()
    {
        openChest();
    }

    protected override bool isOpened()
    {
        return isOpen;
    }

    private void openChest()
    {
        isOpen = true;
        _animator.SetBool("open",true);
        PlayerAccess.getStats().CurrentMoney += money;
    }
   


    public SaveableData saveObject()
    {
        return new InteractiveObjectData(isOpen);
    }

    public void loadObject(SaveableData data)
    {
        try
        {
            InteractiveObjectData chestData = data as InteractiveObjectData;
            if (chestData != null)
            {
                Debug.Log(chestData.Open);
                if (chestData.Open)
                {
                    isOpen = true;
                    _animator.enabled = false;
                    _spriteRenderer.sprite = chestOpenImage;
                }
                else
                {
                    isOpen = false;
                    _animator.enabled = true;
                    _spriteRenderer.sprite = chestCloseImage;
                    _animator.SetBool("open", false);

                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
