namespace MsiPropertiesReader
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnLoadMsiFile = new System.Windows.Forms.Button();
            this.dtGrvProperties = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbBxPropertyNames = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrvProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadMsiFile
            // 
            resources.ApplyResources(this.btnLoadMsiFile, "btnLoadMsiFile");
            this.btnLoadMsiFile.Name = "btnLoadMsiFile";
            this.btnLoadMsiFile.UseVisualStyleBackColor = true;
            this.btnLoadMsiFile.Click += new System.EventHandler(this.BtnLoadMsiFile_Click);
            // 
            // dtGrvProperties
            // 
            this.dtGrvProperties.AllowUserToAddRows = false;
            this.dtGrvProperties.AllowUserToDeleteRows = false;
            this.dtGrvProperties.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dtGrvProperties, "dtGrvProperties");
            this.dtGrvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrvProperties.Name = "dtGrvProperties";
            this.dtGrvProperties.ReadOnly = true;
            this.dtGrvProperties.RowHeadersVisible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbBxPropertyNames
            // 
            resources.ApplyResources(this.cmbBxPropertyNames, "cmbBxPropertyNames");
            this.cmbBxPropertyNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxPropertyNames.FormattingEnabled = true;
            this.cmbBxPropertyNames.Name = "cmbBxPropertyNames";
            this.cmbBxPropertyNames.Sorted = true;
            this.cmbBxPropertyNames.SelectedIndexChanged += new System.EventHandler(this.CmbBxPropertyNames_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbBxPropertyNames);
            this.Controls.Add(this.dtGrvProperties);
            this.Controls.Add(this.btnLoadMsiFile);
            this.Name = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dtGrvProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMsiFile;
        private System.Windows.Forms.DataGridView dtGrvProperties;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbBxPropertyNames;
    }
}

