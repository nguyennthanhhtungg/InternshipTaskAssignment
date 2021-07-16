using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static string BriefDescription(string text, int length)
        {
            string brief = "";

            if (text.Length <= length)
            {
                brief = text + "...";
            }
            else
            {
                brief = text.Substring(0, length + 1).ToString();

                if (brief[length] == ' ')
                {
                    brief = brief.Substring(0, length) + "...";
                }
                else
                {
                    int count = 0;

                    for (int i = length; i >= 0; i--)
                    {
                        if (brief[i] != ' ')
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if(length < count)
                    {
                        brief = "...";
                    }
                    else
                    {
                        brief = brief.Substring(0, length - count) + "...";
                    }
                }
            }


            return brief;
        }

        static void Main(string[] args)
        {
            string text = "Nguyễn Thanh Tùng";
            int length = 10;

            string brief = BriefDescription(text, length);
            Console.WriteLine(brief);
            Console.WriteLine(brief.Length);
        }
    }
}
