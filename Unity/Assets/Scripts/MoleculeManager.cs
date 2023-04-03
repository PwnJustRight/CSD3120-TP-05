using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Molecule
{
    public int NumOfCarbon = 0;
    public int NumOfHydrogen = 0;
    public int NumOfOxygen = 0;
}


public class MoleculeManager : MonoBehaviour
{
    private const int valenceOxygen = 6;
    private const int valenceCarbon = 4;
    private const int valenceHydrogen = 1;

    public static int numAtoms = 7;
    public bool[] atomList = new bool[numAtoms];
    public GameObject[] atoms = new GameObject[numAtoms];
    public Molecule m;
    public TextMeshProUGUI textUI;
    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI stableUI;
    public TextMeshProUGUI toggleSpawnerGUI;
    public List<Sprite> MolSprites;
    public Image MolImage;

    private bool spawnflag = true;
    public void Awake()
    {
        stableUI.text = "NIL";
        stableUI.color = Color.white;
        MolImage.color = new Color(1, 1, 1, 0); //zero alpha
    }

    public void SnapAZero(GameObject gobj)
    {
        atomList[0] = true;
        atoms[0] = gobj;
        UpdateMolecule();
    }

    public void SnapAOne(GameObject gobj)
    {
        atomList[1] = true;
        atoms[1] = gobj;
        UpdateMolecule();
    }

    public void SnapATwo(GameObject gobj)
    {
        atomList[2] = true;
        atoms[2] = gobj;
        UpdateMolecule();
    }

    public void SnapAThree(GameObject gobj)
    {
        atomList[3] = true;
        atoms[3] = gobj;
        UpdateMolecule();
    }

    public void SnapAFour(GameObject gobj)
    {
        atomList[4] = true;
        atoms[4] = gobj;
        UpdateMolecule();
    }

    public void SnapAFive(GameObject gobj)
    {
        atomList[5] = true;
        atoms[5] = gobj;
        UpdateMolecule();
    }

    public void SnapASix(GameObject gobj)
    {
        atomList[6] = true;
        atoms[6] = gobj;
        UpdateMolecule();
    }

    public void UnSnapAZero(GameObject gobj)
    {
        atomList[0] = false;
        UpdateMolecule();
    }

    public void UnSnapAOne(GameObject gobj)
    {
        atomList[1] = false;
        UpdateMolecule();
    }

    public void UnSnapATwo(GameObject gobj)
    {
        atomList[2] = false;
        UpdateMolecule();
    }

    public void UnSnapAThree(GameObject gobj)
    {
        atomList[3] = false;
        UpdateMolecule();
    }

    public void UnSnapAFour(GameObject gobj)
    {
        atomList[4] = false;
        UpdateMolecule();
    }

    public void UnSnapAFive(GameObject gobj)
    {
        atomList[5] = false;
        UpdateMolecule();
    }

    public void UnSnapASix(GameObject gobj)
    {
        atomList[6] = false;
        UpdateMolecule();
    }

    public void UpdateMolecule()
    {
        m = new Molecule();
        for (int i = 0; i < atomList.Length; ++i)
        {
            if (atomList[i])
            {
                if (atoms[i].tag == "Carbon")
                {
                    m.NumOfCarbon++;
                }
                else if (atoms[i].tag == "Hydrogen")
                {
                    m.NumOfHydrogen++;
                }
                else if (atoms[i].tag == "Oxygen")
                {
                    m.NumOfOxygen++;
                }
            }
        }
        UpdateText();
    }

