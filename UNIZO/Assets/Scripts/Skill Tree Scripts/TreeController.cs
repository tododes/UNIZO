using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MenuController {

    public static TreeController singleton { get; private set; }

    [SerializeField] private Node root;
    [SerializeField] private Node current;
    [SerializeField] private bool initTree;
    [SerializeField] private Dictionary<int, CompanionSkillPanel> companionTypeToSkillPanel;
    [SerializeField] private CompanionSkillPanel currentSkillPanel;

    private List<Node> nodes;

    void Awake(){
        singleton = this;
    }
    // Use this for initialization
    protected override void Start(){
        base.Start();
        root = transform.GetChild(0).GetComponent<Node>();
        nodes = new List<Node>(GetComponentsInChildren<Node>());

        companionTypeToSkillPanel = new Dictionary<int, CompanionSkillPanel>();
        int[] types = new int[] { (int)CompanionType.SPREADINGSHOOT, (int)CompanionType.PIERCINGSHOOT };
        CompanionSkillPanel[] existingSkillPanels = FindObjectsOfType<CompanionSkillPanel>();
        MonoSorter<CompanionSkillPanel>.Sort(FindObjectsOfType<CompanionSkillPanel>());

        for (int i = 0; i < existingSkillPanels.Length; i++){
            companionTypeToSkillPanel.Add(types[i], existingSkillPanels[i]);
            existingSkillPanels[i].Activate(false);
        }

        foreach (KeyValuePair<int, CompanionSkillPanel> each in companionTypeToSkillPanel)
        {
            Debug.Log(each.Key + " " + each.Value);
        }
       
        currentSkillPanel = companionTypeToSkillPanel[(int)currentSaveData.getCompanionData().myType];
        currentSkillPanel.Activate(true);
        string companionTypeDisplayName = currentSaveData.getCompanionData().myType == CompanionType.PIERCINGSHOOT ? "Piercing Shoot" : "Spreading Shoot";
        updateSkillPanelDisplay(companionTypeDisplayName, currentSaveData.getCompanionData().mySkills, currentSaveData.getCompanionData().mySkillLevels);
    }

    public void updateSkillPanelDisplay(string displayName, List<string> companionSkills, List<int> companionSkillLevels){
        currentSkillPanel.updateDisplay(displayName, companionSkills, companionSkillLevels);
    }

    public void updateSkillPanelDisplay(){
        CompanionData companionData = currentSaveData.getCompanionData();
        currentSkillPanel.updateDisplay(companionData.ToString(), companionData.mySkills, companionData.mySkillLevels);
    }

    // Update is called once per frame
    void LateUpdate () {
        if (!initTree){
            if (!GameStorage.Exists(Application.persistentDataPath + SaveKey.SKILLTREEDATA_KEY)){
                root.recursivelyChangeStatus(2);
                current = root;
            }
            else{
                List<int> nodeStatusData = GameStorage.Load<List<int>>(Application.persistentDataPath + SaveKey.SKILLTREEDATA_KEY);
                for(int i = 0; i < nodeStatusData.Count; i++){
                    nodes[i].status = nodeStatusData[i];
                    if (nodes[i].status == 2)
                        current = nodes[i];
                    Debug.Log(nodeStatusData[i]);
                }
            }
            initTree = true;
        }
	}

    public void setCurrentNode(Node node){
        current = node;
    }

    public void saveTreeData(){
        List<int> treeData = new List<int>();
        for (int i = 0; i < nodes.Count; i++) {
            treeData.Add(nodes[i].status);
        }
        GameStorage.Save<List<int>>(treeData, Application.persistentDataPath + SaveKey.SKILLTREEDATA_KEY);
        if(current is SkillNode){
            SkillNode currentSkillNode = (SkillNode) current;
            string companionSkillActionName = currentSkillNode.getActionName();
            GameStorage.Save<string>(companionSkillActionName, Application.persistentDataPath + SaveKey.COMPANIONSKILLNAME_KEY);
        }
        treeData.Clear();
        treeData = null;
    }

    public override void SaveGameData()
    {
        base.SaveGameData();
        Debug.Log("Tree controller data");
    }
}
