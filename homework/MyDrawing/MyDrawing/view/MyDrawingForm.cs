using Microsoft.CSharp.RuntimeBinder;
using MyDrawing.model.command;
using MyDrawing.view;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawing
{
    public partial class MyDrawingForm : Form
    {
        private readonly List<Button> buttonList = new List<Button>();
        private readonly Model model;
        private readonly PresentationModel presentationModel;
        private readonly AutoSaveTimer autoSaveTimer;

        public MyDrawingForm(PresentationModel presentationModel, Model model)
        {
            this.model = model;
            this.presentationModel = presentationModel;
            this.autoSaveTimer = new AutoSaveTimer(model);
            
            InitializeComponent();
            CreateButtonList(2);
            addDrawingButton.DataBindings.Add("Enabled", presentationModel, "isAddDrawingButtonEnabled");
            model.ModelChanged += UpdateDisplayDrawingDataGridView;
            model.ModelChanged += UpdateDrawAreaPanelView;
            presentationModel.PresentationModeTextDialogChanged += UpdateTextDialogStatus;
            presentationModel.PresentationModelDrawAreaChanged += UpdateDrawAreaPanelView;
            presentationModel.PresentationModelToolStripChanged += UpdateCursorStatus;
            presentationModel.PresentationModelToolStripChanged += UpdateToolStripButtonStatus;
            presentationModel.PresentationModelShapeLegalChanged += UpdateLabelStatus;
            presentationModel.PresentationModeTextPositionChanged += UpdateTextPositionStatus;
            CommandManager.Instance.CommandManagerChanged += UpdateUndoRedoStatus;
            FileHandler.Instance.FileHandlerSaveErrorChanged += UpdateSaveStatus;
            FileHandler.Instance.FileHandlerLoadErrorChanged += UpdateLoadStatus;
            autoSaveTimer.AutoSaveStarted += UpdateFormAutoSavingTitle;
            autoSaveTimer.AutoSaveFinished += UpdateFormNormalTitle;
            UpdateToolStripButtonStatus();
            UpdateLabelStatus();
        }

        private void CreateButtonList(int numberOfButtons)
        {
            for (int i = 0; i < numberOfButtons; i++)
            {
                Button button = new Button();
                button.Location = new System.Drawing.Point(7, 5 + (i * 75));
                button.Size = new System.Drawing.Size(120, 70);
                button.BackColor = Color.White;
                buttonList.Add(button);
                pageSelectionPanel.Controls.Add(button);
            }
        }

        private void UpdateToolStripButtonStatus()
        {
            startButton.Checked = presentationModel.IsStartChecked;
            terminatorButton.Checked = presentationModel.IsTerminatorChecked;
            decisionButton.Checked = presentationModel.IsDecisionChecked;
            processButton.Checked = presentationModel.IsProcessChecked;
            pointerButton.Checked = presentationModel.IsPointerChecked;
            lineButton.Checked = presentationModel.IsLineChecked;
        }

        private void UpdateCursorStatus()
        {
            Cursor = presentationModel.IsPointerChecked ? Cursors.Default : Cursors.Cross;
        }

        private void UpdateLabelStatus()
        {
            shapeLabel.ForeColor = presentationModel.IsShapeTypeLegal ? Color.Black : Color.Red;
            noteLabel.ForeColor = presentationModel.IsShapeNoteLegal ? Color.Black : Color.Red;
            xLabel.ForeColor = presentationModel.IsShapeXLegal ? Color.Black : Color.Red;
            yLabel.ForeColor = presentationModel.IsShapeYLegal ? Color.Black : Color.Red;
            hLabel.ForeColor = presentationModel.IsShapeHeightLegal ? Color.Black : Color.Red;
            wLabel.ForeColor = presentationModel.IsShapeWidthLegal ? Color.Black : Color.Red;
        }

        private void UpdateUndoRedoStatus()
        {
            undoButton.Enabled = CommandManager.Instance.IsUndoEnabled;
            redoButton.Enabled = CommandManager.Instance.IsRedoEnabled;
        }
        private void UpdateSaveStatus()
        {
            MessageBox.Show("Save Error");
        }

        private void UpdateLoadStatus()
        {
            MessageBox.Show("Load Error");
        }

        private void UpdateDrawAreaPanelView()
        {
            drawAreaPanel.Invalidate();
        }

        private void UpdateDisplayDrawingDataGridView()
        {
            displayDrawingDataGridView.Rows.Clear();

            Button button = new Button { Text = "刪除" };

            foreach (var shape in model.Shapes)
            {
                displayDrawingDataGridView.Rows.Add(
                    button,
                    shape.Id.ToString(),
                    shape.GetShapeType(),
                    shape.Note,
                    shape.X.ToString(),
                    shape.Y.ToString(),
                    shape.Height.ToString(),
                    shape.Width.ToString()
                );
            }
        }
        private void UpdateTextDialogStatus()
        {
            ChangeTextForm changeTextForm = new ChangeTextForm(presentationModel);
            changeTextForm.ShowDialog();
        }

        private void UpdateFormAutoSavingTitle()
        {
            this.Invoke(new Action(() => this.Text = "MyDrawing (Auto Saving...)"));
            this.Invoke(new Action(() => this.formLabel.Text = "MyDrawing (Auto Saving...)"));
        }

        private void UpdateFormNormalTitle()
        {
            this.Invoke(new Action(() => this.Text = "MyDrawing"));
            this.Invoke(new Action(() => this.formLabel.Text = "MyDrawing"));
        }
        private void UpdateTextPositionStatus()
        {
            this.Invoke(new Action(() => this.textPositionLabel.Text = presentationModel.textPosition.ToString()));
        }

        private void AddDrawingButton_Click(object sender, EventArgs e)
        {
            model.AddShape(model.CreateShape(shapeComboBox.Text, noteTextBox.Text, xTextBox.Text, yTextBox.Text, heightTextBox.Text, widthTextBox.Text));
        }

        private void DisplayDrawingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (displayDrawingDataGridView.Columns[e.ColumnIndex].Name == "deleteButton" && e.RowIndex >= 0)
            {
                model.DeleteShapeByIndex(e.RowIndex);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            presentationModel.ToolStripButtonClick("Start");
        }

        private void TerminatorButton_Click(object sender, EventArgs e)
        {
            presentationModel.ToolStripButtonClick("Terminator");
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            presentationModel.ToolStripButtonClick("Process");
        }

        private void DecisionButton_Click(object sender, EventArgs e)
        {
            presentationModel.ToolStripButtonClick("Decision");
        }

        private void PointerButton_Click(object sender, EventArgs e)
        {
            presentationModel.ToolStripButtonClick("Pointer");
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            presentationModel.ToolStripButtonClick("Line");
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            CommandManager.Instance.Undo();
            model.NotifyObserver();
        }


        private void RedoButton_Click(object sender, EventArgs e)
        {
            CommandManager.Instance.Redo();
            model.NotifyObserver();
        }

        private void DrawAreaPanel_MouseEnter(object sender, EventArgs e)
        {
            Cursor = presentationModel.IsPointerChecked ? Cursors.Default : Cursors.Cross;
        }

        private void DrawAreaPanel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void DrawAreaPanel_MouseDown(object sender, MouseEventArgs e)
        {
            presentationModel.DrawAreaMouseDown(e.Location.X, e.Location.Y);
        }

        private void DrawAreaPanel_MouseUp(object sender, MouseEventArgs e)
        {
            presentationModel.DrawAreaMouseUp(e.Location.X, e.Location.Y);
        }

        private void DrawAreaPanel_MouseMove(object sender, MouseEventArgs e)
        {
            presentationModel.DrawAreaMouseMove(e.Location.X, e.Location.Y);
        }

        private void DrawAreaPanel_Paint(object sender, PaintEventArgs e)
        {
            presentationModel.Draw(new FormGraphicAdapter(e.Graphics));
        }

        private void ShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentationModel.SetShapeType(shapeComboBox.SelectedIndex);
        }

        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {
            presentationModel.SetShapeNote(noteTextBox.Text);
        }

        private void XTextBox_TextChanged(object sender, EventArgs e)
        {
            presentationModel.SetShapeX(xTextBox.Text);
        }

        private void YTextBox_TextChanged(object sender, EventArgs e)
        {
            presentationModel.SetShapeY(yTextBox.Text);
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            presentationModel.SetShapeHeight(heightTextBox.Text);
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            presentationModel.SetShapeWidth(widthTextBox.Text);
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "另存新檔",
                Filter = "Mydrawing (*.mydrawing)|*.mydrawing",
                DefaultExt = "mydrawing",
                AddExtension = true,
                FileName = "file"
            };
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveButton.Enabled = false;
                await FileHandler.Instance.Save(saveFileDialog.FileName, model.GetShapesOutput());
                //} catch (Exception e){
                //    Console.WriteLine(e.Data);
                //}
                
                Console.WriteLine(saveFileDialog.FileName);
                saveButton.Enabled = true;
            }
        }
        
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "另存新檔",
                Filter = "Mydrawing (*.mydrawing)|*.mydrawing",
                DefaultExt = "mydrawing",
                AddExtension = true,
                FileName = "file"
            };     
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileHandler.Instance.Load(model, openFileDialog.FileName);
            }
        }
    }
}

