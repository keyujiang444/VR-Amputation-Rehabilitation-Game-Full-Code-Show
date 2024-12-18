using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiamondGenerator : MonoBehaviour
{
    private Transform[] m_Points;
    public GameObject[] m_Prefabs;

    public int DiamondCount = 5;
    public int Radius = 100;
    
    private void Awake()
    {
        var childCount = transform.childCount;
        m_Points = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            m_Points[i] = transform.GetChild(i);
        }
        
        GenDiamond(DiamondCount);
    }

    void GenDiamond(int count)
    {
        var list = new List<Transform>(m_Points);
        for (int i = 0; i < count; i++)
        {
            var prefab = m_Prefabs[Random.Range(0, m_Prefabs.Length)];
            var point = list[Random.Range(0, list.Count)];
            var go = GameObject.Instantiate(prefab);

            var circle = Random.insideUnitCircle.normalized * Radius;
            go.transform.position = point.position + point.right * circle.x + point.up * circle.y;
            go.transform.right = go.transform.position-point.position;
        }
    }
}