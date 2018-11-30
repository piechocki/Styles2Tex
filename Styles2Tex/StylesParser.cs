using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Styles2Tex
{
    class StylesParser
    {
        public void Convert(Microsoft.Office.Interop.Word.Application word, Dictionary<string, string> config)
        {
            string txt;
            string path;
            string para;
            string file = "";
            Range ranActRange;
            Document doc = word.ActiveDocument;

            DateTime begin = DateTime.Now;
            if (config["save_directory"] == "")
            {
                MessageBox.Show("Please set the save directory first.");
                return;
            }
            else
            {
                path = config["save_directory"];
            }

            int k = 0;
            int j = 0;
            string file_txt = "";
            int para_count = doc.Paragraphs.Count;
            string status;

            for (int i = 1; i <= para_count; i++)
            {
                status = string.Format("Processing paragraph {0} of {1}", i, para_count);
                word.StatusBar = status;
                ranActRange = doc.Paragraphs[i].Range;
                para = Text_Format(ranActRange.Text);
                txt = "";

                switch (doc.Paragraphs[i].get_Style().NameLocal)
                {
                    case "Überschrift 1":
                        {
                            if (file_txt != "")
                            {
                                // Save the previous file_txt if it's not empty
                                j += Save_File(file, file_txt, System.Convert.ToBoolean(config["overwrite"])) ? 1 : 0;
                                // Clean the file_text variable for the next section
                                file_txt = "";
                                k = k + 1;
                            }

                            if (k == 0)
                            {
                                // Exception for first file (abstract)
                                file = Path.Combine(path, "abstract.tex");
                                txt = "\\section*{\\centering{" + para + "}}";
                            }
                            else
                            {
                                // All other files will be saved with its section number
                                file = Path.Combine(path, "sec" + System.Convert.ToString(k) + ".tex");
                                txt = "\\section{" + para + "} \\label{" + Label_Format(para) + "}";
                            }

                            break;
                        }

                    case "Überschrift 2":
                        {
                            txt = "\\subsection{" + para + "} \\label{" + Label_Format(para) + "}";
                            break;
                        }

                    case "Überschrift 3":
                        {
                            txt = "\\subsubsection{" + para + "} \\label{" + Label_Format(para) + "}";
                            break;
                        }

                    case "Standard":
                        {
                            txt = para;

                            // Check if carriage return characters after the paragraph are required
                            if (i < doc.Paragraphs.Count)
                            {
                                if (doc.Paragraphs[i + 1].get_Style().NameLocal == "Standard" & No_Equation(doc, i) & !doc.Paragraphs[i + 1].Range.Text.StartsWith("\\input{") & !doc.Paragraphs[i + 1].Range.Text.StartsWith("\\begin{"))
                                {
                                    txt = txt + "\\\\";
                                }                                    
                            }
                            break;
                        }

                    case "Titel":
                        {
                            break;
                        }

                    case "Listenabsatz":
                        {
                            if (doc.Paragraphs[i - 1].get_Style().NameLocal != "Listenabsatz")
                            {
                                // If it's the first item in itemize, first add an opening bracket
                                txt = "\\begin{itemize}\r";
                            }
                            // Add the item
                            txt = txt + "\\item " + Text_Format(ranActRange.ListParagraphs[1].Range.Text);

                            if (doc.Paragraphs[i - 1].get_Style().NameLocal == "Listenabsatz" & doc.Paragraphs[i + 1].get_Style().NameLocal != "Listenabsatz")
                            {
                                // If it's the last item in itemize, finally close the bracket
                                txt = txt + "\\end{itemize}";
                            }
                            break;
                        }

                    default:
                        {
                            // If there is another paragraph with unknown format, return an error and exit
                            MessageBox.Show(string.Format("The style of paragraph #{0} is unknown. Style name: {1}.", i, doc.Paragraphs[i].get_Style().NameLocal), "Error");
                            return;
                        }
                }

                if (txt != "")
                {
                    if (file_txt != "")

                        // If file_txt is not empty anymore, append the paragraph separated by a carriage return
                        file_txt = file_txt + "\r" + txt;
                    else


                        // Else it's the first line in the file and no carriage return is required
                        file_txt = txt;
                }
            }

            // Save the last file_txt if the parsing of the word is finished
            j += Save_File(file, file_txt, System.Convert.ToBoolean(config["overwrite"])) ? 1 : 0;

            if (j == 0)
            {
                status = "Processing has finished. No tex files has been written.";
            }
            else
            {
                status = string.Format("Document processed successfully. {0} tex files has been written. Runtime: {1} seconds", j, System.Convert.ToString((DateTime.Now - begin).Seconds));
            }
            word.StatusBar = status;
            System.Threading.Thread.Sleep(2500);
            word.StatusBar = "";
        }

        private bool No_Equation(Document doc, int i)
        {
            int j;
            bool ne = true;

            for (j = i; j >= i - 3; j += -1)
            {
                if (j == 0)
                    break;
                if (doc.Paragraphs[j].Range.Text.StartsWith("\\begin{equation}"))
                    ne = false;
            }
            return ne;
        }

        private string Text_Format(string text)
        {
            string tf = text.Trim();
            tf = tf.Replace("\r", "");
            tf = tf.Replace("„", "\"`");
            tf = tf.Replace("“", "\"'");
            return tf;
        }

        private string Label_Format(string label)
        {
            string lf = label.Trim();
            lf = lf.ToLower();
            lf = lf.Replace(" ", "-");
            lf = lf.Replace("\"`", "");
            lf = lf.Replace("\"'", "");
            return lf;
        }

        private bool Save_File(string file, string file_txt, bool overwrite)
        {
            if (!File.Exists(file) || overwrite)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(file, FileMode.Create), Encoding.GetEncoding("iso-8859-1")))
                    {
                        sw.Write(file_txt);
                    }
                    return true;
                }
                catch(Exception e)
                {
                    MessageBox.Show(string.Format("At least one tex file could not be saved. Reason: {0}", e.Message), "Error");
                }
            }
            return false;
        }
    }
}
