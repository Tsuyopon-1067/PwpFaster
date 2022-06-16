using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PowerDevide {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Width = ぱわぽふぁすたー.Properties.Settings.Default.sizex;
            this.Height = ぱわぽふぁすたー.Properties.Settings.Default.sizey;
            SetCtrl();
            lv.Columns.Add("名前");
            lv.Columns.Add("パス");
            pro.Width = 0;
        }

        private void SetCtrl() {
            int w = this.Width - 15;
            int h = this.Height - 30;
            int s = 12;
            int btn_w = (w - 3 * s) / 2;
            int btn_h = 40;

            btn_ex.Width = btn_w;
            btn_del.Width = btn_w;
            btn_ex.Height = btn_h;
            btn_del.Height = btn_h;
            lv.Width = w - s * 2;
            lv.Height = h - (s * 6 + btn_h);
            bar.Width = w;
            bar.Height = s * 2;
            pro.Height = 3;

            lv.Top = s;
            lv.Left = s;
            int btn_top = lv.Height + 2 * s;
            btn_del.Top = btn_top;
            btn_del.Left = s;
            btn_ex.Top = btn_top;
            btn_ex.Left = w - (btn_w + s);
            bar.Top = h - 2 * s - 9;
            bar.Left = 0;
            pro.Top = h - 12;
            pro.Left = 0;
        }

        private void Form1_Resize(object sender, EventArgs e) {
            SetCtrl();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            ListViewItem lvi;
            for (int i = 0; i < files.Length; i++) {
                string ext = Path.GetExtension(Path.GetFileName(files[i]));
                if (ext == ".pptx" || ext == ".pptm" || ext == ".ppt") {
                    lvi = lv.Items.Add(Path.GetFileName(files[i]));
                    lvi.SubItems.Add(files[i]);
                }
            }
            foreach (ColumnHeader ch in lv.Columns) {
                ch.Width = -1;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            // ドラッグされモノがファイル以外は何もしない
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btn_ex_Click(object sender, EventArgs e) {
            int goal = 4 * lv.Items.Count;
            int now = 0;
            foreach (ListViewItem lvi in lv.Items) {
                ProgressSet(1, ++now, goal);//更新1
                string inPas = lvi.SubItems[1].Text;//pptファイルフルパス
                string outPas = lvi.SubItems[1].Text;//pptファイル名フォルダまでのパス(展開で作られる
                int l = outPas.Length;
                int lExt = Path.GetExtension(outPas).Length;
                outPas = outPas.Remove(l - lExt, lExt);//パス長-拡張子長から拡張子長さ分消す
                try {
                    ZipFile.ExtractToDirectory(inPas, outPas);
                }
                catch (Exception Error) { }

                ProgressSet(2, ++now, goal);//更新2
                string ext = "m4a";
                string[] files = Directory.GetFiles(outPas + "/ppt/media", "*.m4a");
                //foreach (string s in files) //MessageBox.Show(s);
                if (files.Length == 0) {
                    files = Directory.GetFiles(outPas + "/ppt/media", "*.mp3");
                    ext = "mp3";
                }
                if (files.Length == 0) {

                    files = Directory.GetFiles(outPas + "/ppt/media", "*.wav");
                    ext = "wav";
                }
                try {
                    foreach (string s in files) {
                        string name = Path.GetFileName(s);
                        File.Move(s, outPas + "/" + name);
                    }
                }
                catch (Exception Error) { }


                ProgressSet(3, ++now, goal);//更新3
                string[] folders = Directory.GetDirectories(outPas);//余分なフォルダ削除
                foreach (string s in folders) Directory.Delete(s, true);
                files = Directory.GetFiles(outPas + "/", "*.xml");
                foreach (string s in files) File.Delete(s);

                lv.Items.Remove(lvi);//リストから削除

                ProgressSet(4, ++now, goal);//更新4
                try {
                    StreamWriter sw = File.CreateText(outPas + ".m3u");

                    sw.WriteLine("#EXTM3U");
                    files = Directory.GetFiles(outPas + "/", "*." + ext);
                    List<(int, string)> fileList = new List<(int, string)>();

                    for (int i = 0; i < files.Length; i++) {
                        string s = Path.GetFileName(files[i]);
                        string ns = s.Remove(s.Length - 4, 4);
                        ns = ns.Remove(0, 5);
                        int n = Int32.Parse(ns);
                        fileList.Add((n, s));
                    }
                    fileList.Sort();

                    string folderName = Path.GetFileName(outPas);
                    for (int i = 0; i < files.Length; i++) {
                        sw.WriteLine(folderName + @"\" + fileList[i].Item2);
                    }
                    sw.Close();
                }
                catch (Exception Error) { }
            }
            ProgressSet(0, 0, 0);//更新0
        }

        private void btn_del_Click(object sender, EventArgs e) {
            Del();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) Del();
        }
        private void Del() {
            foreach (ListViewItem lvi in lv.CheckedItems) {
                lv.Items.Remove(lvi);
            }
        }

      

        private void ProgressSet(int n, int now, int goal) {
            if(n == 0) {
                bar.Text = "PowerPointファイルをドラッグアンドドロップしてください";
                pro.Width = 0;
            }
            else {
                switch (n) {
                    case 1:
                        bar.Text = "展開中";
                        break;
                    case 2:
                        bar.Text = "音声ファイル移動中";
                        break;
                    case 3:
                        bar.Text = "余分なファイルを削除中";
                        break;
                    case 4:
                        bar.Text = "プレイリスト生成中";
                        break;
                }
                bar.Text = bar.Text + " 現在" + (now / 4).ToString() + "/" + (goal / 4).ToString();
                int w = this.Width;
                pro.Width = w / goal * now;
            }
            Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            save();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            save();
        }
        private void save() {
            ぱわぽふぁすたー.Properties.Settings.Default.sizex = this.Width;
            ぱわぽふぁすたー.Properties.Settings.Default.sizey = this.Height;
        }
    }
}
