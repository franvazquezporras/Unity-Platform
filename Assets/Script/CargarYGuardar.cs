using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class CargarYGuardar : MonoBehaviour
{
    private string archive;
    static bool firstStart = true;

    private void Awake()
    {

        archive = Application.persistentDataPath + "/datosNiveles.dat";
        if (firstStart)
        {
            Load();
            firstStart = false;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(archive);
        DatosGuardables info = new DatosGuardables(GameController.unlockedLevels);
        bf.Serialize(file, info);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(archive))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(archive, FileMode.Open);
            DatosGuardables info = (DatosGuardables)bf.Deserialize(file);
            GameController.unlockedLevels = info.unlockedLevels;
        }
        else{
            GameController.unlockedLevels = 0;
        }
    }

    

}

[System.Serializable]
class DatosGuardables
{
    public int unlockedLevels;

    public DatosGuardables(int unlockedLevel)
    {
        unlockedLevels = unlockedLevel;
    }
}
