namespace Simple.Models
{
    public partial class Color
    {
        // Convert the hex value to an html color value for any hex value
        public string ToHtmlColor(string alpha)
        {
            // There are problems with this!  A test should show them.
            return "#" + HexValue.Substring(2,6) + alpha;  // add an alpha value so it's not so bright
        }
    }
}
