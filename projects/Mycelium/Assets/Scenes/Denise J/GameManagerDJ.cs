using UnityEngine;

using TMPro;
namespace Scenes.Denise_J
{
    public class GameManagerDJ : MonoBehaviour
    {
        public GameObject damageTextPrefab, enemyInstance;

        public string damageTaken;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject damageTextInstance = Instantiate(damageTextPrefab, enemyInstance.transform);
                damageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(damageTaken);
            }
        }
    }
}
