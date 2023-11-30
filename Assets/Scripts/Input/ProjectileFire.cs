using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    [Header("References")]
    public GameData gameData;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject prefab;
    public ProjectileShootSound projectileShootSound;

    [Header("Properties")]
    [SerializeField]
    //private float cooldown = 0.5f;
    private bool Mouse1Down = false;
    private bool Mouse2Down = false;
    private float lastUsed;

    // Start is called before the first frame update
    void Start()
    {
        gameData = Global.game.GetComponent<GameData>();
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        FetchMouseState();
    }

    void FixedUpdate()
    {
        SpawnProjectile();
    }

    private void FetchMouseState()
    {
        if (!Global.playing)
        {
            return;
        }

        Mouse1Down = Input.GetMouseButton(0);
        Mouse2Down = Input.GetMouseButton(1);
    }

    private void SpawnProjectile()
    {
        if (Time.time - lastUsed < gameData.bulletRate) { return; }

        if (Mouse1Down)
        {
            GameObject projectile = Instantiate(prefab, player.transform.position, player.transform.rotation);

            projectile.GetComponent<Projectile>().positionStart = player.transform.position;
            projectile.GetComponent<Projectile>().positionEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            projectileShootSound.PlaySound();

            lastUsed = Time.time;
        }
    }
}
