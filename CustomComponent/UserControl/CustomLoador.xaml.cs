﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomComponent.UserControl
{
    public partial class CustomLoador : Grid
    {
        
        private static BindableProperty InfoMessage = BindableProperty.Create(
                                                         propertyName: "InfoText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(CustomLoador),
                                                         defaultValue: "Loading...",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: titleTextPropertyChanged);
        
        private static BindableProperty InfoIcon = BindableProperty.Create(
                                                       propertyName: "InfoImage",
                                                       returnType: typeof(string),
                                                       declaringType: typeof(CustomLoador),
                                                       defaultValue: "",
                                                       defaultBindingMode: BindingMode.TwoWay,
                                                       propertyChanged: ImageSourcePropertyChanged);

        public CustomLoador()
        {
            InitializeComponent();

        }

        public string InfoText
        {
            get { return (string)GetValue(InfoMessage); }
            set { SetValue(InfoMessage, value); }
        }

        public string InfoImage
        {
            get { return (string)GetValue(InfoIcon); }
            set { SetValue(InfoIcon, value); }
        }


        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomLoador)bindable;
            control.imgIcon.Source = ImageSource.FromFile(newValue.ToString());
        }

        private static void titleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomLoador)bindable;
            control.lblMsg.Text = newValue.ToString();
        }
    }
}
