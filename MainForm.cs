using System.ComponentModel;
using System.Text.Json;

namespace ModManifestEditor;

public partial class MainForm : Form
{
    private BindingList<ModEntry> _bindingList = new();
    private string? _currentFilePath;
    private bool _isDirty;

    private static readonly string DefaultFilePath =
        Path.Combine(Application.StartupPath, "onward_forever_mod_list.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = null
    };

    public MainForm()
    {
        InitializeComponent();
        dataGridView.DataSource = _bindingList;
        _bindingList.ListChanged += (_, _) => MarkDirty();
        LoadDefaultFile();
    }

    private void LoadDefaultFile()
    {
        _currentFilePath = DefaultFilePath;

        if (File.Exists(DefaultFilePath))
        {
            try
            {
                var json = File.ReadAllText(DefaultFilePath);
                var entries = JsonSerializer.Deserialize<List<ModEntry>>(json, JsonOptions);
                if (entries != null)
                {
                    _bindingList.RaiseListChangedEvents = false;
                    foreach (var entry in entries)
                        _bindingList.Add(entry);
                    _bindingList.RaiseListChangedEvents = true;
                    _bindingList.ResetBindings();
                }
            }
            catch { }
        }

        _isDirty = false;
        UpdateTitle();
        UpdateStatus();
    }

    private void MarkDirty()
    {
        if (!_isDirty)
        {
            _isDirty = true;
            UpdateTitle();
        }
    }

    private void UpdateTitle()
    {
        var fileName = _currentFilePath != null ? Path.GetFileName(_currentFilePath) : "Untitled";
        var dirty = _isDirty ? " *" : "";
        Text = $"Mod Manifest Editor - {fileName}{dirty}";
    }

    private void UpdateStatus()
    {
        var fileInfo = _currentFilePath ?? "No file";
        statusLabel.Text = $"{fileInfo} | {_bindingList.Count} entries";
    }

    private bool PromptSaveIfDirty()
    {
        if (!_isDirty) return true;

        var result = MessageBox.Show(
            "You have unsaved changes. Save before continuing?",
            "Unsaved Changes",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Warning);

        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) return Save();
        return true;
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        if (!PromptSaveIfDirty()) return;

        _bindingList.Clear();
        _currentFilePath = null;
        _isDirty = false;
        UpdateTitle();
        UpdateStatus();
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        if (!PromptSaveIfDirty()) return;

        using var dialog = new OpenFileDialog
        {
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            Title = "Open Mod Manifest",
            InitialDirectory = Application.StartupPath
        };

        if (dialog.ShowDialog() != DialogResult.OK) return;

        try
        {
            var json = File.ReadAllText(dialog.FileName);
            var entries = JsonSerializer.Deserialize<List<ModEntry>>(json, JsonOptions);

            if (entries == null)
            {
                MessageBox.Show("File contains null or invalid data.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bindingList.RaiseListChangedEvents = false;
            _bindingList.Clear();
            foreach (var entry in entries)
                _bindingList.Add(entry);
            _bindingList.RaiseListChangedEvents = true;
            _bindingList.ResetBindings();

            _currentFilePath = dialog.FileName;
            _isDirty = false;
            UpdateTitle();
            UpdateStatus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open file:\n{ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e) => Save();

    private bool Save()
    {
        if (_currentFilePath == null) return SaveAs();
        return WriteFile(_currentFilePath);
    }

    private void SaveAsMenuItem_Click(object? sender, EventArgs e) => SaveAs();

    private bool SaveAs()
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            Title = "Save Mod Manifest As",
            DefaultExt = "json"
        };

        if (dialog.ShowDialog() != DialogResult.OK) return false;

        if (!WriteFile(dialog.FileName)) return false;
        _currentFilePath = dialog.FileName;
        UpdateTitle();
        UpdateStatus();
        return true;
    }

    private bool WriteFile(string path)
    {
        try
        {
            var entries = _bindingList.ToList();
            var json = JsonSerializer.Serialize(entries, JsonOptions);
            File.WriteAllText(path, json);
            _isDirty = false;
            UpdateTitle();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to save file:\n{ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e) => Close();

    private void AddButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new EditEntryDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _bindingList.Add(dialog.GetEntry());
            UpdateStatus();
        }
    }

    private void EditButton_Click(object? sender, EventArgs e) => EditSelectedEntry();

    private void EditSelectedEntry()
    {
        if (dataGridView.CurrentRow == null) return;

        var index = dataGridView.CurrentRow.Index;
        var entry = _bindingList[index];

        using var dialog = new EditEntryDialog(entry);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var updated = dialog.GetEntry();
            _bindingList[index] = updated;
        }
    }

    private void RemoveButton_Click(object? sender, EventArgs e)
    {
        if (dataGridView.CurrentRow == null) return;

        var entry = _bindingList[dataGridView.CurrentRow.Index];
        var result = MessageBox.Show(
            $"Remove \"{entry.Name}\"?",
            "Confirm Remove",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _bindingList.RemoveAt(dataGridView.CurrentRow.Index);
            UpdateStatus();
        }
    }

    private void GenerateUuidButton_Click(object? sender, EventArgs e)
    {
        var uuid = Guid.NewGuid().ToString();
        Clipboard.SetText(uuid);
        statusLabel.Text = $"Copied UUID to clipboard: {uuid}";
    }

    private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) EditSelectedEntry();
    }

    private void DataGridView_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete) RemoveButton_Click(sender, e);
        if (e.KeyCode == Keys.Enter) { EditSelectedEntry(); e.Handled = true; }
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!PromptSaveIfDirty()) e.Cancel = true;
    }
}
