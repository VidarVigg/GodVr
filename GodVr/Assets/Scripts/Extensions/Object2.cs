using UnityEngine;
using UnityEngineInternal;

public class Object2 : Object
{

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public new static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent)
    {
        Object clone = Object.Instantiate(original, position, rotation, parent);
        clone.name = original.name;
        return clone;
    }

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public new static Object Instantiate(Object original)
    {
        Object clone = Object.Instantiate(original);
        clone.name = original.name;
        return clone;
    }

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public new static Object Instantiate(Object original, Vector3 position, Quaternion rotation)
    {
        Object clone = Object.Instantiate(original, position, rotation);
        clone.name = original.name;
        return clone;
    }

    public new static T Instantiate<T>(T original, Transform parent, bool worldPositionStays) where T : Object
    {
        T clone = Object.Instantiate(original, parent, worldPositionStays);
        clone.name = original.name;
        return clone;
    }

    public new static T Instantiate<T>(T original, Transform parent) where T : Object
    {
        T clone = Object.Instantiate(original, parent);
        clone.name = original.name;
        return clone;
    }

    public new static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object
    {
        T clone = Object.Instantiate(original, position, rotation, parent);
        clone.name = original.name;
        return clone;
    }

    public new static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object
    {
        T clone = Object.Instantiate(original, position, rotation);
        clone.name = original.name;
        return clone;
    }

    public new static T Instantiate<T>(T original) where T : Object
    {
        T clone = Object.Instantiate(original);
        clone.name = original.name;
        return clone;
    }

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public new static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
    {
        Object clone = Object.Instantiate(original, parent, instantiateInWorldSpace);
        clone.name = original.name;
        return clone;
    }

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public new static Object Instantiate(Object original, Transform parent)
    {
        Object clone = Object.Instantiate(original, parent);
        clone.name = original.name;
        return clone;
    }

}