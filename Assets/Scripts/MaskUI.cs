using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class MaskUI : Image
{
    public override Material materialForRendering 
    {
        get {
            Material tempMat = new Material(base.material);
            tempMat.SetFloat("_StencilComp", (float)CompareFunction.NotEqual);
            return tempMat; 
        }
    }
}
