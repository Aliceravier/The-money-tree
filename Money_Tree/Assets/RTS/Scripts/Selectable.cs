using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    // Is the entity selected?
    // More than one can be selected at a time
    public bool Selected
    {
        get
        {
            return _selected;
        }
        set
        {
            _selected = value;
            if(value)
            {
                Select();
            }
            else
            {
                Deselect();
            }
        }
    }

    // The color the sprite will glow when selected
    public Color SelectionGlowColor = Color.yellow;

    // The intensity of the selection glow
    public float SelectionGlowIntensity = 0.4f;

    // Can the unit be [de]selected by OnMouseDown()?
    public bool MouseSelectable = true;    


    bool _selected = false;
    MaterialPropertyBlock _materialProps; // (Used to control the glow when selected)
    SpriteRenderer _spriteRenderer;


    void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        if(_spriteRenderer != null)
        {
            _materialProps = new MaterialPropertyBlock();
        }

        _selected = false;
        this.ApplyGlowColor(Color.black, this.SelectionGlowIntensity);
    }

    // Applies the given color to "Sprites/Edge"'s _EdgeGlowColor
    // (does nothing if there is no sprite renderer)
    void ApplyGlowColor(Color color, float intensity)
    {
        if(_spriteRenderer != null)
        {
            _spriteRenderer.GetPropertyBlock(_materialProps);
            _materialProps.SetColor("_EdgeGlowColor", color);
            _materialProps.SetFloat("_EdgeGlowIntensity", intensity);
            _spriteRenderer.SetPropertyBlock(_materialProps);
        }
    }

    // Selects the entity
    public void Select()
    {
        _selected = true;
        this.ApplyGlowColor(this.SelectionGlowColor, this.SelectionGlowIntensity);
    }

    // Deselects the entity
    public void Deselect()
    {
        _selected = false;
        this.ApplyGlowColor(Color.black, this.SelectionGlowIntensity);
    }

    void OnMouseDown()
	{
        if(MouseSelectable)
        {
            Selected = !Selected;
        }
    }
}
