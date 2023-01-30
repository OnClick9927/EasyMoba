/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-08-03
 *Description:    Description
 *History:        2022-08-03--
*********************************************************************************/

using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace IFramework.UI.MVC
{
    public abstract class UIView<T> : UIView where T : UIPanel
    {
        public T Tpanel { get { return panel as T; } }
    }
    public abstract class UIView : IViewEventHandler
    {
        protected UIView BindInputField(InputField input, UnityAction<string> callback)
        {
            input.onValueChanged.AddListener(callback);
            return this;
        }
        protected UIView BindToggle(Toggle toggle, UnityAction<bool> callback)
        {
            toggle.onValueChanged.AddListener(callback);
            return this;
        }
        protected UIView BindSlider(Slider slider, UnityAction<float> callback)
        {
            slider.onValueChanged.AddListener(callback);
            return this;
        }
        protected UIView BindOnEndEdit(InputField input, UnityAction<string> callback)
        {
            input.onEndEdit.AddListener(callback);
            return this;
        }
        protected UIView BindOnValidateInput(InputField input, InputField.OnValidateInput callback)
        {
            input.onValidateInput = callback;
            return this;
        }
        protected UIView BindButton(Button button, UnityAction callback)
        {
            button.onClick.AddListener(callback);
            return this;
        }
        public UIPanel panel;
     
        protected abstract void OnLoad();
        protected abstract void OnShow();
        protected abstract void OnHide();
        protected abstract void OnClose();

        void IViewEventHandler.OnLoad()
        {
            OnLoad();
        }

        void IViewEventHandler.OnShow()
        {
            OnShow();
        }

        void IViewEventHandler.OnHide()
        {
            OnHide();
        }

        void IViewEventHandler.OnClose()
        {
            OnClose();
        }
    }
}
