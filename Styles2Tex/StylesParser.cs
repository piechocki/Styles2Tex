using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styles2Tex
{
    class StylesParser
    {
        public void convert(Document doc)
        {
            int i;
            int j;
            int k;
            Range ranActRange;
            string txt;
            string path;
            string para;
            string file = "";
            string file_txt;
            DateTime begin;

            begin = DateTime.Now;
            path = "C:\\Users\\marti\\OneDrive\\Documents\\OLAT\\Master\\4. Semester\\Masterarbeit\\LaTeX\\input\\";
            k = 0;
            file_txt = "";

            for (i = 1; i <= doc.Paragraphs.Count; i++)
            {
                ranActRange = doc.Paragraphs[i].Range;
                para = text_format(ranActRange.Text);
                txt = "";

                switch (doc.Paragraphs[i].get_Style())
                {
                    case "Überschrift 1":
                        {
                            if (file_txt != "")
                            {

                                // Save the previous file_txt if it's not empty
                                save_file(file, file_txt);
                                // Clean the file_text variable for the next section
                                file_txt = "";
                                k = k + 1;
                            }

                            if (k == 0)
                            {

                                // Exception for first file (abstract)
                                file = path + "abstract.tex";
                                txt = "\\section*{\\centering{" + para + "}}";
                            }
                            else
                            {


                                // All other files will be saved with its section number
                                file = path + "sec" + System.Convert.ToString(k) + ".tex";
                                txt = "\\section{" + para + "} \\label{" + label_format(para) + "}";
                            }

                            break;
                        }

                    case "Überschrift 2":
                        {
                            txt = "\\subsection{" + para + "} \\label{" + label_format(para) + "}";
                            break;
                        }

                    case "Überschrift 3":
                        {
                            txt = "\\subsubsection{" + para + "} \\label{" + label_format(para) + "}";
                            break;
                        }

                    case "Standard":
                        {
                            txt = para;

                            // Check if carriage return characters after the paragraph are required
                            if (i < doc.Paragraphs.Count)
                            {
                                if (doc.Paragraphs[i + 1].get_Style() == "Standard" & no_equation(i) & Left(doc.Paragraphs[i + 1].Range.Text, 7) != "\\input{" & Left(doc.Paragraphs[i + 1].Range.Text, 7) != "\\begin{")

                                    txt = txt + "\\\\";
                            }

                            break;
                        }

                    case "Titel":
                        {
                            break;
                        }

                    case "Listenabsatz":
                        {
                            if (doc.Paragraphs[i - 1].get_Style() != "Listenabsatz")

                                // If it's the first item in itemize, first add an opening bracket
                                txt = "\\begin{itemize}\r";

                            // Add the item
                            txt = txt + "\\item " + text_format(ranActRange.ListParagraphs[1].Range.Text);

                            if (doc.Paragraphs[i - 1].get_Style() == "Listenabsatz" & doc.Paragraphs[i + 1].get_Style() != "Listenabsatz")

                                // If it's the last item in itemize, finally close the bracket
                                txt = txt + "\\end{itemize}";
                            break;
                        }

                    default:
                        {

                            // If there is another paragraph with unknown format, return an error and exit
                            MsgBox("Fehler: Nicht erkanntes Format eines Absatzes (" + doc.Paragraphs(i).Style + ")");
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
            save_file(file, file_txt);

            Interaction.MsgBox("Das Dokument wurde ohne Fehler übersetzt (Laufzeit: " + System.Convert.ToString(DateTime.DateDiff("s", begin, DateTime.Now)) + " Sekunden).");
        }


        private bool no_equation(int i)
        {
            int j;
            no_equation = true;

            for (j = i; j >= i - 3; j += -1)
            {
                if (j == 0)
                    break;
                if (Left(ActiveDocument.Paragraphs(j).Range.text, 16) == "\\begin{equation}")
                    no_equation = false;
            }
        }


        private string text_format(string text)
        {
            string tf = text.Trim();
            tf = tf.Replace("\r", "");
            tf = tf.Replace("„", "\"`");
            tf = tf.Replace("“", "\"'");
            return tf;
        }


        private string label_format(string label)
        {
            string lf = label.Trim();
            lf = lf.ToLower();
            lf = lf.Replace(" ", "-");
            lf = lf.Replace("\"`", "");
            lf = lf.Replace("\"'", "");
            return lf;
        }

        public void load_config()
        {
            // TODO: encoding, labels, filenames, folders output, 
        }


        private void save_file(string file, string file_txt)
        {
            FileStream stream = new FileStream();           
            stream.Open();
            stream.Type = adTypeText;
            stream.Charset = "iso-8859-1";
            stream.LineSeparator = "\n";
            stream.WriteText(file_txt, adWriteLine);
            stream.SaveToFile(file, adSaveCreateOverWrite);
            stream.Close();
            stream = null;
        }
    }
}
