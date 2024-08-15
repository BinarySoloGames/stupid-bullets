using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunController : MonoBehaviour
{
    [SerializeField] 
    private Transform spawnPoint;
    [SerializeField] 
    private int numSpecialBullets = 5;
    [SerializeField] 
    private List<GameObject> bullets;
    [SerializeField] 
    private AudioSource shootSource;
    [SerializeField]
    private AudioClip emptyClick;
    [SerializeField]
    private int clipSize = 15;
    [SerializeField]
    private float reloadTime = 1.0f;
    
    public List<Bullet> loadedBullets = new List<Bullet>();

    public delegate void BulletFired();
    public event BulletFired OnBulletFired;
    
    public delegate void BulletsLoaded();
    public event BulletsLoaded OnBulletLoaded;


    private void Start()
    {
        LoadBullets();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (loadedBullets.Count > 0)
            {
                var bulletInstance = GameObject.Instantiate(loadedBullets[0]);
                bulletInstance.transform.position = spawnPoint.position;
                bulletInstance.transform.forward = spawnPoint.forward;
                Bullet bullet = bulletInstance.GetComponent<Bullet>();
                bullet.Fire();
                shootSource.clip = bullet.ShootClip;
                shootSource.Play();
                OnBulletFired?.Invoke();

                loadedBullets.RemoveAt(0);
                if (loadedBullets.Count == 0)
                {
                    StartCoroutine(DelayLoadBullets());
                }
            }
            else
            {
                shootSource.clip = emptyClick;
                shootSource.Play();
            }
        }
    }

    private IEnumerator DelayLoadBullets()
    {
        yield return new WaitForSeconds(reloadTime);

        LoadBullets();
    }

    private void LoadBullets()
    {
        for (int i = 0; i < clipSize; i++)
        {
            loadedBullets.Add(bullets.PickRandom().GetComponent<Bullet>());
        }
        
        OnBulletLoaded?.Invoke();
    }

    public void ChangeBullet(Bullet specialBullet)
    {
        for (int i = 0; i < numSpecialBullets; i++)
        {
            bullets[bullets.Count - i - 1] = specialBullet.gameObject;
        }
    }
}
