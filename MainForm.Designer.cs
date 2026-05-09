namespace ModManifestEditor;

partial class MainForm
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
        menuStrip = new MenuStrip();
        fileMenu = new ToolStripMenuItem();
        newMenuItem = new ToolStripMenuItem();
        openMenuItem = new ToolStripMenuItem();
        saveMenuItem = new ToolStripMenuItem();
        saveAsMenuItem = new ToolStripMenuItem();
        exitMenuItem = new ToolStripMenuItem();
        toolStrip = new ToolStrip();
        addButton = new ToolStripButton();
        editButton = new ToolStripButton();
        removeButton = new ToolStripButton();
        separatorButton = new ToolStripSeparator();
        generateUuidButton = new ToolStripButton();
        dataGridView = new DataGridView();
        colName = new DataGridViewTextBoxColumn();
        colUUID = new DataGridViewTextBoxColumn();
        colModNumber = new DataGridViewTextBoxColumn();
        colURL = new DataGridViewTextBoxColumn();
        statusStrip = new StatusStrip();
        statusLabel = new ToolStripStatusLabel();

        menuStrip.SuspendLayout();
        toolStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
        statusStrip.SuspendLayout();
        SuspendLayout();

        // menuStrip
        menuStrip.Items.Add(fileMenu);

        // fileMenu
        fileMenu.Text = "&File";
        fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
            newMenuItem, openMenuItem, new ToolStripSeparator(),
            saveMenuItem, saveAsMenuItem, new ToolStripSeparator(),
            exitMenuItem
        });

        // newMenuItem
        newMenuItem.Text = "&New";
        newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        newMenuItem.Click += NewMenuItem_Click;

        // openMenuItem
        openMenuItem.Text = "&Open...";
        openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        openMenuItem.Click += OpenMenuItem_Click;

        // saveMenuItem
        saveMenuItem.Text = "&Save";
        saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveMenuItem.Click += SaveMenuItem_Click;

        // saveAsMenuItem
        saveAsMenuItem.Text = "Save &As...";
        saveAsMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
        saveAsMenuItem.Click += SaveAsMenuItem_Click;

        // exitMenuItem
        exitMenuItem.Text = "E&xit";
        exitMenuItem.Click += ExitMenuItem_Click;

        // toolStrip
        toolStrip.Items.AddRange(new ToolStripItem[] {
            addButton, editButton, removeButton, separatorButton, generateUuidButton
        });

        // addButton
        addButton.Text = "Add";
        addButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        addButton.Click += AddButton_Click;

        // editButton
        editButton.Text = "Edit";
        editButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        editButton.Click += EditButton_Click;

        // removeButton
        removeButton.Text = "Remove";
        removeButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        removeButton.Click += RemoveButton_Click;

        // generateUuidButton
        generateUuidButton.Text = "Copy New UUID";
        generateUuidButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        generateUuidButton.Click += GenerateUuidButton_Click;

        // dataGridView
        dataGridView.Dock = DockStyle.Fill;
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.ReadOnly = true;
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView.MultiSelect = false;
        dataGridView.AutoGenerateColumns = false;
        dataGridView.RowHeadersVisible = false;
        dataGridView.Columns.AddRange(new DataGridViewColumn[] {
            colName, colUUID, colModNumber, colURL
        });
        dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
        dataGridView.KeyDown += DataGridView_KeyDown;

        // colName
        colName.HeaderText = "Name";
        colName.DataPropertyName = "Name";
        colName.Width = 150;

        // colUUID
        colUUID.HeaderText = "UUID";
        colUUID.DataPropertyName = "UUID";
        colUUID.Width = 280;

        // colModNumber
        colModNumber.HeaderText = "Version";
        colModNumber.DataPropertyName = "ModNumber";
        colModNumber.Width = 80;

        // colURL
        colURL.HeaderText = "URL";
        colURL.DataPropertyName = "URL";
        colURL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        // statusStrip
        statusStrip.Items.Add(statusLabel);

        // statusLabel
        statusLabel.Text = "Ready";

        // MainForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 500);
        Controls.Add(dataGridView);
        Controls.Add(toolStrip);
        Controls.Add(menuStrip);
        Controls.Add(statusStrip);
        MainMenuStrip = menuStrip;
        Text = "Mod Manifest Editor - Untitled";
        FormClosing += MainForm_FormClosing;

        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        toolStrip.ResumeLayout(false);
        toolStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenu;
    private ToolStripMenuItem newMenuItem;
    private ToolStripMenuItem openMenuItem;
    private ToolStripMenuItem saveMenuItem;
    private ToolStripMenuItem saveAsMenuItem;
    private ToolStripMenuItem exitMenuItem;
    private ToolStrip toolStrip;
    private ToolStripButton addButton;
    private ToolStripButton editButton;
    private ToolStripButton removeButton;
    private ToolStripSeparator separatorButton;
    private ToolStripButton generateUuidButton;
    private DataGridView dataGridView;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colUUID;
    private DataGridViewTextBoxColumn colModNumber;
    private DataGridViewTextBoxColumn colURL;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusLabel;
}
