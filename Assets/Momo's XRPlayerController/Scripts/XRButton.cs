using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Button))]
[RequireComponent(typeof(BoxCollider))]
public class XRButton : MonoBehaviour
{
    UnityEngine.UI.Button button;
    BoxCollider boxCollider;
    RectTransform rectTransform;

    Animator buttonAnimator;
    Sprite originalButtonSprite;
    UnityEngine.UI.Image buttonImage;

    ButtonState buttonState;

    public ButtonState state
    {
        get { return buttonState; }
    }

    void Awake()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null) {
            GetComponent<BoxCollider>().size = new Vector3(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y, 1);
        }
        buttonImage = button.GetComponent<UnityEngine.UI.Image>();
        originalButtonSprite = buttonImage.sprite;
        buttonAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // If button is set to be non-interactable, run the ChangeState function
        if (!button.interactable && buttonState != ButtonState.DISABLED)
        {
            ChangeState(ButtonState.DISABLED);
        }
    }

    public enum ButtonState
    {
        UP, HOVERED, PRESSED, DISABLED
    };

    public void ChangeState(ButtonState state)
    {
        // Trigger button transitions
        switch (state)
        {
            case ButtonState.DISABLED:
                switch (button.transition)
                {
                    case UnityEngine.UI.Selectable.Transition.SpriteSwap:
                        buttonImage.sprite = button.spriteState.disabledSprite;
                        break;
                    case UnityEngine.UI.Selectable.Transition.ColorTint:
                        buttonImage.color = button.colors.disabledColor;
                        break;
                    case UnityEngine.UI.Selectable.Transition.Animation:
                        buttonAnimator.Play(button.animationTriggers.disabledTrigger);
                        break;
                    case UnityEngine.UI.Selectable.Transition.None:
                        break;
                }
                button.interactable = false;
                buttonState = ButtonState.DISABLED;
                break;
            case ButtonState.HOVERED:
                switch (button.transition)
                {
                    case UnityEngine.UI.Selectable.Transition.SpriteSwap:
                        buttonImage.sprite = button.spriteState.highlightedSprite;
                        break;
                    case UnityEngine.UI.Selectable.Transition.ColorTint:
                        buttonImage.color = button.colors.highlightedColor;
                        break;
                    case UnityEngine.UI.Selectable.Transition.Animation:
                        buttonAnimator.Play(button.animationTriggers.highlightedTrigger);
                        break;
                    case UnityEngine.UI.Selectable.Transition.None:
                        break;
                }
                buttonState = ButtonState.HOVERED;
                break;
            case ButtonState.PRESSED:
                switch (button.transition)
                {
                    case UnityEngine.UI.Selectable.Transition.SpriteSwap:
                        buttonImage.sprite = button.spriteState.pressedSprite;
                        break;
                    case UnityEngine.UI.Selectable.Transition.ColorTint:
                        buttonImage.color = button.colors.pressedColor;
                        break;
                    case UnityEngine.UI.Selectable.Transition.Animation:
                        buttonAnimator.Play(button.animationTriggers.pressedTrigger);
                        break;
                    case UnityEngine.UI.Selectable.Transition.None:
                        break;
                }
                button.onClick.Invoke();
                buttonState = ButtonState.PRESSED;
                break;
            case ButtonState.UP:
                switch (button.transition)
                {
                    case UnityEngine.UI.Selectable.Transition.SpriteSwap:
                        buttonImage.sprite = originalButtonSprite;
                        break;
                    case UnityEngine.UI.Selectable.Transition.ColorTint:
                        buttonImage.color = button.colors.normalColor;
                        break;
                    case UnityEngine.UI.Selectable.Transition.Animation:
                        buttonAnimator.Play(button.animationTriggers.normalTrigger);
                        break;
                    case UnityEngine.UI.Selectable.Transition.None:
                        break;
                }
                buttonState = ButtonState.UP;
                break;
        }
    }
}
