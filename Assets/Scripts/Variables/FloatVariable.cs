using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [NonSerialized]
    public float RuntimeValue;
    
    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        ResetVariable();
    }

    public void ResetVariable()
    {
        RuntimeValue = initialValue;
    }
}
