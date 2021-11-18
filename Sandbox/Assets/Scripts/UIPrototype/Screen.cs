using UnityEngine;

//Empty class to distinguish Screen panels from other Rectransforms.
public class Screen : MonoBehaviour
{
    public virtual void HandleUpButtonPress() { }
    public virtual void HandleDownButtonPress() { }
    public virtual void HandleSelectButtonPress() { }

    protected virtual void SetInitialState() { }
}
