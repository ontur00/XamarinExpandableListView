using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace TestExpandedListView
{
    class ExpandableListAdapter : BaseExpandableListAdapter
    {
        private Context context { get; set; }
        private List<string> listDataHeader { get; set; }           // header titles
                                                                    // child data in format of header title, child title
        private Dictionary<string, List<string>> listDataChild { get; set; }

        public ExpandableListAdapter(Context context, List<string> listDataHeader,
            Dictionary<string, List<string>> listDataChild)
        {
            this.context = context;
            this.listDataHeader = listDataHeader;
            this.listDataChild = listDataChild;
        }

        public override int GroupCount
        {
            get
            {
                return listDataHeader.Count;
            }
        }

        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            List<string> lString = new List<string>();
            listDataChild.TryGetValue(listDataHeader[groupPosition], out lString);
            return lString[childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            string key = listDataHeader[groupPosition];
            List<string> lChild = new List<string>();
            listDataChild.TryGetValue(key, out lChild);
            return lChild.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            string childText = (string)GetChild(groupPosition, childPosition);

            if (convertView == null)
            {
                LayoutInflater infalInflater = (LayoutInflater)this.context
                        .GetSystemService(Context.LayoutInflaterService);
                convertView = infalInflater.Inflate(Resource.Layout.list_item, null);
            }

            TextView txtListChild = (TextView)convertView.FindViewById(Resource.Id.lblListItem);

            txtListChild.Text = childText;
            return convertView;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return listDataHeader[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            ViewHolderParrent viewHolderParent = null;
            var viewParent = convertView;

            string headerTitle = (string)GetGroup(groupPosition);

            if( viewParent != null )
            {
                viewHolderParent = viewParent.Tag as ViewHolderParrent;
                Console.WriteLine("Juz zainicjalizowane");
            }

            if( viewHolderParent == null )
            {
                viewHolderParent = new ViewHolderParrent();
                LayoutInflater layoutInflater = (LayoutInflater)this.context.GetSystemService(Context.LayoutInflaterService);
                viewParent = layoutInflater.Inflate(Resource.Layout.list_group, null);

                viewHolderParent.textViewParent = viewParent.FindViewById<TextView>(Resource.Id.lblListHeader);
                viewParent.Tag = viewHolderParent;

                Console.WriteLine("Inflate");
            }

            //if (viewParent == null )
            //{
            //    LayoutInflater layoutInflater = (LayoutInflater)this.context.GetSystemService(Context.LayoutInflaterService);
            //    viewParent = layoutInflater.Inflate(Resource.Layout.list_group, null);

            //    viewHolderParent = new ViewHolderParrent() { textViewParent = convertView.FindViewById<TextView>(Resource.Id.lblListHeader) };            
            //    viewHolderParent.textViewParent.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);

            //    viewParent.Tag = viewHolderParent;
            //}

            
            viewHolderParent.textViewParent.Text = headerTitle;

            return viewParent;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        class ViewHolderParrent : Java.Lang.Object
        {
            public TextView textViewParent { get; set; }
        }
    }
}