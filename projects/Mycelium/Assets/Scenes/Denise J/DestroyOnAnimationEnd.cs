using UnityEngine;

namespace Scenes.Denise_J.Scripts_DJ
{
    public class DestroyOnAnimationEnd : MonoBehaviour
    {
        public void DestroyParent()
        {
            GameObject parent = gameObject.gameObject.transform.parent.gameObject;
            Destroy(parent);
        }
    }
}
