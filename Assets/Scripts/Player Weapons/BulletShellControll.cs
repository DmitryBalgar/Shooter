using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShellControll : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _slowDownSpeedIndex;
    [SerializeField] private Transform _shellPositionSpawm;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void DropShell()
    {
        //float startSpeed = Random.Range(2f, 4.5f);
        //float startPoint = Random.Range(0.5f, 0.9f);
        //Vector3 _currentSpawnPoint = _shellPositionSpawm.position;
        ////_currentSpawnPoint += (spawnDir - shellPositionSpawm.position.normalized);

        ////Rigidbody2D shellRb = Instantiate(this.gameObject, _currentSpawnPoint, Quaternion.identity, _shellPositionSpawm);

        //var dir = new Vector2(spawnDir.normalized.x * startSpeed, spawnDir.normalized.y * startSpeed);
        //shellRb.velocity = Quaternion.Euler(0, 0, -90f) * dir;
        //shellRb.rotation = Random.Range(0, 360f);

        //_shellList.Add(shellRb);
        //_shellIndex++;
        //if (_shellIndex > 200)
        //{
        //    Destroy(_shellList[0].gameObject);
        //    _shellList.Remove(_shellList[0]);
        //    _shellIndex--;
        //}
    }

}
