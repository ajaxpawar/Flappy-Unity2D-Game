using Assets.Application.Services;
using Assets.Core.Constants;
using Assets.Core.Interfaces;
using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Bird _bird;
    private float MovementForce =3.55f;
    private Animator _animator;
    private IBirdAnimationService _birdAnimationService;
    private IBirdAudioManager _birdAudioManager;
    private AudioSource[] _audioSources;
    private AudioSource _birdWingFlapAudioSource;
    private AudioSource _birdCrashAudioSource;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _bird = new Bird(MovementForce);
        _birdAnimationService = new BirdAnimationService(_animator);
        _audioSources = GetComponents<AudioSource>();
        if (_audioSources.Length > 0)
        {
            if (_audioSources[0] is not null)
            {
                _birdWingFlapAudioSource = (AudioSource)_audioSources[0];
            }
            if (_audioSources[1] is not null)
            {
                _birdCrashAudioSource = (AudioSource)_audioSources[1];
            }
        }
        _birdAudioManager = new BirdAudioManager(_birdWingFlapAudioSource, _birdCrashAudioSource);
    }
    private void Start()
    {
        if (GameManager.instance.IsGameOn)
        {
            _birdAnimationService.ActivateFlyingAnimation();

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.IsGameOn) 
        {
            _birdAudioManager.PlayWingFlapAudio();
            MoveBird();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.IsGameOn && !IsCollisionObjectIsUpperBoundry(collision))
        {
            _birdAudioManager.PlayCrashAudio();
            _birdAnimationService.ActivateGameOverAnimation();
            StartCoroutine(WaitForGameOver());

        }

    }

    private static bool IsCollisionObjectIsUpperBoundry(Collision2D collision)
    {
        return collision.gameObject.CompareTag(Tags.Env_UpperBoundry);
    }

    private void MoveBird()
     {
        _rigidbody2D.linearVelocity = _bird.CalculateMovement();
    }
    private IEnumerator WaitForGameOver()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.instance.SetGameOver();
    }
}
