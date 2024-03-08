using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingWeaponItem : MonoBehaviour
{
    public WeaponItem item;
    private SpriteRenderer spriteRenderer;

    public void UpdateSprite()
    {
        spriteRenderer.sprite = item.sprite;
    }

    private void Start()
    {
        spriteRenderer = transform.Find("Gfx").GetComponent<SpriteRenderer>();
        if (item == null)
        {
            item = Database.GetRandomItem();
        }
        UpdateSprite();
    }
}
