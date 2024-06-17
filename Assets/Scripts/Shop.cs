using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public MeshRenderer[] planeModel;
    public Material[] materials;
    private void Start()
    {
        CheckMat();
    }
    private void CheckMat()
    {
        if (PlayerPrefs.HasKey("Mat"))
        {

        
        Material randomMaterial = materials[PlayerPrefs.GetInt("Mat")];
            foreach (MeshRenderer mesh in planeModel)
            {
                mesh.material = randomMaterial;

            }
        }
    }
    public void GetRandomColor()
    {
        if (PlayerPrefs.GetInt("Money")>10)
        {
            int rand = Random.Range(0, materials.Length);
            Material randomMaterial = materials[rand];
            foreach (MeshRenderer mesh in planeModel)
            {
                mesh.material = randomMaterial;
            }
            PlayerPrefs.SetInt("Mat", rand);
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetRandomColor();
        }
    }
}
