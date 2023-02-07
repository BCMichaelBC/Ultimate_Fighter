using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewCharacters : MonoBehaviour
{
    public GameObject[] _characters;
    public GameObject _image;
    private int _imageIndex = 0;

    public void OnClickLeft()
    {
        _imageIndex = ((0 == _imageIndex) ? _characters.Length : _imageIndex) - 1;
        OnClickAnnoying();
    }

    public void OnClickRight()
    {
        _imageIndex = ((_characters.Length - 1) == _imageIndex) ?  0 : (_imageIndex + 1);
        OnClickAnnoying();
    }

    public void OnClickAnnoying()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Annoying;
    }

    public void OnClickAttack0()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Attack0;
    }

    public void OnClickAttack1()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Attack1;
    }

    public void OnClickAttack2()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Attack2;
    }

    public void OnClickStand()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Stand;
    }

    public void OnClickHit()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Hit;
    }

    public void OnClickGroggy()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Groggy;
    }

    public void OnClickWin()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Win;
    }

    public void OnClickLose()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Lose;
    }

    public void OnClickPortrait()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().Portrait;
    }

    public void OnClickPortraitLose()
    {
        _image.GetComponent<Image>().sprite = _characters[_imageIndex].GetComponent<PreviewCharacter>().PortraitLose;
    }
    

    void Start()
    {   
        OnClickAnnoying();
    }

    void Update()
    {   
    }
}
