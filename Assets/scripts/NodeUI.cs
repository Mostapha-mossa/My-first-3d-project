using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public void setTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetbuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
