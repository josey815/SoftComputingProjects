using Steema.TeeChart;
using Steema.TeeChart.Editors.Series;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Legend = System.Windows.Forms.DataVisualization.Charting.Legend;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace R10546040FuzzySetNamespace
{
    public partial class MyForm : Form
    {
        FuzzySet[] FSCollection = new FuzzySet[2];

        public MyForm()
        {
            InitializeComponent();
            this.EquationPage.Parent = null;
            this.FuzzySetPage.Parent = this.tabControl;
            this.RulesPage.Parent = this.tabControl;
            //this.EquationPage.Hide();
            FuzzySystemChanged(null, null);

            splitContainer7.Visible = false;
            chtTsukamotoOutput.Visible = false;
        }

        private void trvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selected = trvMain.SelectedNode;

            if (selected.Level == 0)
            {
                btnAddUniverse.Enabled = true;
                if (selected.Index == 0)
                {
                    btnAddUniverse.Text = "Add An Input Universe";
                }
                else
                {
                    btnAddUniverse.Text = "Add An Output Universe";
                    if (selected.Nodes.Count == 1)
                    {
                        btnAddUniverse.Enabled = false;
                    }
                    else
                    {
                        btnAddUniverse.Enabled = true;
                    }
                }
            }
            else
            {
                btnAddUniverse.Enabled = false;
            }

            prgMain.SelectedObject = trvMain.SelectedNode.Tag;
        }

        private void btnAddUniverse_Click(object sender, EventArgs e)
        {
            // Universe layout arrangement
            Universe aUniv = new Universe();
            if (trvMain.SelectedNode.Index == 0)
            {
                chtMainChart.ChartAreas.Insert(0, aUniv.TheArea);
                chtMainChart.Legends.Insert(0, aUniv.TheLegend);
                trvMain.SelectedNode.Nodes.Insert(0, aUniv.TheNode);
            }
            else
            {
                btnAddUniverse.Enabled = false;
                chtMainChart.ChartAreas.Add(aUniv.TheArea);
                chtMainChart.Legends.Add(aUniv.TheLegend);
                trvMain.SelectedNode.Nodes.Add(aUniv.TheNode);
                aUniv.TheArea.BackColor = Color.LightSkyBlue;
            }

            trvMain.ExpandAll();
            trvMain.Focus();

            // DataGridView layout arrangement
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = aUniv.Title;
            col.Tag = aUniv;

            if (dgvRules.Columns.Count < 1)
            {
                dgvRules.Columns.Add(col);
            }
            else
            {
                if (trvMain.SelectedNode.Index == 0)
                {
                    dgvRules.Columns.Insert(0, col);
                }
                else
                {
                    dgvRules.Columns.Add(col);
                }

            }

            if (trvMain.SelectedNode.Index == 0) // for input universe
            {
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = aUniv.Title;
                col1.Tag = aUniv;
                dgvConditions.Columns.Insert(0, col1);
            }
            else
            {
                //col.HeaderCell.Style.BackColor = Color.Maroon;
                //col.HeaderCell.Style.ForeColor = Color.Gold;
                col.DefaultCellStyle.BackColor = Color.Maroon;
                col.DefaultCellStyle.ForeColor = Color.Gold;
            }
        }

        private void btnAddFuzzySet_Click(object sender, EventArgs e)
        {
            // make sure selectedNode is not null and the node is in universe level
            if (trvMain.SelectedNode != null)
            {
                if (trvMain.SelectedNode.Level == 1)
                {
                    Universe theU = (Universe)trvMain.SelectedNode.Tag;
                    FuzzySet fs = null;
                    switch (cbxFuzzySetList.SelectedIndex)
                    {
                        case 0: // TriangularFuzzySet
                            fs = new TriangularFuzzySet(theU);
                            break;
                        case 1: // TrapezoidalFuzzySet
                            fs = new TrapezoidalFuzzySet(theU);
                            break;
                        case 2: // GaussianFuzzySet
                            fs = new GaussianFuzzySet(theU);
                            break;
                        case 3: // BellFuzzySet
                            fs = new BellFuzzySet(theU);
                            break;
                        case 4: // SigmoidalFuzzySet
                            fs = new SigmoidalFuzzySet(theU);
                            break;
                        case 5: // Left-RightFuzzySet
                            fs = new LeftRightFuzzySet(theU);
                            break;
                        case 6: // SFuzzySet
                            fs = new SFuzzySet(theU);
                            break;
                        case 7: // ZFuzzySet
                            fs = new ZFuzzySet(theU);
                            break;
                        case 8: // pi FuzzySet
                            fs = new PiFuzzySet(theU);
                            break;
                        case 9: // two-side pi FuzzySet
                            fs = new twoSidePiFuzzySet(theU);
                            break;
                        case 10: // Step-up FuzzySet
                            fs = new StepUpFuzzySet(theU);
                            break;
                        case 11: // Step-down FuzzySet
                            fs = new StepDownFuzzySet(theU);
                            break;
                    }

                    fs.VisualDisplay = true;

                    //TreeNode node = new TreeNode();
                    //fs.UpdateSeries();
                    //node.Tag = fs;
                    //fs.TheNode = node;

                    //trvMain.SelectedNode.Nodes.Add(fs.TheNode);
                    chtMainChart.Series.Add(fs.TheSeries);
                    trvMain.ExpandAll();
                    trvMain.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (trvMain.SelectedNode != null) // make sure we have selected something to delete
            {
                if (trvMain.SelectedNode.Level == 1) // delete Universe
                {
                    Universe Uni_de = (Universe)trvMain.SelectedNode.Tag;
                    chtMainChart.ChartAreas.Remove(Uni_de.TheArea);
                    chtMainChart.Legends.Remove(Uni_de.TheLegend);

                    if (trvMain.SelectedNode.Parent.Index == 0)
                    {
                        dgvRules.Columns.RemoveAt(trvMain.SelectedNode.Index);
                        dgvConditions.Columns.RemoveAt(trvMain.SelectedNode.Index);
                    }
                    else
                    {
                        dgvRules.Columns.RemoveAt(dgvRules.Columns.Count - 1);
                    }

                    trvMain.SelectedNode.Remove();

                    // Be careful when all the universes are deleted, we should also erase all the series.
                    // Otherwise, when we try to add a new universe again, it will draw all the series that you had created before
                    // ,which is weird and not what we want.
                    if (chtMainChart.ChartAreas.Count == 0)
                    {
                        chtMainChart.Series.Clear();
                    }
                }
                else if (trvMain.SelectedNode.Level == 2) // delete FuzzySet
                {
                    FuzzySet FS_de = (FuzzySet)trvMain.SelectedNode.Tag;
                    chtMainChart.Series.Remove(FS_de.TheSeries);
                    trvMain.SelectedNode.Remove();
                }
            }
        }

        private void btnAddUnaryOperatedFS_Click(object sender, EventArgs e)
        {
            if (trvMain.SelectedNode != null)
            {
                if (trvMain.SelectedNode.Level == 2)
                {
                    FuzzySet aUnaryFS = null;
                    FuzzySet fs_selected = (FuzzySet)trvMain.SelectedNode.Tag;
                    switch (cbxUnaryOperator.SelectedIndex)
                    {
                        case 0: // Negation
                            aUnaryFS = !fs_selected;
                            break;
                        case 1: // Value-Cut
                            if (!String.IsNullOrEmpty(tbUnaryParameters.Text))
                            {
                                double value = Convert.ToDouble(tbUnaryParameters.Text);
                                if (value > 0 & value < 1)
                                {
                                    aUnaryFS = value - fs_selected;
                                }
                                else
                                {
                                    tbUnaryParameters.Text = "0.5";
                                    aUnaryFS = 0.5 - fs_selected;
                                }
                            }
                            else
                            {
                                tbUnaryParameters.Text = "0.5";
                                aUnaryFS = 0.5 - fs_selected;
                            }
                            break;
                        case 2: // Very
                            aUnaryFS = new UnaryOperatedFS(new Very(), fs_selected);
                            break;
                        case 3: // More or Less
                            aUnaryFS = new UnaryOperatedFS(new MoreOrLess(), fs_selected);
                            break;
                        case 4: // Extremely
                            aUnaryFS = new UnaryOperatedFS(new Extremely(), fs_selected);
                            break;
                        case 5: // Intensification
                            aUnaryFS = new UnaryOperatedFS(new Intensification(), fs_selected);
                            break;
                        case 6: // Diminisher
                            aUnaryFS = new UnaryOperatedFS(new Diminisher(), fs_selected);
                            break;
                        case 7: // Scale
                            if (!String.IsNullOrEmpty(tbUnaryParameters.Text))
                            {
                                double value = Convert.ToDouble(tbUnaryParameters.Text);
                                if (value > 0 & value <= 1)
                                {
                                    aUnaryFS = value * fs_selected;
                                }
                                else
                                {
                                    tbUnaryParameters.Text = "0.5";
                                    aUnaryFS = 0.5 * fs_selected;
                                }
                            }
                            else
                            {
                                tbUnaryParameters.Text = "0.5";
                                aUnaryFS = 0.5 * fs_selected;
                            }
                            break;
                    }

                    aUnaryFS.VisualDisplay = true;

                    //trvMain.SelectedNode.Parent.Nodes.Add(aUnaryFS.TheNode);
                    chtMainChart.Series.Add(aUnaryFS.TheSeries);
                }
            }
        }
        private void btnAddBinaryOperatedFS_Click(object sender, EventArgs e)
        {
            // make sure both fuzzyset are selected and in the same universe
            if (FSCollection[0] != null)
            {
                if (FSCollection[1] != null)
                {
                    if (FSCollection[0].TheUniverse == FSCollection[1].TheUniverse)
                    {
                        // make sure we have selected one fuzzyset to be operated on, in order to add treenode properly
                        if (trvMain.SelectedNode.Level == 2)
                        {
                            if (((FuzzySet)trvMain.SelectedNode.Tag == FSCollection[0]) | ((FuzzySet)trvMain.SelectedNode.Tag == FSCollection[1]))
                            {
                                FuzzySet aBinaryFS = null;
                                FuzzySet fs_1 = FSCollection[0];
                                FuzzySet fs_2 = FSCollection[1];
                                switch (cbxBinaryOperator.SelectedIndex)
                                {
                                    case 0: // Intersection
                                        aBinaryFS = fs_1 & fs_2;
                                        break;
                                    case 1: // Union
                                        aBinaryFS = fs_1 | fs_2;
                                        break;
                                    case 2: // Algebraic Sum
                                        aBinaryFS = fs_1 + fs_2;
                                        break;
                                    case 3: // Bounded Sum
                                        aBinaryFS = new BinaryOperatedFS(new BoundedSum(), fs_1, fs_2);
                                        break;
                                    case 4: // Drastic Sum
                                        aBinaryFS = new BinaryOperatedFS(new DrasticSum(), fs_1, fs_2);
                                        break;
                                    case 5: // Algebraic Product
                                        aBinaryFS = fs_1 * fs_2;
                                        break;
                                    case 6: // Bounded Product
                                        aBinaryFS = new BinaryOperatedFS(new BoundedProduct(), fs_1, fs_2);
                                        break;
                                    case 7: // Drastic Product
                                        aBinaryFS = new BinaryOperatedFS(new DrasticProduct(), fs_1, fs_2);
                                        break;
                                    case 8: // Schweizer and Sklar Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double p = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (p > 0)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new SchweizerSklarTnorm(p), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "1";
                                                aBinaryFS = new BinaryOperatedFS(new SchweizerSklarTnorm(1), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "1";
                                            aBinaryFS = new BinaryOperatedFS(new SchweizerSklarTnorm(1), fs_1, fs_2);
                                        }
                                        break;
                                    case 9: // Yager Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double q = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (q > 0)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new YagerTnorm(q), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "1";
                                                aBinaryFS = new BinaryOperatedFS(new YagerTnorm(1), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "1";
                                            aBinaryFS = new BinaryOperatedFS(new YagerTnorm(1), fs_1, fs_2);
                                        }
                                        break;
                                    case 10: // Dubois and Prade Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double alpha = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (alpha >= 0 & alpha <= 1)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new DuboisPradeTnorm(alpha), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "0.5";
                                                aBinaryFS = new BinaryOperatedFS(new DuboisPradeTnorm(0.5), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "0.5";
                                            aBinaryFS = new BinaryOperatedFS(new DuboisPradeTnorm(0.5), fs_1, fs_2);
                                        }
                                        break;
                                    case 11: // Hamacher Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double gamma = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (gamma > 0)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new HamacherTnorm(gamma), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "1";
                                                aBinaryFS = new BinaryOperatedFS(new HamacherTnorm(1), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "1";
                                            aBinaryFS = new BinaryOperatedFS(new HamacherTnorm(1), fs_1, fs_2);
                                        }
                                        break;
                                    case 12: // Frank Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double s = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (s > 0)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new FrankTnorm(s), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "1";
                                                aBinaryFS = new BinaryOperatedFS(new FrankTnorm(1), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "1";
                                            aBinaryFS = new BinaryOperatedFS(new FrankTnorm(1), fs_1, fs_2);
                                        }
                                        break;
                                    case 13: // Sugeno Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double lambda = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (lambda >= -1)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new SugenoTnorm(lambda), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "-1";
                                                aBinaryFS = new BinaryOperatedFS(new SugenoTnorm(-1), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "-1";
                                            aBinaryFS = new BinaryOperatedFS(new SugenoTnorm(-1), fs_1, fs_2);
                                        }
                                        break;
                                    case 14: // Dombi Tnorm
                                        if (!String.IsNullOrEmpty(tbBinaryParameters.Text))
                                        {
                                            double lambda = Convert.ToDouble(tbBinaryParameters.Text);
                                            if (lambda > 0)
                                            {
                                                aBinaryFS = new BinaryOperatedFS(new DombiTnorm(lambda), fs_1, fs_2);
                                            }
                                            else
                                            {
                                                tbBinaryParameters.Text = "1";
                                                aBinaryFS = new BinaryOperatedFS(new DombiTnorm(1), fs_1, fs_2);
                                            }
                                        }
                                        else
                                        {
                                            tbBinaryParameters.Text = "1";
                                            aBinaryFS = new BinaryOperatedFS(new DombiTnorm(1), fs_1, fs_2);
                                        }
                                        break;
                                }

                                aBinaryFS.VisualDisplay = true;

                                //trvMain.SelectedNode.Parent.Nodes.Add(aBinaryFS.TheNode);
                                chtMainChart.Series.Add(aBinaryFS.TheSeries);
                            }
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (trvMain.SelectedNode != null)
            {
                if (trvMain.SelectedNode.Level == 2)
                {
                    label1.Text = trvMain.SelectedNode.Text;
                    FuzzySet fs_1 = (FuzzySet)trvMain.SelectedNode.Tag;
                    FSCollection[0] = fs_1;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (trvMain.SelectedNode != null)
            {
                if (trvMain.SelectedNode.Level == 2)
                {
                    label2.Text = trvMain.SelectedNode.Text;
                    FuzzySet fs_2 = (FuzzySet)trvMain.SelectedNode.Tag;
                    FSCollection[1] = fs_2;
                }
            }
        }

        private void cbxUnaryOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxUnaryOperator.SelectedIndex)
            {
                case 0: // Negation
                    label4.Visible = false;
                    tbUnaryParameters.Visible = false;
                    break;
                case 1: // Value-Cut
                    label4.Visible = true;
                    tbUnaryParameters.Visible = true;
                    label4.Text = "Alpha input value between 0-1 : ";
                    tbUnaryParameters.Text = "0.5";
                    break;
                case 2: // Very
                    label4.Visible = false;
                    tbUnaryParameters.Visible = false;
                    break;
                case 3: // More or Less
                    label4.Visible = false;
                    tbUnaryParameters.Visible = false;
                    break;
                case 4: // Extremely
                    label4.Visible = false;
                    tbUnaryParameters.Visible = false;
                    break;
                case 5: // Intensification
                    label4.Visible = false;
                    tbUnaryParameters.Visible = false;
                    break;
                case 6: // Diminisher
                    label4.Visible = false;
                    tbUnaryParameters.Visible = false;
                    break;
                case 7: // Scale
                    label4.Visible = true;
                    tbUnaryParameters.Visible = true;
                    label4.Text = "Scale input value between 0-1 : ";
                    tbUnaryParameters.Text = "0.5";
                    break;
            }
        }

        private void cbxBinaryOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxBinaryOperator.SelectedIndex)
            {
                case 0: // Intersection
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 1: // Union
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 2: // Algebraic Sum
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 3: // Bounded Sum
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 4: // Drastic Sum
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 5: // Algebraic Product
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 6: // Bounded Product
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 7: // Drastic Product
                    label3.Visible = false;
                    tbBinaryParameters.Visible = false;
                    break;
                case 8: // Schweizer and Sklar Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Schweizer and Sklar p input value > 0 : ";
                    tbBinaryParameters.Text = "1";
                    break;
                case 9: // Yager Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Yager q input value > 0 : ";
                    tbBinaryParameters.Text = "1";
                    break;
                case 10: // Dubois and Prade Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Dubois and Prade alpha input value (0-1) : ";
                    tbBinaryParameters.Text = "0.5";
                    break;
                case 11: // Hamacher Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Hamacher gamma input value > 0 : ";
                    tbBinaryParameters.Text = "1";
                    break;
                case 12: // Frank Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Frank s input value > 0 : ";
                    tbBinaryParameters.Text = "1";
                    break;
                case 13: // Sugeno Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Sugeno lambda input value >= -1 : ";
                    tbBinaryParameters.Text = "-1";
                    break;
                case 14: // Dombi Tnorm
                    label3.Visible = true;
                    tbBinaryParameters.Visible = true;
                    label3.Text = "Dombi lambda input value > 0 : ";
                    tbBinaryParameters.Text = "1";
                    break;
            }
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            dgvRules.Rows.Add();
            if (dgvConditions.Rows.Count == 0)
            {
                dgvConditions.Rows.Add();
            }
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TreeNode tn = trvMain.SelectedNode;
            if (tn.Level != 2) return;
            Universe un = (Universe)tn.Parent.Tag;
            Universe colUn = (Universe)dgvRules.Columns[e.ColumnIndex].Tag;

            // check un and colUn 
            if (un != colUn)
            {
                Console.Beep();
                return;
            }

            if (rbtnMamdani.Checked)
            {
                FuzzySet fs = (FuzzySet)tn.Tag;
                DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = fs;
            }else if (rbtnSugeno.Checked)
            {
                if (tn.Parent.Parent.Index == 0)
                {
                    FuzzySet fs = (FuzzySet)tn.Tag;
                    DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Value = fs;
                }
                else
                {
                    int eqID = (int)tn.Tag;
                    DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Value = eqID;
                }
            }
            else
            {
                FuzzySet fs = (FuzzySet)tn.Tag;
                DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = fs;
            }
        }

        private void dgvConditions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TreeNode tn = trvMain.SelectedNode;
            if (tn.Level != 2) return;
            Universe un = (Universe)tn.Parent.Tag;
            Universe colUn = (Universe)dgvConditions.Columns[e.ColumnIndex].Tag;

            // check un and colUn 
            if (un != colUn)
            {
                Console.Beep();
                return;
            }

            if (rbtnMamdani.Checked)
            {
                FuzzySet fs = (FuzzySet)tn.Tag;
                DataGridViewCell cell = dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = fs;
            }
        }

        FuzzySet inferenceResult;
        private void btnInferencing_Click(object sender, EventArgs e)
        {
            if (inferenceResult != null)
            {
                chtMainChart.Series.Remove(inferenceResult.TheSeries);
                inferenceResult.TheNode.Remove();
            }

            if (rbtnMamdani.Checked)
            {
                MamdaniFuzzySystem sysMam = new MamdaniFuzzySystem();
                sysMam.CutInferencing = ckbCut.Checked;
                sysMam.ConstructRules(dgvRules);

                // Prepare conditions
                FuzzySet[] condMam = new FuzzySet[dgvConditions.ColumnCount];
                for (int i = 0; i < dgvConditions.ColumnCount; i++)
                {
                    condMam[i] = ((FuzzySet)dgvConditions.Rows[0].Cells[i].Value);
                }

                inferenceResult = sysMam.FuzzyInFuzzyOutInferencing(condMam);
                // Enable visual display of the final result
                inferenceResult.VisualDisplay = true;
                inferenceResult.TheSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                inferenceResult.TheSeries.Color = Color.FromArgb(127, Color.Red);
                chtMainChart.Series.Add(inferenceResult.TheSeries);
            }
            else if (rbtnSugeno.Checked)
            {
                SugenoFuzzySystem sysSug = new SugenoFuzzySystem();
                sysSug.IsWeightedAverage = ckbCut.Checked;
                sysSug.ConstructRules(dgvRules);

                double resolution = 30;
                switch (domainResolution.SelectedIndex)
                {
                    case 0:
                        resolution = 30;
                        break;
                    case 1:
                        resolution = 40;
                        break;
                    case 2:
                        resolution = 50;
                        break;
                    case 3:
                        resolution = 60;
                        break;
                    default:
                        resolution = 30;
                        break;
                }

                double[] condition = new double[2];

                Universe u1, u2;
                u1 = (Universe)trvMain.Nodes[0].Nodes[0].Tag;
                u2 = (Universe)trvMain.Nodes[0].Nodes[1].Tag;

                double u1Delta = (u1.UpperBound - u1.LowerBound) / (resolution - 1);
                double u2Delta = (u2.UpperBound - u2.LowerBound) / (resolution - 1);
                surface1.Clear();

                for (int i = 0; i <= resolution; i++)
                {
                    double x = u1.LowerBound + i * u1Delta;
                    for (int j = 0; j <= resolution; j++)
                    {
                        double z = u2.LowerBound + j * u2Delta;
                        condition[0] = x;
                        condition[1] = z;
                        double y = sysSug.CrispInCrispOutInferencing(condition);

                        surface1.Add(x, y, z);
                    }
                }
            }
            else
            {
                TsukamotoFuzzySystem sysTsu = new TsukamotoFuzzySystem();
                sysTsu.IsWeightedAverage = ckbCut.Checked;
                sysTsu.ConstructRules(dgvRules);

                Universe u1;

                if (trvMain.Nodes[0].Nodes.Count == 1)
                {
                    u1 = (Universe)trvMain.Nodes[0].Nodes[0].Tag;

                    chtTsukamotoOutput.ChartAreas.Clear();
                    chtTsukamotoOutput.Series.Clear();
                    chtTsukamotoOutput.Legends.Clear();
                    ChartArea theArea = new ChartArea();
                    theArea.AxisX.Title = "x";
                    theArea.AxisY.Title = "y";


                    Series theSeries = new Series();
                    Legend theLegend = new Legend();
                    theSeries.ChartType = SeriesChartType.Line;
                    theSeries.BorderWidth = 2;
                    theSeries.Name = "x-y";

                    for (double x = u1.LowerBound; x <= u1.UpperBound; x += u1.Increment)
                    {
                        double[] temp = new double[1];
                        temp[0] = x;
                        double y = sysTsu.CrispInCrispOutInferencing(temp);
                        theSeries.Points.AddXY(x, y);
                    }

                    theSeries.Color = Color.FromArgb(127, Color.Red);
                    chtTsukamotoOutput.ChartAreas.Add(theArea);
                    chtTsukamotoOutput.Legends.Add(theLegend);
                    chtTsukamotoOutput.Series.Add(theSeries);
                }
            }
        }

        IFuzzySystem myFuzzySystem = null;

        private void btnGetCrispInputOutputResponse_Click(object sender, EventArgs e)
        {
            double resolution = 30;
            switch (domainResolution.SelectedIndex)
            {
                case 0: 
                    resolution = 30;
                    break;
                case 1:
                    resolution = 40;
                    break;
                case 2: 
                    resolution = 50;
                    break;
                case 3:
                    resolution = 60;
                    break;
                default:
                    resolution = 30;
                    break;
            }

            if (rbtnMamdani.Checked)
            {
                myFuzzySystem = new MamdaniFuzzySystem();
                myFuzzySystem.ConstructRules(dgvRules);
                double[] condition = new double[2];

                Universe u1, u2;
                u1 = (Universe)trvMain.Nodes[0].Nodes[0].Tag;
                u2 = (Universe)trvMain.Nodes[0].Nodes[1].Tag;

                double u1Delta = (u1.UpperBound - u1.LowerBound) / (resolution - 1);
                double u2Delta = (u2.UpperBound - u2.LowerBound) / (resolution - 1);
                surface1.Clear();

                for (int i = 0; i <= resolution; i++)
                {
                    double x = u1.LowerBound + i * u1Delta;
                    for (int j = 0; j <= resolution; j++)
                    {
                        double z = u2.LowerBound + j * u2Delta;
                        condition[0] = x;
                        condition[1] = z;
                        double y = myFuzzySystem.CrispInCrispOutInferencing(condition);

                        surface1.Add(x, y, z);
                    }
                }
            }else if (rbtnSugeno.Checked)
            {
                myFuzzySystem = new SugenoFuzzySystem();
                myFuzzySystem.ConstructRules(dgvRules);
                double[] condition = new double[2];

                Universe u1, u2;
                u1 = (Universe)trvMain.Nodes[0].Nodes[0].Tag;
                u2 = (Universe)trvMain.Nodes[0].Nodes[1].Tag;

                double u1Delta = (u1.UpperBound - u1.LowerBound) / (resolution - 1);
                double u2Delta = (u2.UpperBound - u2.LowerBound) / (resolution - 1);
                surface1.Clear();

                for (int i = 0; i <= resolution; i++)
                {
                    double x = u1.LowerBound + i * u1Delta;
                    for (int j = 0; j <= resolution; j++)
                    {
                        double z = u2.LowerBound + j * u2Delta;
                        condition[0] = x;
                        condition[1] = z;
                        double y = myFuzzySystem.CrispInCrispOutInferencing(condition);

                        surface1.Add(x, y, z);
                    }
                }
            }
            else
            {
                TsukamotoFuzzySystem sysTsu = new TsukamotoFuzzySystem();
                sysTsu.IsWeightedAverage = ckbCut.Checked;
                sysTsu.ConstructRules(dgvRules);

                Universe u1;

                if (trvMain.Nodes[0].Nodes.Count == 1)
                {
                    u1 = (Universe)trvMain.Nodes[0].Nodes[0].Tag;

                    chtTsukamotoOutput.ChartAreas.Clear();
                    chtTsukamotoOutput.Series.Clear();
                    chtTsukamotoOutput.Legends.Clear();
                    ChartArea theArea = new ChartArea();
                    theArea.AxisX.Title = "x";
                    theArea.AxisY.Title = "y";


                    Series theSeries = new Series();
                    Legend theLegend = new Legend();
                    theSeries.ChartType = SeriesChartType.Line;
                    theSeries.BorderWidth = 2;
                    theSeries.Name = "x-y";

                    for (double x = u1.LowerBound; x <= u1.UpperBound; x += u1.Increment)
                    {
                        double[] temp = new double[1];
                        temp[0] = x;
                        double y = sysTsu.CrispInCrispOutInferencing(temp);
                        theSeries.Points.AddXY(x, y);
                    }

                    theSeries.Color = Color.FromArgb(127, Color.Red);
                    chtTsukamotoOutput.ChartAreas.Add(theArea);
                    chtTsukamotoOutput.Legends.Add(theLegend);
                    chtTsukamotoOutput.Series.Add(theSeries);
                }
            }
        }

        Random rnd = new Random();

        double InferenceAData(double[] inputs)
        {
            return inputs[0] * Math.Sin(rnd.NextDouble()) + inputs[1] * Math.Cos(rnd.NextDouble() * 1.5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            surface1.IrregularGrid = true;
            surface1.NumXValues = 30;
            surface1.NumZValues = 30;
            double[] condition = new double[2];
            for (int i = 0; i <= surface1.NumXValues; i++)
            {
                double x = i * 0.1;
                for (int j = 0; j <= surface1.NumZValues; j++)
                {
                    double z = 2 + j * 0.2;
                    condition[0] = x;
                    condition[1] = z;
                    double y = InferenceAData(condition);

                    surface1.Add(x, y, z);
                }
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgSave.ShowDialog();
            if (result != DialogResult.OK) return;
            StreamWriter sw = new StreamWriter(dlgSave.FileName);
            sw.WriteLine($"Model:{myFuzzySystem.SystemType}");

            // save input universe and its FSs
            int num1 = trvMain.Nodes[0].Nodes.Count;
            sw.WriteLine($"NumberOfInputUniverses:{num1}");
            for (int i = 0; i < num1; i++)
            {
                Universe u = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                u.Save(sw);
                int nfs = trvMain.Nodes[0].Nodes[i].Nodes.Count;
                sw.WriteLine($"NumberOfFSs:{nfs}");
                for (int j = 0; j < nfs; j++)
                {
                    FuzzySet fs = (FuzzySet)trvMain.Nodes[0].Nodes[i].Nodes[j].Tag;
                    sw.WriteLine($"*FuzzySetType:{fs.GetType().Name}");
                    fs.Save(sw);
                }
            }

            // save output universe and its FSs
            if (rbtnMamdani.Checked)
            {
                int num2 = trvMain.Nodes[1].Nodes.Count;
                sw.WriteLine($"NumberOfOutputUniverse:{num2}");
                for (int i = 0; i < num2; i++)
                {
                    Universe u = (Universe)trvMain.Nodes[1].Nodes[i].Tag;
                    u.Save(sw);
                    int nfs = trvMain.Nodes[1].Nodes[i].Nodes.Count;
                    sw.WriteLine($"NumberOfFSs:{nfs}");
                    for (int j = 0; j < nfs; j++)
                    {
                        FuzzySet fs = (FuzzySet)trvMain.Nodes[1].Nodes[i].Nodes[j].Tag;
                        sw.WriteLine($"FuzzySetType:{fs.GetType().Name}");
                        fs.Save(sw);
                    }
                }
            }
            else if (rbtnSugeno.Checked)
            {
                int num2 = trvMain.Nodes[1].Nodes.Count;
                sw.WriteLine($"NumberOfOutputUniverse:{num2}");
                for (int i = 0; i < num2; i++)
                {
                    Universe u = (Universe)trvMain.Nodes[1].Nodes[i].Tag;
                    u.Save(sw);
                    int nfs = trvMain.Nodes[1].Nodes[i].Nodes.Count;
                    sw.WriteLine($"NumberOfFSs:{nfs}");
                    for (int j = 0; j < nfs; j++)
                    {
                        // need revision later
                        sw.WriteLine($"*EquationTitle:{trvMain.Nodes[1].Nodes[i].Nodes[j].Text}");
                        string eqID = (trvMain.Nodes[1].Nodes[i].Nodes[j].Text).Substring(1, 1);
                        sw.WriteLine($"*EquationID:{eqID}");
                    }
                }
            }
            else
            {
                int num2 = trvMain.Nodes[1].Nodes.Count;
                sw.WriteLine($"NumberOfOutputUniverse:{num2}");
                for (int i = 0; i < num2; i++)
                {
                    Universe u = (Universe)trvMain.Nodes[1].Nodes[i].Tag;
                    u.Save(sw);
                    int nfs = trvMain.Nodes[1].Nodes[i].Nodes.Count;
                    sw.WriteLine($"NumberOfFSs:{nfs}");
                    for (int j = 0; j < nfs; j++)
                    {
                        FuzzySet fs = (FuzzySet)trvMain.Nodes[1].Nodes[i].Nodes[j].Tag;
                        sw.WriteLine($"FuzzySetType:{fs.GetType().Name}");
                        fs.Save(sw);
                    }
                }
            }

            // ask fuzzy system update its rules
            myFuzzySystem.ConstructRules(dgvRules);

            // save rules
            sw.WriteLine($"NumberOfRuleRows:{dgvRules.RowCount}");
            sw.WriteLine($"NumberOfRuleCols:{dgvRules.ColumnCount}");
            myFuzzySystem.Save(sw);

            // save conditions
            if (rbtnMamdani.Checked)
            {
                sw.WriteLine($"NumberOfConditionRows:{dgvConditions.RowCount}");
                sw.WriteLine($"NumberOfConditionCols:{dgvConditions.ColumnCount}");

                // Prepare conditions
                FuzzySet[] condMam = new FuzzySet[dgvConditions.ColumnCount];
                for (int i = 0; i < dgvConditions.ColumnCount; i++)
                {
                    condMam[i] = ((FuzzySet)dgvConditions.Rows[0].Cells[i].Value);
                }

                for (int i = 0; i < condMam.Length; i++)
                {
                    if (condMam[i] != null)
                    {
                        sw.WriteLine($"FuzzySetHash:{condMam[i].GetHashCode()}");
                    }
                }
            }
            else if (rbtnSugeno.Checked)
            {
                sw.WriteLine($"NumberOfConditionRows:{dgvConditions.RowCount}");
                sw.WriteLine($"NumberOfConditionCols:{dgvConditions.ColumnCount}");

                // Prepare conditions
                //FuzzySet[] condSug = new FuzzySet[dgvConditions.ColumnCount];
                //for (int i = 0; i < dgvConditions.ColumnCount; i++)
                //{
                //    condSug[i] = ((FuzzySet)dgvConditions.Rows[0].Cells[i].Value);
                //}

                for (int i = 0; i < dgvConditions.ColumnCount; i++)
                {
                    sw.WriteLine($"FuzzySetHash:None");
                }
            }
            else
            {
                sw.WriteLine($"NumberOfConditionRows:{dgvConditions.RowCount}");
                sw.WriteLine($"NumberOfConditionCols:{dgvConditions.ColumnCount}");

                //// Prepare conditions
                //FuzzySet[] condTsu = new FuzzySet[dgvConditions.ColumnCount];
                //for (int i = 0; i < dgvConditions.ColumnCount; i++)
                //{
                //    condTsu[i] = ((FuzzySet)dgvConditions.Rows[0].Cells[i].Value);
                //}

                for (int i = 0; i < dgvConditions.ColumnCount; i++)
                {
                    sw.WriteLine($"FuzzySetHash:None");
                }
            }
            sw.Close();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(dlgOpen.FileName);
            string str;
            string[] items;
            str = sr.ReadLine();
            items = str.Split(':');
            Type systemType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
            myFuzzySystem = (IFuzzySystem)Activator.CreateInstance(systemType);

            if ((string)items[1] == "MamdaniFuzzySystem")
            {
                rbtnMamdani.Checked = true;
                rbtnSugeno.Checked = false;
                rbtnTsukamoto.Checked = false;
            }else if ((string)items[1] == "SugenoFuzzySystem")
            {
                rbtnMamdani.Checked = false;
                rbtnSugeno.Checked = true;
                rbtnTsukamoto.Checked = false;
            }
            else
            {
                rbtnMamdani.Checked = false;
                rbtnSugeno.Checked = false;
                rbtnTsukamoto.Checked = true;
                chtTsukamotoOutput.Visible = true;
            }

            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);

            // clear old contents
            trvMain.Nodes[0].Nodes.Clear();
            chtMainChart.Series.Clear();
            chtMainChart.Legends.Clear();
            chtMainChart.ChartAreas.Clear();

            List<FuzzySet> allFSs = new List<FuzzySet>();

            // read in input universes and their FSs and ** maintain TreeView node information
            for (int i = 0; i < num; i++)
            {
                Universe u = new Universe();
                u.Open(sr);
                chtMainChart.ChartAreas.Add(u.TheArea);
                chtMainChart.Legends.Add(u.TheLegend);
                trvMain.Nodes[0].Nodes.Add(u.TheNode);
                trvMain.ExpandAll();
                trvMain.Focus();

                items = sr.ReadLine().Split(':');
                int nfs = Convert.ToInt32(items[1]);
                for (int j = 0; j < nfs; j++)
                {
                    items = sr.ReadLine().Split(':');
                    Type fsType;
                    fsType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
                    FuzzySet fs = (FuzzySet)Activator.CreateInstance(fsType, u);
                    fs.VisualDisplay = true;
                    chtMainChart.Series.Add(fs.TheSeries);
                    fs.Open(sr);

                    trvMain.ExpandAll();
                    trvMain.Focus();

                    allFSs.Add(fs);
                }
            }

            // read output universe and its FSs
            if (rbtnMamdani.Checked)
            {
                int num2;
                items = sr.ReadLine().Split(':');
                num2 = Convert.ToInt32(items[1]);
                // clear old contents
                trvMain.Nodes[1].Nodes.Clear();
                // read in output universes and their FSs and ** maintain TreeView node information
                for (int i = 0; i < num2; i++)
                {
                    Universe u = new Universe();
                    u.Open(sr);

                    // maintain output universes treeview node
                    chtMainChart.ChartAreas.Add(u.TheArea);
                    u.TheArea.BackColor = Color.LightSkyBlue;
                    chtMainChart.Legends.Add(u.TheLegend);
                    trvMain.Nodes[1].Nodes.Insert(0, u.TheNode);
                    trvMain.ExpandAll();
                    trvMain.Focus();

                    items = sr.ReadLine().Split(':');
                    int nfs = Convert.ToInt32(items[1]);
                    for (int j = 0; j < nfs; j++)
                    {
                        items = sr.ReadLine().Split(':');
                        Type fsType;
                        fsType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
                        FuzzySet fs = (FuzzySet)Activator.CreateInstance(fsType, u);
                        fs.VisualDisplay = true;
                        chtMainChart.Series.Add(fs.TheSeries);
                        //if (j == nfs - 1)
                        //{
                        //    fs.TheSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                        //    fs.TheSeries.Color = Color.FromArgb(127, Color.Red);
                        //}

                        fs.Open(sr);

                        trvMain.ExpandAll();
                        trvMain.Focus();

                        allFSs.Add(fs);
                    }
                }
            }
            else if (rbtnSugeno.Checked)
            {
                int num2;
                items = sr.ReadLine().Split(':');
                num2 = Convert.ToInt32(items[1]);
                // clear old contents
                trvMain.Nodes[1].Nodes.Clear();
                // read in output universes and their FSs and ** maintain TreeView node information
                for (int i = 0; i < num2; i++)
                {
                    Universe u = new Universe();
                    u.Open(sr);

                    // maintain output universes treeview node
                    chtMainChart.ChartAreas.Add(u.TheArea);
                    chtMainChart.Legends.Add(u.TheLegend);
                    trvMain.Nodes[1].Nodes.Insert(0, u.TheNode);
                    trvMain.ExpandAll();
                    trvMain.Focus();

                    items = sr.ReadLine().Split(':');
                    int nEQ = Convert.ToInt32(items[1]);
                    for (int j = 0; j < nEQ; j++)
                    {
                        items = sr.ReadLine().Split(':');
                        TreeNode tn = new TreeNode();
                        tn.Text = items[1];

                        items = sr.ReadLine().Split(':');
                        tn.Tag = Convert.ToInt32(items[1]);

                        trvMain.Nodes[1].Nodes[0].Nodes.Add(tn);
                        trvMain.Focus();
                        trvMain.ExpandAll();
                    }
                }
            }
            else
            {
                int num2;
                items = sr.ReadLine().Split(':');
                num2 = Convert.ToInt32(items[1]);
                // clear old contents
                trvMain.Nodes[1].Nodes.Clear();
                // read in output universes and their FSs and ** maintain TreeView node information
                for (int i = 0; i < num2; i++)
                {
                    Universe u = new Universe();
                    u.Open(sr);

                    // maintain output universes treeview node
                    chtMainChart.ChartAreas.Add(u.TheArea);
                    chtMainChart.Legends.Add(u.TheLegend);
                    trvMain.Nodes[1].Nodes.Insert(0, u.TheNode);
                    trvMain.ExpandAll();
                    trvMain.Focus();

                    items = sr.ReadLine().Split(':');
                    int nfs = Convert.ToInt32(items[1]);
                    for (int j = 0; j < nfs; j++)
                    {
                        items = sr.ReadLine().Split(':');
                        Type fsType;
                        fsType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
                        FuzzySet fs = (FuzzySet)Activator.CreateInstance(fsType, u);
                        fs.VisualDisplay = true;
                        chtMainChart.Series.Add(fs.TheSeries);
                        fs.Open(sr);

                        trvMain.ExpandAll();
                        trvMain.Focus();

                        allFSs.Add(fs);
                    }
                }
            }

            // Resume references of unary- and -binary- operated FSs
            foreach (FuzzySet fs in allFSs)
            {
                if (fs is UnaryOperatedFS || fs is BinaryOperatedFS)
                {
                    fs.RebuildFuzzySetReferences(allFSs);
                }
            }

            // clear rule datagridview
            dgvRules.Columns.Clear();
            dgvRules.Rows.Clear();


            if (rbtnMamdani.Checked)
            {
                // read in rule and maintain dgvRules
                // prepare dgvRules Columns
                for (int i = 0; i < trvMain.Nodes[0].Nodes.Count; i++)
                {
                    DataGridViewTextBoxColumn ruleCol = new DataGridViewTextBoxColumn();
                    Universe ant_univ = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                    ruleCol.Name = ruleCol.HeaderText = ant_univ.Title;
                    ruleCol.Tag = ant_univ;
                    dgvRules.Columns.Add(ruleCol);
                }

                DataGridViewTextBoxColumn ruleConclusion = new DataGridViewTextBoxColumn();
                Universe con_univ = (Universe)trvMain.Nodes[1].Nodes[0].Tag;
                ruleConclusion.Name = ruleConclusion.HeaderText = con_univ.Title;
                ruleConclusion.Tag = con_univ;
                dgvRules.Columns.Add(ruleConclusion);

                myFuzzySystem.Open(sr, allFSs);

                // Add dgvRule's Rows
                for (int i = 0; i < myFuzzySystem.RulesCount(); i++)
                {
                    dgvRules.Rows.Add();
                    for (int j = 0; j < (myFuzzySystem.Rule_antecedents(i)).Length; j++)
                    {
                        FuzzySet fs_ant = (myFuzzySystem.Rule_antecedents(i))[j];
                        DataGridViewCell cell_ant = dgvRules.Rows[i].Cells[j];
                        cell_ant.Value = fs_ant;
                    }
                    FuzzySet fs_con = (myFuzzySystem.Rule_conclusion(i))[0];
                    DataGridViewCell cell_con = dgvRules.Rows[i].Cells[(myFuzzySystem.Rule_antecedents(i)).Length];
                    cell_con.Value = fs_con;
                }
            }
            else if (rbtnSugeno.Checked)
            {
                // read in rule and maintain dgvRules
                // prepare dgvRules Columns
                for (int i = 0; i < trvMain.Nodes[0].Nodes.Count; i++)
                {
                    DataGridViewTextBoxColumn ruleCol = new DataGridViewTextBoxColumn();
                    Universe ant_univ = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                    ruleCol.Name = ruleCol.HeaderText = ant_univ.Title;
                    ruleCol.Tag = ant_univ;
                    dgvRules.Columns.Add(ruleCol);
                }

                DataGridViewTextBoxColumn ruleConclusion = new DataGridViewTextBoxColumn();
                Universe con_univ = (Universe)trvMain.Nodes[1].Nodes[0].Tag;
                ruleConclusion.Name = ruleConclusion.HeaderText = con_univ.Title;
                ruleConclusion.Tag = con_univ;
                dgvRules.Columns.Add(ruleConclusion);

                myFuzzySystem.Open(sr, allFSs);

                // Add dgvRule's Rows
                for (int i = 0; i < myFuzzySystem.RulesCount(); i++)
                {
                    dgvRules.Rows.Add();
                    for (int j = 0; j < (myFuzzySystem.Rule_antecedents(i)).Length; j++)
                    {
                        FuzzySet fs_ant = (myFuzzySystem.Rule_antecedents(i))[j];
                        DataGridViewCell cell_ant = dgvRules.Rows[i].Cells[j];
                        cell_ant.Value = fs_ant;
                    }
                    int fs_con = (myFuzzySystem.Rule_conclusion2(i))[0];
                    DataGridViewCell cell_con = dgvRules.Rows[i].Cells[(myFuzzySystem.Rule_antecedents(i)).Length];
                    cell_con.Value = fs_con;
                }
            }
            else
            {
                // read in rule and maintain dgvRules
                // prepare dgvRules Columns
                for (int i = 0; i < trvMain.Nodes[0].Nodes.Count; i++)
                {
                    DataGridViewTextBoxColumn ruleCol = new DataGridViewTextBoxColumn();
                    Universe ant_univ = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                    ruleCol.Name = ruleCol.HeaderText = ant_univ.Title;
                    ruleCol.Tag = ant_univ;
                    dgvRules.Columns.Add(ruleCol);
                }

                DataGridViewTextBoxColumn ruleConclusion = new DataGridViewTextBoxColumn();
                Universe con_univ = (Universe)trvMain.Nodes[1].Nodes[0].Tag;
                ruleConclusion.Name = ruleConclusion.HeaderText = con_univ.Title;
                ruleConclusion.Tag = con_univ;
                dgvRules.Columns.Add(ruleConclusion);

                myFuzzySystem.Open(sr, allFSs);

                // Add dgvRule's Rows
                for (int i = 0; i < myFuzzySystem.RulesCount(); i++)
                {
                    dgvRules.Rows.Add();
                    for (int j = 0; j < (myFuzzySystem.Rule_antecedents(i)).Length; j++)
                    {
                        FuzzySet fs_ant = (myFuzzySystem.Rule_antecedents(i))[j];
                        DataGridViewCell cell_ant = dgvRules.Rows[i].Cells[j];
                        cell_ant.Value = fs_ant;
                    }
                    FuzzySet fs_con = (myFuzzySystem.Rule_conclusion(i))[0];
                    DataGridViewCell cell_con = dgvRules.Rows[i].Cells[(myFuzzySystem.Rule_antecedents(i)).Length];
                    cell_con.Value = fs_con;
                }
            }

            // clear condition datagridview
            dgvConditions.Columns.Clear();
            dgvConditions.Rows.Clear();

            // read in conditions
            if (rbtnMamdani.Checked)
            {
                int condNum;
                int condAntNum;
                items = sr.ReadLine().Split(':');
                condNum = Convert.ToInt32(items[1]);
                items = sr.ReadLine().Split(':');
                condAntNum = Convert.ToInt32(items[1]);

                for (int i = 0; i < condAntNum; i++)
                {
                    DataGridViewTextBoxColumn condcol = new DataGridViewTextBoxColumn();
                    Universe u = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                    condcol.Name = condcol.HeaderText = u.Title;
                    condcol.Tag = u;
                    dgvConditions.Columns.Add(condcol);
                }

                dgvConditions.Rows.Add(condNum);

                FuzzySet[] condFS = new FuzzySet[condAntNum];
                for (int i = 0; i < condAntNum; i++)
                {
                    DataGridViewCell cell = dgvConditions.Rows[condNum - 1].Cells[i];
                    items = sr.ReadLine().Split(':');
                    int fsCode = Convert.ToInt32(items[1]);
                    foreach (FuzzySet fs in allFSs)
                    {
                        if (fs.SavedHashCode == fsCode)
                        {
                            cell.Value = fs;
                            break;
                        }
                    }
                }
            }
            else if (rbtnSugeno.Checked)
            {
                int condNum;
                int condAntNum;
                items = sr.ReadLine().Split(':');
                condNum = Convert.ToInt32(items[1]);
                items = sr.ReadLine().Split(':');
                condAntNum = Convert.ToInt32(items[1]);

                for (int i = 0; i < condAntNum; i++)
                {
                    DataGridViewTextBoxColumn condcol = new DataGridViewTextBoxColumn();
                    Universe u = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                    condcol.Name = condcol.HeaderText = u.Title;
                    condcol.Tag = u;
                    dgvConditions.Columns.Add(condcol);
                }

                dgvConditions.Rows.Add(condNum);

                FuzzySet[] condFS = new FuzzySet[condAntNum];
                for (int i = 0; i < condAntNum; i++)
                {
                    DataGridViewCell cell = dgvConditions.Rows[condNum - 1].Cells[i];
                    cell.Value = null;
                }
            }
            else
            {
                int condNum;
                int condAntNum;
                items = sr.ReadLine().Split(':');
                condNum = Convert.ToInt32(items[1]);
                items = sr.ReadLine().Split(':');
                condAntNum = Convert.ToInt32(items[1]);

                for (int i = 0; i < condAntNum; i++)
                {
                    DataGridViewTextBoxColumn condcol = new DataGridViewTextBoxColumn();
                    Universe u = (Universe)trvMain.Nodes[0].Nodes[i].Tag;
                    condcol.Name = condcol.HeaderText = u.Title;
                    condcol.Tag = u;
                    dgvConditions.Columns.Add(condcol);
                }

                dgvConditions.Rows.Add(condNum);

                FuzzySet[] condFS = new FuzzySet[condAntNum];
                for (int i = 0; i < condAntNum; i++)
                {
                    DataGridViewCell cell = dgvConditions.Rows[condNum - 1].Cells[i];
                    cell.Value = null;
                }
            }
            sr.Close();
        }

        private void FuzzySystemChanged(object sender, EventArgs e)
        {
            if (rbtnMamdani.Checked)
            {
                myFuzzySystem = new MamdaniFuzzySystem();
                this.EquationPage.Hide();
            }
            else if (rbtnSugeno.Checked)
            {
                myFuzzySystem = new SugenoFuzzySystem();
                this.EquationPage.Show();
            }
            else
            {
                myFuzzySystem = new TsukamotoFuzzySystem();
                this.EquationPage.Hide();
            }
            prgSystem.SelectedObject = myFuzzySystem;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbOpen_Click(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbSave_Click(null, null);
        }

        private void rbtnSugeno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSugeno.Checked)
            {
                this.EquationPage.Parent = this.tabControl;
                this.FuzzySetPage.Parent = this.tabControl;
                this.RulesPage.Parent = this.tabControl;

                splitContainer7.Visible = false;
                chtTsukamotoOutput.Visible = false;
            }
        }

        private void rbtnMamdani_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMamdani.Checked)
            {
                this.EquationPage.Parent = null;
                this.FuzzySetPage.Parent = this.tabControl;
                this.RulesPage.Parent = this.tabControl;

                splitContainer7.Visible = false;
                chtTsukamotoOutput.Visible = false;
            }
        }

        private void rbtnTsukamoto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTsukamoto.Checked)
            {
                this.EquationPage.Parent = null;
                this.FuzzySetPage.Parent = this.tabControl;
                this.RulesPage.Parent = this.tabControl;

                splitContainer7.Visible = true;
                chtTsukamotoOutput.Visible = true;
            }
        }

        private void btnAddEquation_Click(object sender, EventArgs e)
        {
            if (trvMain.SelectedNode != null)
            {
                if (trvMain.SelectedNode.Level == 1)
                {
                    if (trvMain.SelectedNode.Parent.Index == 1)
                    {
                        int EQid = 0;

                        switch (lsbEquation.SelectedIndex)
                        {
                            case 0: //Y=0.1X+6.4
                                EQid = 0;
                                break;
                            case 1: // Y=-0.5X+4
                                EQid = 1;
                                break;
                            case 2: // Y=X-2
                                EQid = 2;
                                break;
                            case 3: // Z=-X+Y+1
                                EQid = 3;
                                break;
                            case 4: // Z =-Y+3
                                EQid = 4;
                                break;
                            case 5: // Z=-X+3
                                EQid = 5;
                                break;
                            case 6: // Z=X+Y+2
                                EQid = 6;
                                break;
                        }

                        TreeNode tn = new TreeNode();
                        tn.Tag = EQid;
                        tn.Text = (String)lsbEquation.SelectedItem;
                        trvMain.SelectedNode.Nodes.Add(tn);
                        trvMain.Focus();
                        trvMain.ExpandAll();
                    }
                }
            }
        }

        private void btnInferTsukamoto_Click(object sender, EventArgs e)
        {
            TsukamotoFuzzySystem sysTsu = new TsukamotoFuzzySystem();
            sysTsu.IsWeightedAverage = ckbCut.Checked;
            sysTsu.ConstructRules(dgvRules);

            Universe u1;
            if (trvMain.Nodes[0].Nodes.Count == 1)
            {
                u1 = (Universe)trvMain.Nodes[0].Nodes[0].Tag;

                chtTsukamotoOutput.ChartAreas.Clear();
                chtTsukamotoOutput.Series.Clear();
                chtTsukamotoOutput.Legends.Clear();
                ChartArea theArea = new ChartArea();
                theArea.AxisX.Title = "x";
                theArea.AxisY.Title = "y";


                Series theSeries = new Series();
                Legend theLegend = new Legend();
                theSeries.ChartType = SeriesChartType.Line;
                theSeries.BorderWidth = 2;
                theSeries.Name = "x-y";

                for (double x = u1.LowerBound; x <= u1.UpperBound; x += u1.Increment)
                {
                    double[] temp = new double[1];
                    temp[0] = x;
                    double y = sysTsu.CrispInCrispOutInferencing(temp);
                    theSeries.Points.AddXY(x, y);
                }

                theSeries.Color = Color.FromArgb(127, Color.Red);
                chtTsukamotoOutput.ChartAreas.Add(theArea);
                chtTsukamotoOutput.Legends.Add(theLegend);
                chtTsukamotoOutput.Series.Add(theSeries);
            }
        }
    }
}
