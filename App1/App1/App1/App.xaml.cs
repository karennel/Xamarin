﻿using Xamarin.Forms;

namespace App1
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      //ContainerBuilder()

      MainPage = new MainPage();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
