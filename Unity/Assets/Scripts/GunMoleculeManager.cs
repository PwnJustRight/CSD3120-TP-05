using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Tilia.Interactions.SnapZone;
using Tilia.Interactions.Interactables.Interactables;

public class GunMoleculeManager : MonoBehaviour
{
    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI countUI;

    public GunController gunController;

    private string moleculeName;

    public List<Sprite> MolSprites;
    public Image molImage;

    public GameObject reloadZoneMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (attachedMolecule != null)
        // {
        //     DestroyImmediate(attachedMolecule);
        //     snapper.Unsnap();
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gobj = other.gameObject;
        InteractableFacade interactFacade = gobj.GetComponent<InteractableFacade>();
        if (interactFacade == null || interactFacade.IsGrabbed == false) return;

        bool bulletFound = gunController.EnableFire(gobj);
        if (bulletFound == true)
        {
            GetComponent<AudioSource>().Play();
            gunController.ReloadGun();
            UpdateMolecule(gobj);
            countUI.color = new Color(1, 1, 1, 1);

            interactFacade.Ungrab();
            Destroy(gobj);

            reloadZoneMesh.SetActive(false);
        }
    }


    public void SnapAZero(GameObject gobj)
    {

        // gunController.ReloadGun();
        // gunController.EnableFire(gobj);
        // UpdateMolecule(gobj);
        // countUI.color = new Color(1, 1, 1, 1);

        // SnapZoneFacade snapper = GetComponent<SnapZoneFacade>();
        // GameObject snapObj = snapper.SnappedGameObject;
        // if (snapObj != null) 
        // { 
            
        //     snapper.Unsnap();
        //     DestroyImmediate(snapObj);
        // }
    }

    public void UnSnapAZero(GameObject gobj)
    {
        // gunController.DisableFire();

        // moleculeName = "Insert Molecule";
        // molImage.color = new Color(1, 1, 1, 0);
        // nameUI.text = moleculeName;
    }

    public void UpdateMolecule(GameObject gobj)
    {
        // C2H2
        if (gobj.tag == "C2H2")
        {
            moleculeName = "C" + "<sub>" + 2 + "</sub>" + "H" + "<sub>" + 2 + "</sub>";
            molImage.sprite = MolSprites[0];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // C2H4
        else if (gobj.tag == "C2H4")
        {
            moleculeName = "C" + "<sub>" + 2 + "</sub>" + "H" + "<sub>" + 4 + "</sub>";
            molImage.sprite = MolSprites[1];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // CH4
        else if (gobj.tag == "CH4")
        {
            moleculeName = "C"+ "H" + "<sub>" + 4 + "</sub>";
            molImage.sprite = MolSprites[2];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // CO
        else if (gobj.tag == "CO")
        {
            moleculeName = "C"+ "O";
            molImage.sprite = MolSprites[3];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // CO2
        else if (gobj.tag == "CO2")
        {
            moleculeName = "C"+ "O" + "<sub>" + 2 + "</sub>";
            molImage.sprite = MolSprites[4];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // H2
        else if (gobj.tag == "H2")
        {
            moleculeName = "H" + "<sub>" + 2 + "</sub>"; 
            molImage.sprite = MolSprites[5];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // H2O
        else if (gobj.tag == "H2O")
        {
            moleculeName = "H" + "<sub>" + 2 + "</sub>" + "O"; 
            molImage.sprite = MolSprites[6];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // H2O2
        else if (gobj.tag == "H2O2")
        {
            moleculeName = "H" + "<sub>" + 2 + "</sub>" + "O" + "<sub>" + 2 + "</sub>"; 
            molImage.sprite = MolSprites[7];
            molImage.color = new Color(1, 1, 1, 1);
        }
        // O2
        else if (gobj.tag == "O2")
        {
            moleculeName = "O" + "<sub>" + 2 + "</sub>";
            molImage.sprite = MolSprites[8];
            molImage.color = new Color(1, 1, 1, 1);
        }
        
        
        // empty
        else
        {
            moleculeName = "Insert Molecule";
            molImage.color = new Color(1, 1, 1, 0);
        }

        molImage.preserveAspect = false;
        nameUI.text = moleculeName;
    }

    public void AmmoCountTextUpdate(int _count, int _max)
    {
        countUI.text = _count + " / " + _max;
        if (_count == 0)
        {
            countUI.color = new Color(1, 1, 1, 0);
            EmptyMoleculeUpdate();
        }
    }

    public void AmmoInfiniteTextUpdate()
    {
        countUI.text = "∞ / ∞";
    }

    void EmptyMoleculeUpdate()
    {
        moleculeName = "Insert Molecule";
        molImage.color = new Color(1, 1, 1, 0);
        nameUI.text = moleculeName;
        reloadZoneMesh.SetActive(true);
    }
}
