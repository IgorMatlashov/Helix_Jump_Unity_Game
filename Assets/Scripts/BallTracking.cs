using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _diractionOffset;
    [SerializeField] private float _length;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        // Находим ссылки на объекты Ball и Beam
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        // Устанавливаем начальные позиции камеры и минимальной позиции мяча
        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        // Вызываем метод для отслеживания мяча
        TrackBall();
    }

    private void Update()
    {
        // Проверяем, если позиция мяча ниже минимальной позиции,
        // то вызываем метод для отслеживания мяча
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {

        // Получаем позицию Beam и устанавливаем ее высоту на высоту мяча
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;

        // Устанавливаем позицию камеры равной позиции мяча
        _cameraPosition = _ball.transform.position;

        // Вычисляем направление от мяча до Beam с учетом смещения (_directionOffset)
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _diractionOffset;

        // Вычисляем конечную позицию камеры, учитывая длину (_length) и направление
        _cameraPosition -= direction * _length;

        // Устанавливаем позицию и направление камеры
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
