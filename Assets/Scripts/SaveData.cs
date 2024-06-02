using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    static string playerxp_key = "playerXP";
    static string inventory_key = "inventory";

    private int playerXP = 100;

    private List<string> inventario = new List<string>();

    void Start()
    {
        if (PlayerPrefs.HasKey(playerxp_key))
            playerXP = PlayerPrefs.GetInt(playerxp_key);
        else
            playerXP = 0;

        if (PlayerPrefs.HasKey(inventory_key))
            inventario = ParsearInventario(PlayerPrefs.GetString(inventory_key));
        else
            inventario = new List<string>();
    }

    private List<string> ParsearInventario(string inventoryParsed)
    {
        return inventoryParsed.Split(",").ToList();
    }

    void UpdateXP(int value)
    {
        playerXP += value;

        PlayerPrefs.SetInt(playerxp_key, playerXP);
        PlayerPrefs.Save();
    }

    void SaveInventory()
    {
        string inventoryParsed = "";
        foreach (var item in inventario)
        {
            inventoryParsed += item + ",";
        }

        PlayerPrefs.SetString(inventory_key, inventoryParsed);
        PlayerPrefs.Save();
    }

    private void ResetearAvance()
    {
        PlayerPrefs.DeleteAll();
    }
}
