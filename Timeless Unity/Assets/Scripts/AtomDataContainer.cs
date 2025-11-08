using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class AtomDataContainer : ScriptableObject
{
    public List<AtomData> atomDatas;

    public AtomData GetRandomAtomData(AtomData atomData)
    {
        if (atomDatas == null || atomDatas.Count == 0)
        {
            Debug.LogWarning("AtomDataContainer: Список atomDatas пуст!");
            return null;
        }

        // фильтруем все, кроме переданного atomData
        var filtered = atomDatas.Where(a => a != atomData).ToList();

        if (filtered.Count == 0)
        {
            Debug.LogWarning("AtomDataContainer: Нет других атомов, кроме переданного!");
            return atomData; // или null, если хочешь явно сигнализировать
        }

        return filtered[Random.Range(0, filtered.Count)];
    }

    public AtomData GetRandomAtomData(Atom[] atoms)
    {
        if (atomDatas == null || atomDatas.Count == 0)
        {
            Debug.LogWarning("AtomDataContainer: Список atomDatas пуст!");
            return null;
        }

        // фильтруем те, которые уже у atoms
        var filtered = atomDatas.Where(a => !atoms.Any(atom => atom.data == a)).ToList();

        if (filtered.Count == 0)
        {
            Debug.LogWarning("AtomDataContainer: Все атомы уже используются!");
            return atomDatas[Random.Range(0, atomDatas.Count)];
        }

        return filtered[Random.Range(0, filtered.Count)];
    }
}
