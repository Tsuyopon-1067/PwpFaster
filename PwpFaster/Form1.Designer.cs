namespace PowerDevide {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lv = new System.Windows.Forms.ListView();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_ex = new System.Windows.Forms.Button();
            this.bar = new System.Windows.Forms.Label();
            this.pro = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pro)).BeginInit();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.AllowDrop = true;
            this.lv.CheckBoxes = true;
            this.lv.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(12, 12);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(776, 366);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.lv.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("游ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.Location = new System.Drawing.Point(12, 397);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(360, 40);
            this.btn_del.TabIndex = 1;
            this.btn_del.Text = "リストから削除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_ex
            // 
            this.btn_ex.Font = new System.Drawing.Font("游ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ex.Location = new System.Drawing.Point(416, 397);
            this.btn_ex.Name = "btn_ex";
            this.btn_ex.Size = new System.Drawing.Size(360, 40);
            this.btn_ex.TabIndex = 2;
            this.btn_ex.Text = "実行";
            this.btn_ex.UseVisualStyleBackColor = true;
            this.btn_ex.Click += new System.EventHandler(this.btn_ex_Click);
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bar.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bar.ForeColor = System.Drawing.Color.White;
            this.bar.Location = new System.Drawing.Point(8, 354);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(799, 24);
            this.bar.TabIndex = 3;
            this.bar.Text = "PowerPointファイルをドラッグアンドドロップしてください";
            // 
            // pro
            // 
            this.pro.BackColor = System.Drawing.Color.White;
            this.pro.Location = new System.Drawing.Point(7, 389);
            this.pro.Name = "pro";
            this.pro.Size = new System.Drawing.Size(800, 5);
            this.pro.TabIndex = 4;
            this.pro.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.pro);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.btn_ex);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.lv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ぱわぽふぁすたー";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_ex;
        private System.Windows.Forms.Label bar;
        private System.Windows.Forms.PictureBox pro;
    }
}

