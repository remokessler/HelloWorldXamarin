using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HelloWorld.Layouts.Model
{
    public class LayoutNavModel
    {
        public Page[] NavEntries = new Page[]
        {
            new AbsoluteLayout(),
            new FlexLayouts(),
            new FrameView(),
            new GridLayout(),
            new RelativeLayout(),
            new ScrollView(),
            new StackLayout(),
            new TemplatedView()
        };
    }
}
