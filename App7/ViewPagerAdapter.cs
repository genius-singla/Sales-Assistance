using Android.Support.V4.App;
using Android.Support.V4.View;

namespace App7
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        Fragment[] _fragments;

        public ViewPagerAdapter(FragmentManager fm, Fragment[] fragments) : base(fm)
        {
            _fragments = fragments;
        }

        public override int Count => _fragments.Length;

        public override Fragment GetItem(int position) => _fragments[position];
    }
}