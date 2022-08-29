/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1.440
 *UnityVersion:   2018.4.17f1
 *Date:           2020-02-28
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using IFramework.MVVM;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace IFramework.UI.MVVM
{
    /// <summary>
    /// UIView 基类
    /// </summary>
    public abstract class UIView : View, IViewEventHandler
    {

        public UIPanel panel;
        private ViewEventType _lastState = ViewEventType.None;
        public ViewEventType lastState { get { return _lastState; } }

        protected UIView Bind(Text text, Func<string> getter)
        {
            handler.BindProperty(() => {
                string tmp = getter();
                if (tmp != text.text)
                {
                    text.text = tmp;
                }
            });
            return this;
        }
        protected UIView Bind(InputField input, Func<string> getter)
        {
            handler.BindProperty(() => {
                string tmp = getter();
                if (tmp != input.text)
                {
                    input.text = tmp;
                }
            });
            return this;
        }
        protected UIView Bind(Slider slider, Func<float> getter)
        {
            handler.BindProperty(() => {
                float tmp = getter();
                if (slider.value != tmp)
                {
                    slider.value = tmp;
                }
            });
            return this;
        }
        protected UIView Bind(Toggle toggle, Func<bool> getter)
        {
            handler.BindProperty(() => {
                bool tmp = getter();
                if (tmp != toggle.isOn)
                {
                    toggle.isOn = tmp;
                }
            });
            return this;
        }

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


        protected abstract void OnLoad();
        protected abstract void OnShow();
        protected abstract void OnHide();
        protected abstract void OnClose();

        void IViewEventHandler.OnLoad()
        {
            OnLoad();
            _lastState = ViewEventType.OnLoad;
        }

        void IViewEventHandler.OnShow()
        {
            OnShow();
            _lastState = ViewEventType.OnShow;
        }

        void IViewEventHandler.OnHide()
        {
            OnHide();
            _lastState = ViewEventType.OnHide;

        }

        void IViewEventHandler.OnClose()
        {
            OnClose();
            _lastState = ViewEventType.OnClose;
        }
    }
    public abstract class UIView<VM, Panel> : UIView where VM : UIViewModel where Panel : UIPanel
    {
        public VM Tcontext { get { return this.context as VM; } }
        public Panel Tpanel { get { return this.panel as Panel; } }
    }
}
