using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController
{
    CharacterModel _characterModel;
    CharacterView _characterView;
    bool flipX;


    public void SetCharacterModel(CharacterModel characterModel, CharacterView characterView)
    {
        _characterModel = characterModel;
        _characterView = characterView;

        _characterModel.OnJump += _characterView.Jump;
        _characterModel.OnRun += _characterView.Run;
        _characterModel.OnCrouch += _characterView.Crouch;
        _characterModel.OnShootUp += _characterView.ShootUp;
        _characterModel.OnDead += _characterView.Dead;
    }

    public void ListenerInputs()
    {
        float AxisX = Input.GetAxis("Horizontal");
        if (AxisX > 0.1f)
            flipX = false;
        else if (AxisX < -0.1f)
            flipX = true;
        _characterModel.Move(new Vector2(AxisX, 0), flipX);

        if (Input.GetKeyDown(KeyCode.X))
            _characterModel.Jump();

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (AxisX != 0)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    _characterModel.ShootDUP(flipX);
                    if (AxisX != 0)
                        _characterView.ShootDUP(true);
                }
            }
            else
            {
                _characterModel.Crouch();
                _characterView.ShootDUP(false);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _characterModel.SeeUp();
            if (AxisX != 0 && Input.GetKey(KeyCode.Z))
            {
                _characterModel.ShootFUP(flipX);

                _characterView.ShootFUP(true);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                _characterModel.ShootUp(flipX);
                _characterView.ShootFUP(false);
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            _characterModel.Shoot(flipX);
            if (AxisX != 0)
            {
                _characterView.ShootRun(true);
                _characterView.ShootDUP(false);
                _characterView.ShootFUP(false);
            }
        }
        else if (AxisX == 0)
        {
            _characterView.ShootRun(false);
            _characterView.ShootDUP(false);
            _characterView.ShootFUP(false);
        }
        else
            _characterView.ShootUp(false);


    }
}
