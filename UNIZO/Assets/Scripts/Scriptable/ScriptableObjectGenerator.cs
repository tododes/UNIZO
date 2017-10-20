using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScriptableObjectGenerator : MonoBehaviour {
#if UNITY_EDITOR
    [MenuItem("Assets/Create/Scene Tree")]
    public static void CreateSceneTree(){
        SceneGraph instance = ScriptableObject.CreateInstance<SceneGraph>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable/SceneTree.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Create/Scene Node")]
    public static void CreateSceneNode(){
        SceneNode instance = ScriptableObject.CreateInstance<SceneNode>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable/Nodes/Tutorial 1 Scene.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Create/Item Sprite Database")]
    public static void CreateItemSpriteDatabase(){
        ItemSpriteDatabase instance = ScriptableObject.CreateInstance<ItemSpriteDatabase>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable/Item Sprite Database.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Create/Player Sprite Database")]
    public static void CreatePlayerSpriteDatabase(){
        PlayerNameToImageConverter instance = ScriptableObject.CreateInstance<PlayerNameToImageConverter>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable/Player Sprite Database.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Create/Companion Skill Sprite Database")]
    public static void CreateCompanionSkillSpriteDatabase()
    {
        NameToSkillSpriteDatabase instance = ScriptableObject.CreateInstance<NameToSkillSpriteDatabase>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable/Companion Skill Sprite Database.asset");
        AssetDatabase.SaveAssets();
    }
#endif
    /*Main Menu         Settings        Shop        Skill Tree Scene        Game Scene      Choose Dungeon*/
}
