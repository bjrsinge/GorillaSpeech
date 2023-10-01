using ComputerInterface;
using ComputerInterface.ViewLib;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaSpeech
{
    public class GorillaSpeechView : ComputerView
    {
        private string balloonText;
        private readonly UITextInputHandler textInputHandler;

        public override void OnShow(object[] args)
        {   
            base.OnShow(args);
            Text = "Type what you want the speech balloon to say! Press ENTER once you're done.";
        }

        public override void OnKeyPressed(EKeyboardKey key)
        {
            if (key == EKeyboardKey.Delete)
            {
                if (balloonText.Length == 0) return;

                balloonText = balloonText.Substring(0, balloonText.Length - 1);
            }

            if (!key.IsFunctionKey())
            {
                if (key.TryParseNumber(out var num))
                {
                    string num2 = num.ToString();
                    Debug.Log(num2);

                    balloonText += num2;
                }
                else
                {
                    balloonText += key;
                }
            }

            if (key == EKeyboardKey.Back)
            {
                ReturnToMainMenu();
            }

            if (key == EKeyboardKey.Space)
            {
                balloonText += " ";
            }

            if (key == EKeyboardKey.Enter)
            {
                Plugin.asset.GetComponentInChildren<Text>().text = balloonText;
            }
            Text = balloonText;
        }
    }
}