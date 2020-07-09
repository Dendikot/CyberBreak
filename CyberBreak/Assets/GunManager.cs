using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField]
    private Gun m_gunController;

    //calculate god damn weapon
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] m_WeaponsMeshes;

    [SerializeField]
    private GameObject[] m_Projectiles = new GameObject[3];

    public SpawnManagerScriptableObject sObj;

    void Start()
    {
        SetWeapon();
    }


    private void SetWeapon()
    {
        Debug.Log("was triggered" + PlayerData.xVal);
        if (sObj.xVal == 0)
        {
            return;
        }
        else if (sObj.xVal > 0.65)
        {
            UpdateWeapon(0);
        }
        else if (sObj.xVal < 0.45)
        {
            UpdateWeapon(2);
        }
        else
        {
            UpdateWeapon(1);
        }
    }

    private void UpdateWeapon(int WeaponInd)
    {

        Debug.Log("change and was " + WeaponInd);
        for (int nWeaponInd = 0; nWeaponInd < m_WeaponsMeshes.Length; nWeaponInd++)
        {
            m_WeaponsMeshes[nWeaponInd].SetActive(false);
        }
        m_WeaponsMeshes[WeaponInd].SetActive(true);

        switch (WeaponInd)
        {
            case 0:
                m_gunController.BulletPrefab = m_Projectiles[0];
                m_gunController.Speed = 700;
                m_gunController.Auto = false;
                sObj.EnemyType = 1;
                break;
            case 1:
                m_gunController.BulletPrefab = m_Projectiles[1];
                m_gunController.Speed = 100;
                m_gunController.Auto = true;
                sObj.EnemyType = 2;
                break;
            case 2:
                m_gunController.BulletPrefab = m_Projectiles[2];
                m_gunController.Speed = 450; 
                m_gunController.Auto = false;
                sObj.EnemyType = 3; 
                break;
            default:
                break;
        }
    }

}
