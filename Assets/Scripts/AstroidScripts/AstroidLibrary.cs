using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidLibrary : MonoBehaviour
{
    
    private static Dictionary<int, Astroid> astroidDictionary = new Dictionary<int, Astroid>();

    void Awake()
    {

        Astroid[] astroidEntries = Resources.LoadAll<Astroid>("Astroids/");

        foreach (Astroid astroid in astroidEntries)
        {

            if (astroidDictionary.ContainsKey(astroid.id))
            {

                Debug.LogError("Two Astroids have the same ID!" + astroid.astroidName + " has the same ID as " + astroidDictionary[astroid.id].astroidName);

            }
            else
            {

                astroidDictionary.Add(astroid.id, astroid);

            }

        }

        Debug.Log("Astroids Loaded! Listing Astroid Types");
        foreach (KeyValuePair<int, Astroid> entry in astroidDictionary)
        {

            Debug.Log(entry.Value.astroidName);

        }

    }  

    static public Astroid GetAstroid(int id)
    {

        Astroid getAstroid;
        if (astroidDictionary.TryGetValue(id, out getAstroid))
        {

            return getAstroid;

        }
        else
        {

            Debug.LogError("Could not find item with id, " + id);
            return null;

        }

    }

}
