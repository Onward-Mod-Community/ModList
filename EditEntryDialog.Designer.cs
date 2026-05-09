namespace ModManifestEditor;

partial class EditEntryDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblName = new Label();
        lblUUID = new Label();
        lblVersion = new Label();
        lblURL = new Label();
        txtName = new TextBox();
        txtUUID = new TextBox();
        txtVersion = new TextBox();
        txtURL = new TextBox();
        btnGenerateUUID = new Button();
        btnOK = new Button();
        btnCancel = new Button();

        SuspendLayout();

        // lblName
        lblName.Text = "Name:";
        lblName.Location = new Point(12, 20);
        lblName.AutoSize = true;

        // txtName
        txtName.Location = new Point(100, 17);
        txtName.Size = new Size(320, 23);

        // lblUUID
        lblUUID.Text = "UUID:";
        lblUUID.Location = new Point(12, 55);
        lblUUID.AutoSize = true;

        // txtUUID
        txtUUID.Location = new Point(100, 52);
        txtUUID.Size = new Size(320, 23);

        // btnGenerateUUID
        btnGenerateUUID.Text = "Generate";
        btnGenerateUUID.Location = new Point(426, 51);
        btnGenerateUUID.Size = new Size(80, 25);
        btnGenerateUUID.Click += BtnGenerateUUID_Click;

        // lblVersion
        lblVersion.Text = "Version:";
        lblVersion.Location = new Point(12, 90);
        lblVersion.AutoSize = true;

        // txtVersion
        txtVersion.Location = new Point(100, 87);
        txtVersion.Size = new Size(320, 23);

        // lblURL
        lblURL.Text = "URL:";
        lblURL.Location = new Point(12, 125);
        lblURL.AutoSize = true;

        // txtURL
        txtURL.Location = new Point(100, 122);
        txtURL.Size = new Size(320, 23);

        // btnOK
        btnOK.Text = "OK";
        btnOK.Location = new Point(264, 165);
        btnOK.Size = new Size(75, 28);
        btnOK.Click += BtnOK_Click;

        // btnCancel
        btnCancel.Text = "Cancel";
        btnCancel.Location = new Point(345, 165);
        btnCancel.Size = new Size(75, 28);
        btnCancel.DialogResult = DialogResult.Cancel;

        // EditEntryDialog
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 210);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mod Entry";
        AcceptButton = btnOK;
        CancelButton = btnCancel;

        Controls.AddRange(new Control[] {
            lblName, txtName,
            lblUUID, txtUUID, btnGenerateUUID,
            lblVersion, txtVersion,
            lblURL, txtURL,
            btnOK, btnCancel
        });

        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblName;
    private Label lblUUID;
    private Label lblVersion;
    private Label lblURL;
    private TextBox txtName;
    private TextBox txtUUID;
    private TextBox txtVersion;
    private TextBox txtURL;
    private Button btnGenerateUUID;
    private Button btnOK;
    private Button btnCancel;
}
