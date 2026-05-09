using System.Text.RegularExpressions;

namespace ModManifestEditor;

public partial class EditEntryDialog : Form
{
    public EditEntryDialog()
    {
        InitializeComponent();
        Text = "Add Mod Entry";
    }

    public EditEntryDialog(ModEntry entry) : this()
    {
        Text = "Edit Mod Entry";
        txtName.Text = entry.Name;
        txtUUID.Text = entry.UUID;
        txtVersion.Text = entry.ModNumber;
        txtURL.Text = entry.URL;
    }

    public ModEntry GetEntry() => new()
    {
        Name = txtName.Text.Trim(),
        UUID = txtUUID.Text.Trim(),
        ModNumber = txtVersion.Text.Trim(),
        URL = txtURL.Text.Trim()
    };

    private void BtnGenerateUUID_Click(object? sender, EventArgs e)
    {
        txtUUID.Text = Guid.NewGuid().ToString();
    }

    private void BtnOK_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            ShowError("Name is required.");
            txtName.Focus();
            return;
        }

        if (!Guid.TryParse(txtUUID.Text.Trim(), out _))
        {
            ShowError("UUID must be a valid GUID.\nClick 'Generate' to create one.");
            txtUUID.Focus();
            return;
        }

        if (!Regex.IsMatch(txtVersion.Text.Trim(), @"^\d+\.\d+\.\d+$"))
        {
            ShowError("Version must be in format X.Y.Z (e.g., 1.0.0).");
            txtVersion.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtURL.Text))
        {
            ShowError("URL is required.");
            txtURL.Focus();
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private static void ShowError(string message)
    {
        MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
