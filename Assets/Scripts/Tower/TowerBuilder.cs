using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private Transform _perentTrasform;

    private float _startAndFinishAdditionalScale = 0.5f;
    private float _additionalScale = 3;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale;


    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosiotion = beam.transform.position;
        spawnPosiotion.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosiotion);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosiotion);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosiotion);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
        spawnPosition.y -= 1;
    }
}
 