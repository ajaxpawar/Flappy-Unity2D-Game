using UnityEngine;

public class BirdAnimationService : IBirdAnimationService
{
    private Animator _animator;
    public BirdAnimationService(Animator animator)
    {
        _animator = animator;
    }
    public void ActivateFlyingAnimation()
    {
        _animator.SetBool(Animations.BirdAnimation,true);
    }

    public void ActivateGameOverAnimation()
    {
        _animator.SetBool(Animations.BirdAnimation, false);
    }
}