    public void UpdateText()
    {
        string text = "";
        int valency = 0;
        if (m.NumOfCarbon > 0)
        {
            text += "C";
            if (m.NumOfCarbon > 1)
                text += "<sub>" + m.NumOfCarbon + "</sub>";

            valency += m.NumOfCarbon * valenceCarbon;
        }
        if (m.NumOfHydrogen > 0)
        {
            text += "H";
            if (m.NumOfHydrogen > 1)
                text += "<sub>" + m.NumOfHydrogen + "</sub>";

            valency += m.NumOfHydrogen * valenceHydrogen;
        }
        if (m.NumOfOxygen > 0)
        {
            text += "O";
            if (m.NumOfOxygen > 1)
                text += "<sub>" + m.NumOfOxygen + "</sub>";

            valency += m.NumOfOxygen * valenceOxygen;
        }

        // Set the text of the TextMeshProUGUI component
        this.textUI.text = text;

        //Name UI
        SetNameText();

        //Stable UI
        if (nameUI.text == "")
        {
            stableUI.text = "Unstable";
            stableUI.color = Color.red;
        }
        else if (valency == 0)
        {
            stableUI.text = "NIL";
            stableUI.color = Color.white;
        }
        else if ((valency % 2) == 0)
        {
            stableUI.text = "Stable";
            stableUI.color = Color.green;
        }
        else
        {
            stableUI.text = "Unstable";
            stableUI.color = Color.red;
        }
    }

    public void SetNameText()
    {
        string nameText = "";

        int numCarbon = m.NumOfCarbon;
        int numOxygen = m.NumOfOxygen;
        int numHydrogen = m.NumOfHydrogen;
        int valenceElectrons = numCarbon * 4 + numOxygen * 6 + numHydrogen * 1;


        if (valenceElectrons == 2)
        {
            nameText = "Hydrogen Gas";
            MolImage.sprite = MolSprites[0];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else if (valenceElectrons == 8 && numCarbon == 1 && numHydrogen == 4)
        {
            nameText = "Methane";
            MolImage.sprite = MolSprites[6];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else if (valenceElectrons == 8 && numOxygen == 1 && numHydrogen == 2)
        {
            nameText = "Water";
            MolImage.sprite = MolSprites[2];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        /*        else if (valenceElectrons == 8 && numCarbon == 2)
                    nameText = "Diatomic carbon";*/
        else if (valenceElectrons == 10 && numCarbon == 1 && numOxygen == 1)
        {
            nameText = "Carbon Monoxide";
            MolImage.sprite = MolSprites[4];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else if (valenceElectrons == 10 && numCarbon == 2 && numHydrogen == 2)
        {
            nameText = "Acetylene";
            MolImage.sprite = MolSprites[5];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else if (valenceElectrons == 12 && numCarbon == 2 && numHydrogen == 4)
        {
            nameText = "Polyethylene";
            MolImage.sprite = MolSprites[8];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else if (valenceElectrons == 12 && numOxygen == 2)
        {
            nameText = "Oxygen Gas";
            MolImage.sprite = MolSprites[1];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        /*        else if (valenceElectrons == 12 && numCarbon == 3)
                    nameText = "Cyclopropatriene";*/
        else if (valenceElectrons == 14 && numOxygen == 2 && numHydrogen == 2)
        {
            nameText = "Hydrogen Peroxide";
            MolImage.sprite = MolSprites[7];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else if (valenceElectrons == 14 && numCarbon == 2 && numHydrogen == 6)
            nameText = "Ethane";
        else if (valenceElectrons == 16 && numCarbon == 1 && numOxygen == 2)
        {
            nameText = "Carbon Dioxide";
            MolImage.sprite = MolSprites[3];
            MolImage.color = new Color(1, 1, 1, 1); //alpha
        }
        else
        {
            MolImage.color = new Color(1, 1, 1, 0); //alpha
        }

        nameUI.text = nameText;
    }

    public void KillSpawners()
    {
        Spawner.KillAllZombies();
    }

    public void ToggleSpawners()
    {
        spawnflag = !spawnflag;
        if(spawnflag)
        {
            toggleSpawnerGUI.color = Color.green;
        }
        else
        {
            toggleSpawnerGUI.color = Color.red;
        }
        Spawner.ToggleAllSpawners();
    }
}
