using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPasteScrpt : MonoBehaviour
{
    public float HealAmount; // Ammount item heals for 
    public HealthBarScript HealthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth()
    {
        CheckIfItemInInventory();

        HealthBarScript.UpdateHealthBar(HealAmount); // Add health to healthbar 

        RemoveItemFromInVentory();
    }

    public bool CheckIfItemInInventory()
    {
        bool InInventory;

        InInventory = true;

        return InInventory;
    }

    public void RemoveItemFromInVentory()
    {

    }
}
