using UnityEngine;

public class BaconBehaviour : MonoBehaviour
{
    public GameObject bitBaconPrefab;
    private int points;
    private string baconName = "";

    public void EatBacon()
    {
        Debug.Log("Bacon Eaten");
        Destroy(gameObject);
    }

    // public void CreateBitBacon()
    // {
    //     Debug.Log("Bit Bacon Created");
    //     GameObject inst = (GameObject)Instantiate(bitBaconPrefab, transform.position, transform.rotation);

    //     baconName = inst.gameObject.name;

    //     Destroy(gameObject);
    //     Destroy(inst.gameObject);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GyuukiBehaviour gyuuki = other.gameObject.GetComponentInParent<GyuukiBehaviour>();

        Debug.Log("OnTriggerEnter2D works!");
        Debug.Log(other.gameObject.name);

        if(!gyuuki)
            return;

        EatBacon();
    }
}
