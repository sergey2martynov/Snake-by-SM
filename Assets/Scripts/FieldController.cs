using UnityEngine;

public class FieldController : MonoBehaviour
{
    [SerializeField] private FieldValueType _fieldValue;

    public FieldValueType FieldValue
    {
        get => _fieldValue;
        set => _fieldValue = value;
    }
}
