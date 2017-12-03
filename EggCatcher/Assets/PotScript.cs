using EggCatcher.Globals;
using UnityEngine;
public class PotScript : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Egg")
        {
            print("Collision");
            collider.transform.SetParent(transform);
            foreach (CircleCollider2D Collider in transform.GetComponentsInChildren<CircleCollider2D>())
                Collider.enabled = true;

           Destroy(GetComponent<BoxCollider2D>());
           collider.GetComponent<Rigidbody2D>().freezeRotation = true;
           LevelController.levelController.OnHit();

            GameObject potPrefab = Instantiate(LevelController.levelController.pot);
            potPrefab.transform.SetParent(transform.parent);
            potPrefab.transform.localPosition = transform.localPosition + new Vector3(0,5, 0);

            Globals.Input = true;
        }
    }
}
