
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Tilia.Interactions.Interactables.Interactables;

public class GunController : MonoBehaviour
{
    [Header("Gun Properties")]
    public GameObject gunBarrel;
    public GunMoleculeManager gunMolManager;
    public int ammoCount = 0;
    public int ammoMax = 2;
    public bool ammoInfinite = false;
    public TextMeshProUGUI infUI;

    [Header("Firing Properties")]
    public GameObject projectileType;
    public bool canFire = false;
    public float fireForce = 25.0f;

    [Header("Lasersight Properties")]
    public LineRenderer lineRenderer;
    public float laserMaxRange = 100.0f;
    public float laserThiccness = 0.01f;
    public bool enableLaser = true;

    [Header("Bullet Types")]
    public List<GameObject> bulletTypes = new List<GameObject>();

    public void SetInfAmmo()
    {
        ammoInfinite = !ammoInfinite;
        if (ammoInfinite)
        {
            infUI.color = Color.green;
        }
        else
        {
            infUI.color = Color.red;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.widthMultiplier = laserThiccness;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableLaser == false) return;
        Vector3 endPosition = LaserSight();
        lineRenderer.SetPosition(0, gunBarrel.transform.position);
        lineRenderer.SetPosition(1, endPosition);

        if (ammoInfinite)
            gunMolManager.AmmoInfiniteTextUpdate();
        else
            gunMolManager.AmmoCountTextUpdate(ammoCount, ammoMax);
    }

    // check through ammo types to determine if ammo loaded is valid
    public bool EnableFire(GameObject gobj)
    {
        foreach(GameObject bulletType in bulletTypes)
        {
            if (gobj.tag == bulletType.tag)
            {
                projectileType = bulletType;
                canFire = true;
                return true;
            }
        }
        return false;
    }

    // disable fire boolean
    public void DisableFire()
    {
        canFire = false;
    }

    // gun fire function
    public void Fire()
    {
        print("fire");
        InteractableFacade interactFacade = gameObject.GetComponent<InteractableFacade>();
        // not grabbed so of course cannot fire
        if (interactFacade == null || interactFacade.IsGrabbed == false) return;
        // no proper ammo loaded so cannot fire
        if (canFire == false || ammoCount == 0 ) return;

        // all good and ready to fire
        gunBarrel.GetComponent<AudioSource>().Play();
        GameObject projectile =  GameObject.Instantiate(projectileType, gunBarrel.transform.position, Quaternion.identity, null);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(gunBarrel.transform.forward * fireForce, ForceMode.Impulse);
        gunBarrel.GetComponent<ParticleSystem>().Play();
        
        // infinite ammo cheat
        if (ammoInfinite == false)
        {
            --ammoCount;
            if (ammoCount == 0) DisableFire();
            gunMolManager.AmmoCountTextUpdate(ammoCount, ammoMax);
        }
    }

    // lasersight that points a line from the barrel
    Vector3 LaserSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.transform.position, gunBarrel.transform.forward, out hit, laserMaxRange))
        {
            return hit.point;
        }
        return (gunBarrel.transform.position +  gunBarrel.transform.forward * laserMaxRange);
    }

    // reload gun ammo
    public void ReloadGun()
    {
        ammoCount = ammoMax;
        if (ammoInfinite == false)
            gunMolManager.AmmoCountTextUpdate(ammoCount, ammoMax);
        else
            gunMolManager.AmmoInfiniteTextUpdate();
    }

    public void ToggleInfiniteAmmo()
    {
        ammoInfinite = !ammoInfinite;
    }
}
