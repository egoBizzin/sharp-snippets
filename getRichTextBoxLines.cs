using System;
using System.Text;
using System.Windows.Forms;

namespace Ego
{
    public static partial class snippets
    {
        public static string getRichTextBoxLines(RichTextBox rtb) {
            StringBuilder sb = new StringBuilder();
            foreach (string line in rtb.Lines)
                sb.Append(line + Environment.NewLine);
            return sb.ToString();
        }//getRichTextBoxLines
    }//class
}//namepsace