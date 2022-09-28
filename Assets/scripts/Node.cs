using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoney;
    [Header("Optional")]
    public GameObject turret;

    public Vector3 posetionOffSet;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManger;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManger = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            buildManger.selectNode(this);
            return;
        }

        if (!buildManger.CanBuild)
        {
            return;
        }
        //build a turret
        buildManger.BuildTurretOn(this);
    }
    public Vector3 GetbuildPosition()
    {
        return transform.position + posetionOffSet;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManger.CanBuild)
        {
            return;
        }
        if (buildManger.HasMoney)
        {
        rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoney;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
