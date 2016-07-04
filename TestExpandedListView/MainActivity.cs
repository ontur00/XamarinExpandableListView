using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace TestExpandedListView
{
    [Activity(Label = "TestExpandedListView", MainLauncher = true, Icon = "@drawable/icon",
        Theme = "@android:style/Theme.Material.Light")]
    public class MainActivity : Activity
    {
        int count = 1;

        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            InitUI();
            
        }

        private void InitUI()
        {
            expListView = FindViewById<ExpandableListView>(Resource.Id.lvExp);
            PreapareListData();

            listAdapter = new ExpandableListAdapter(ApplicationContext, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);
        }

        private void PreapareListData()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();

            // Adding child data
            listDataHeader.Add("Top 250");
            listDataHeader.Add("Now Showing");
            listDataHeader.Add("Coming Soon..");

            listDataHeader.Add("3");
            listDataHeader.Add("4");
            listDataHeader.Add("5");

            listDataHeader.Add("6");
            listDataHeader.Add("7");
            listDataHeader.Add("8");

            // Adding child data
            List<string> top250 = new List<string>();
            top250.Add("The Shawshank Redemption");
            top250.Add("The Godfather");
            top250.Add("The Godfather: Part II");
            top250.Add("Pulp Fiction");
            top250.Add("The Good, the Bad and the Ugly");
            top250.Add("The Dark Knight");
            top250.Add("12 Angry Men");

            List<string> nowShowing = new List<string>();
            nowShowing.Add("The Conjuring");
            nowShowing.Add("Despicable Me 2");
            nowShowing.Add("Turbo");
            nowShowing.Add("Grown Ups 2");
            nowShowing.Add("Red 2");
            nowShowing.Add("The Wolverine");

            List<string> comingSoon = new List<string>();
            comingSoon.Add("2 Guns");
            comingSoon.Add("The Smurfs 2");
            comingSoon.Add("The Spectacular Now");
            comingSoon.Add("The Canyons");
            comingSoon.Add("Europa Report");

            listDataChild.Add(listDataHeader[0], top250);
            listDataChild.Add(listDataHeader[1], nowShowing);
            listDataChild.Add(listDataHeader[2], comingSoon);

            listDataChild.Add(listDataHeader[3], top250);
            listDataChild.Add(listDataHeader[4], nowShowing);
            listDataChild.Add(listDataHeader[5], comingSoon);

            listDataChild.Add(listDataHeader[6], top250);
            listDataChild.Add(listDataHeader[7], nowShowing);
            listDataChild.Add(listDataHeader[8], comingSoon);
        }


    }
}

