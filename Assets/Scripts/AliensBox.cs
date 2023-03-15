using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AliensBox : MonoBehaviour
{
    private int aliensNumber;
    private int xDirection = 1;
    private int yDirection = 2;
    private bool isBoundCollided = false;
    [SerializeField]
    private GameObject enemyLaserPrefab;
    public GameObject gameController;
    private GameController controller;

    void Start()
    {
        controller = gameController.GetComponent<GameController>();

        aliensNumber = GetChildren().Count();
        AddColliderAroundChildren();
        StartCoroutine(MovementRoutine());
        StartCoroutine(EnemyLaserRoutine());
    }


    void Update()
    {
        int value = GetChildren().Count();
        if (value != aliensNumber)
        {
            AddColliderAroundChildren();
            aliensNumber = value;
        }
        if (aliensNumber == 0 && controller.isPlayerAlive)
        {
            controller.WinGame();
        }
    }

    IEnumerator MovementRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        if (isBoundCollided)
        {
            xDirection = xDirection * -1;
            yDirection--;
            transform.position = new Vector3(transform.position.x, yDirection, 0);
            yield return new WaitForSeconds(1.0f);
            isBoundCollided = false;
        }
        transform.position = new Vector3((transform.position.x) + 1 * xDirection, yDirection, 0);
        yield return MovementRoutine();
    }

    IEnumerator EnemyLaserRoutine()
    {
        while (controller.isPlayerAlive)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9.4f, 9.4f), transform.position.y, 0);
            Instantiate<GameObject>(enemyLaserPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "left_bound" || collision.tag == "right_bound")
        {
            isBoundCollided = true;
        }
    }

    private void AddColliderAroundChildren()
    {
        transform.localScale = Vector3.one;
        GetBounds(out Bounds bounds);

        BoxCollider2D boxCol = GetComponent<BoxCollider2D>();
        boxCol.offset = bounds.center - transform.position;
        boxCol.size = bounds.size;

    }

    private void GetBounds(out Bounds bounds) {
        bounds = new Bounds(Vector3.zero, Vector3.zero);
        IEnumerable<Transform> descendants = GetChildren();

        foreach (Transform desc in descendants)
        {
            if (desc.TryGetComponent<Renderer>(out Renderer childRenderer))
            {
                if (bounds.extents == Vector3.zero)
                    bounds = childRenderer.bounds;
                bounds.Encapsulate(childRenderer.bounds);
            }
        }
    }

    private IEnumerable<Transform> GetChildren ()
    {
        return GetComponentsInChildren<Transform>().Where(t => t != transform);
    }
}