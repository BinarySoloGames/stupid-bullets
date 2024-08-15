using UnityEngine;
using UnityEngine.UIElements;

public class AmmoWatcher : MonoBehaviour
{
    [SerializeField]
    private GunController gun;

    [SerializeField]
    private Bullet normalBullet;

    [SerializeField]
    private UIDocument doc;
    private VisualElement ammoElement;
    
    // Start is called before the first frame update
    void Start()
    {
        gun.OnBulletFired += OnBulletFired;
        gun.OnBulletLoaded += OnBulletsLoaded;

        ammoElement = doc.rootVisualElement.Q<VisualElement>("AmmoUI");
    }

    private void OnBulletsLoaded()
    {
        for (int i = 0; i < gun.loadedBullets.Count; i++)
        {
            VisualElement newAmmoElement = new VisualElement();
            newAmmoElement.style.flexGrow = 0.0f;
            if (gun.loadedBullets[i] == normalBullet)
            {
                newAmmoElement.AddToClassList("ammo-bar");
            }
            else
            {
                newAmmoElement.AddToClassList("ammo-bar-special");
            }
            
            ammoElement.Add(newAmmoElement);
        }
    }

    private void OnBulletFired()
    {
        if (ammoElement.childCount > 0)
        {
            ammoElement.RemoveAt(0);
        }
    }
}
