﻿using Earthbender.Models;
using Earthbender.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Earthbender.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListActions : ContentPage
    {
        AddActionViewModel viewModel;

        public ListActions()
        {
            InitializeComponent();
            viewModel = new AddActionViewModel();
        }
        private void listActions()
        {
            var res = viewModel.GetAllActions().Result;
            lstData.ItemsSource = res;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listActions();
        }

        private void btnAddRecord(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddActions());
        }

        private async void lsdata_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Actions obj = (Actions)e.SelectedItem;
                string res = await DisplayActionSheet("View", "Cancel", null, "View Details");

                switch (res)
                {
                    case "View Details":
                        await this.Navigation.PushAsync(new ViewAction(obj));
                        break;
                }

                lstData.SelectedItem = null;
            }
        }
    }
}