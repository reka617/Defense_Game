using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType {get; protected set;} = Define.Scene.Unknown;

}
