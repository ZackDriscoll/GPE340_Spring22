using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public Image weaponImage;

    public void SetWeaponImage(Sprite weaponSprite)
    {
        weaponImage.sprite = weaponSprite;
        weaponImage.SetNativeSize();
    }
}
