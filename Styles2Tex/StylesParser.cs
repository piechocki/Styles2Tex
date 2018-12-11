using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Styles2Tex
{
    class StylesParser
    {
        readonly Enum[] supported_styles = {
            WdBuiltinStyle.wdStyleTitle,
            WdBuiltinStyle.wdStyleNormal,
            WdBuiltinStyle.wdStyleHeading1,
            WdBuiltinStyle.wdStyleHeading2,
            WdBuiltinStyle.wdStyleHeading3,
            WdBuiltinStyle.wdStyleListParagraph
        };

        public void Convert_Styles(Microsoft.Office.Interop.Word.Application word, Dictionary<string, string> config)
        {
            StringBuilder txt;
            string path;
            string para;
            string file = "";
            Range para_range;
            Document doc = word.ActiveDocument;
            DateTime begin = DateTime.Now;
            Dictionary<Enum, string> local_names = Get_Local_Names(doc);

            if (config["save_directory"] == "")
            {
                MessageBox.Show("Settings missing: Please set the save directory first.", "Styles2Tex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (config["encoding"] == "")
            {
                MessageBox.Show("Settings missing: Please set the encoding first.", "Styles2Tex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                path = config["save_directory"];
            }
                        
            StringBuilder file_txt = new StringBuilder();            
            string status;
            string para_style;
            int para_count = doc.Paragraphs.Count;
            int not_builtin = 0;
            int not_supported = 0;
            int sec_number = 0;
            int written_files = 0;
            DateTime status_refreshed = DateTime.MinValue;

            for (int i = 1; i <= para_count; i++)
            {
                status = string.Format("Processing paragraph {0} of {1}", i, para_count);
                if (status_refreshed == DateTime.MinValue || status_refreshed.Second < DateTime.Now.Second)
                {
                    word.StatusBar = status;
                    status_refreshed = DateTime.Now;
                }

                para_range = doc.Paragraphs[i].Range;
                para = Text_Format(para_range.Text);
                para_style = doc.Paragraphs[i].get_Style().NameLocal;
                txt = new StringBuilder();

                if (!doc.Paragraphs[i].get_Style().BuiltIn)
                {
                    not_builtin += 1;
                    continue;
                }
                //else if (doc.Paragraphs[i].get_Style().Type != WdStyleType.wdStyleTypeCharacter)
                //{
                //    // fehler
                //}

                if (para_style == local_names[WdBuiltinStyle.wdStyleHeading1])
                {
                    if (file_txt.Length != 0)
                    {
                        // Save the previous file_txt if it's not empty
                        written_files += Save_File(file, file_txt.ToString(), Convert.ToBoolean(config["overwrite"]), config["encoding"]) ? 1 : 0;
                        // Clean the file_text variable for the next section
                        file_txt = new StringBuilder();
                        sec_number += 1;
                    }

                    if (sec_number == 0 && Convert.ToBoolean(config["abstract"]))
                    {
                        // Exception for first file (abstract)
                        file = Path.Combine(path, "abstract.tex");
                        txt.AppendLine("\\section*{\\centering{" + para + "}}");
                    }
                    else
                    {
                        if (sec_number == 0)
                        {
                            // Increment sec number if abstract option is set to false and it's the first section
                            sec_number += 1;
                        }
                        // All other files will be saved with its section number
                        file = Path.Combine(path, config["naming"].Replace("$", Convert.ToString(sec_number)) + ".tex");
                        txt.Append("\\section{" + para + "}").AppendLine(Get_Label(para, config));
                    }
                }
                else if (para_style == local_names[WdBuiltinStyle.wdStyleHeading2])
                {
                    txt.Append("\\subsection{" + para + "}").AppendLine(Get_Label(para, config));
                }
                else if (para_style == local_names[WdBuiltinStyle.wdStyleHeading3])
                {
                    txt.Append("\\subsubsection{" + para + "}").AppendLine(Get_Label(para, config));
                }
                else if (para_style == local_names[WdBuiltinStyle.wdStyleNormal])
                {
                    if (Convert.ToBoolean(config["emphasize"]))
                    {
                        para = Get_Italic_Format(para_range);
                    }

                    // Check if carriage return characters after the paragraph are required
                    if (i < doc.Paragraphs.Count &&
                        doc.Paragraphs[i + 1].get_Style().NameLocal == local_names[WdBuiltinStyle.wdStyleNormal] &&
                        No_Equation(doc, i) &&
                        !doc.Paragraphs[i + 1].Range.Text.StartsWith("\\input{") &&
                        !doc.Paragraphs[i + 1].Range.Text.StartsWith("\\begin{"))
                    {
                        txt.Append(para).AppendLine("\\\\");
                    }
                    else
                    {
                        txt.AppendLine(para);
                    }
                }
                else if (para_style == local_names[WdBuiltinStyle.wdStyleTitle])
                {

                }
                else if (para_style == local_names[WdBuiltinStyle.wdStyleListParagraph] &&
                         (para_range.ListFormat.ListType == WdListType.wdListSimpleNumbering || para_range.ListFormat.ListType == WdListType.wdListBullet))
                {
                    if (i == 1 || doc.Paragraphs[i - 1].get_Style().NameLocal != local_names[WdBuiltinStyle.wdStyleListParagraph])
                    {
                        // If it's the first item in itemize, first add an opening bracket
                        txt.AppendLine("\\begin{" + ((para_range.ListFormat.ListType == WdListType.wdListSimpleNumbering) ? "enumerate" : "itemize") + "}");
                    }
                    // Add the item
                    txt.AppendLine("  \\item " + Text_Format(para_range.ListParagraphs[1].Range.Text));

                    if ((i == 1 || doc.Paragraphs[i - 1].get_Style().NameLocal == local_names[WdBuiltinStyle.wdStyleListParagraph]) &&
                        (i == para_count || doc.Paragraphs[i + 1].get_Style().NameLocal != local_names[WdBuiltinStyle.wdStyleListParagraph]))
                    {
                        // If it's the last item in itemize, finally close the bracket
                        txt.AppendLine("\\end{" + ((para_range.ListFormat.ListType == WdListType.wdListSimpleNumbering) ? "enumerate" : "itemize") + "}");
                    }
                }
                else
                {
                    not_supported += 1;
                    continue;
                }

                if (txt.Length != 0)
                {
                    file_txt.Append(txt.ToString());                     
                }
            }

            // Save the last file_txt if the parsing of the word is finished
            written_files += Save_File(file, file_txt.ToString(), Convert.ToBoolean(config["overwrite"]), config["encoding"]) ? 1 : 0;

            StringBuilder final_status = new StringBuilder("Document processed successfully.");
            final_status.AppendFormat(" {0} tex files has been written.", written_files);
            final_status.AppendFormat(" {0} paragraphs were skipped ({1} non built-in styles, {2} built-in but not supported styles).", not_builtin + not_supported, not_builtin, not_supported);
            final_status.AppendFormat(" Runtime: {0} seconds", Convert.ToString((DateTime.Now - begin).Seconds));
            word.StatusBar = final_status.ToString();
            Thread.Sleep(5000);
            word.StatusBar = "";
        }

        private string Get_Label(string para, Dictionary<string, string> config)
        {
            if (Convert.ToBoolean(config["labels"]))
            {
                return " \\label{" + Label_Format(para) + "}";
            }
            else
            {
                return "";
            }
        }

        private string Get_Italic_Format(Range para_range)
        {
            StringBuilder para = new StringBuilder();
            StringBuilder chars_italic = new StringBuilder();
            StringBuilder chars_non_italic = new StringBuilder();

            foreach (Range w in para_range.Words)
            {
                if (w.Font.Italic != 0)
                {
                    if (chars_non_italic.Length != 0)
                    {
                        para.Append(chars_non_italic.ToString());
                        chars_non_italic = new StringBuilder();
                    }
                    chars_italic.Append(w.Text.Replace("\r", ""));
                }
                else
                {
                    if (chars_italic.Length != 0)
                    {
                        para.Append("\\emph{").Append(chars_italic.ToString()).Append("}");
                        chars_italic = new StringBuilder();
                    }
                    chars_non_italic.Append(w.Text.Replace("\r", ""));
                }
            }

            if (chars_italic.Length != 0)
            {
                para.Append("\\emph{").Append(chars_italic.ToString()).Append("}");
            }
            para.Append(chars_non_italic.ToString());

            return para.ToString();
        }

        public Dictionary<Enum, string> Get_Local_Names(Document doc)
        {
            Dictionary<Enum, string> local_names = new Dictionary<Enum, string>();
            foreach (Enum supported_style in supported_styles)
            {
                local_names.Add(supported_style, doc.Styles[supported_style].NameLocal);
            }
            return local_names;
        }

        private bool No_Equation(Document doc, int i)
        {
            bool ne = true;

            for (int j = i; j >= i - 3; j -= 1)
            {
                if (j == 0)
                {
                    break;
                }                
                else if (doc.Paragraphs[j].Range.Text.StartsWith("\\begin{equation}"))
                {
                    ne = false;
                }                    
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

        private bool Save_File(string file, string file_txt, bool overwrite, string encoding)
        {            
            if (!File.Exists(file) || overwrite)
            {
                try
                {
                    if (file == "")
                    {
                        throw new Exception("For each section a top level heading ('Heading 1') is mandatory.");
                    }

                    using (StreamWriter sw = new StreamWriter(File.Open(file, FileMode.Create), Encoding.GetEncoding(encoding)))
                    {
                        sw.Write(file_txt);
                    }
                    return true;
                }
                catch(Exception e)
                {
                    MessageBox.Show(string.Format("At least one tex file could not be saved.\r\rError: {0}", e.Message), "Styles2Tex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return false;
        }
    }
}
