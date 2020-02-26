using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] string fileName;
    [SerializeField] Slider Speed;
    [SerializeField] PositionsController positions;
    [SerializeField] MovementController movement;
    void Awake()
    {
        print(Application.persistentDataPath + fileName);
        if (File.Exists(Application.persistentDataPath + fileName))
            Load();
        else // initial values
        {
            movement.targetPos = movement.transform.position; 
            positions.points = new Queue<Vector3>();
        }
        
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    void Load()
    {
        SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.persistentDataPath + fileName));
        positions.points = new Queue<Vector3>();
        for (int i = 0;i < data.positions.Length;i++)
        {
            positions.points.Enqueue(data.positions[i]);
        }
        Speed.value = data.speed;
        movement.transform.position = data.currentPosition;
        movement.targetPos = data.currentTarget;

    }

    public void Save()
    {
        var data = new SaveData() { currentPosition = movement.transform.position,currentTarget = movement.targetPos, positions = positions.points.ToArray(), speed = Speed.value};
        File.WriteAllText(Application.persistentDataPath + fileName, JsonUtility.ToJson(data));
    }
}
