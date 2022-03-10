using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Thruster : SingleInputHandler
{
    [SerializeField]
    Rigidbody2D _body = default;

    [SerializeField]
    Vector2 _thrusterDirection = Vector2.left;

    [SerializeField]
    float _thrustPower = 1f;

    [Header("Effect")]

    [SerializeField]
    private Vector3 _offset = Vector2.zero;

    /// <summary>
    /// �M�ʃJ�[�u
    /// </summary>
    [SerializeField]
    AnimationCurve _heatCurve = AnimationCurve.EaseInOut(0f, 0f, 4f, 1f);

    /// <summary>
    /// �o�̓J�[�u�ɑ΂��Ă̏搔
    /// </summary>
    [SerializeField]
    float _outputFlowCurveMultiplier = 1f;

    /// <summary>
    /// �o�̓J�[�u
    /// </summary>
    [SerializeField]
    AnimationCurve _outputFlowCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    /// <summary>
    /// �o�͗��̃J�[�u�ɑ΂��Ă̏搔
    /// </summary>
    [SerializeField]
    float _outputAmountCurveMultiplier = 1f;

    /// <summary>
    /// �o�͗ʂ̃J�[�u
    /// </summary>
    [SerializeField]
    AnimationCurve _outputAmountCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0.1f);

    /// <summary>
    /// �o�͂̐F���z
    /// </summary>
    [SerializeField]
    Gradient _outputColorGradient = new Gradient();

    private bool _active = false;
    private float _time = 0f;

    private void Awake()
    {
        if (_body == default)
        {
            _body = GetComponent<Rigidbody2D>();
        }
    }

    protected override void Update()
    {
        base.Update();
        CheckInput();
        Thrust();
    }

    protected override void OnKeyPressed()
    {
        _active = true;
    }

    protected override void OnKeyReleased()
    {
        _active = false;
        _time = 0;
    }

    private void CheckInput()
    {
        if (_active)
        {
            _time += Time.deltaTime;
        }
    }

    private void Thrust()
    {
        if (_active && _body)
        {
            _body.AddForce(transform.rotation * (_thrusterDirection * _thrustPower));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 wDirection = transform.rotation * (_thrusterDirection * _thrustPower);
        Vector3 pos = transform.position;
        Vector3 arrowHeadPos = pos + wDirection;
        Gizmos.DrawLine(pos, arrowHeadPos);
    }
}