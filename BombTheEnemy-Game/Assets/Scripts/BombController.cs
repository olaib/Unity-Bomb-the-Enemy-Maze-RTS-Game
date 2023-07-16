using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject bomb;
    private const float bombFuseTime = 3f;
    private bool isHodingBomb = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        isHodingBomb = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHodingBomb && Input.GetKeyDown(KeyCode.X))
        {
            isHodingBomb = false;
            StartCoroutine(ThrowBomb());
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            isHodingBomb = true;
        }
    }

    private IEnumerator ThrowBomb()
    {
        GameObject bombInstance = Instantiate(bomb, transform.position, Quaternion.identity);
        bombInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
    
        yield return new WaitForSeconds(1f);
        Destroy(bombInstance);
    }
}
