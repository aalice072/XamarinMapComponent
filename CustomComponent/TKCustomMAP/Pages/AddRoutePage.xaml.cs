﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CustomComponent.TKCustomMAP.ViewModels;
using TK.CustomMap;
using TK.CustomMap.Overlays;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CustomComponent.TKCustomMAP.Pages
{
    public partial class AddRoutePage : ContentPage
    {
        public AddRoutePage(ObservableCollection<TKRoute> routes, ObservableCollection<TKCustomMapPin> pins, MapSpan bounds)
        {
            InitializeComponent();

            var googleImage = new Image
            {
                Source = "powered_by_google_on_white.png"
            };

            var searchFrom = new PlacesAutoComplete(false) { ApiToUse = PlacesAutoComplete.PlacesApi.Google, Bounds = bounds, Placeholder = "From" };
            searchFrom.SetBinding(PlacesAutoComplete.PlaceSelectedCommandProperty, "FromSelectedCommand");
            var searchTo = new PlacesAutoComplete(false) { ApiToUse = PlacesAutoComplete.PlacesApi.Google, Bounds = bounds, Placeholder = "To" };
            searchTo.SetBinding(PlacesAutoComplete.PlaceSelectedCommandProperty, "ToSelectedCommand");

            if (Device.OS == TargetPlatform.Android)
            {
                _baseLayout.Children.Add(
                    googleImage,
                    Constraint.Constant(10),
                    Constraint.RelativeToParent(l => l.Height - 30));
            }

            _baseLayout.Children.Add(
                searchTo,
                yConstraint: Constraint.RelativeToView(searchFrom, (l, v) => searchFrom.HeightOfSearchBar + 10));

            _baseLayout.Children.Add(
                searchFrom,
                Constraint.Constant(0),
                Constraint.Constant(10));

            BindingContext = new AddRouteViewModel(routes, pins, bounds);
        }
    }
}