using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R10546040FuzzySetNamespace
{
    public partial class MyForm : Form
    {
        FuzzySet[] FSCollection = new FuzzySet[2];

        public MyForm()
        {
            InitializeComponent();
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
                        dgvRules.Columns.RemoveAt(dgvRules.Columns.Count-1);
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
            switch(cbxUnaryOperator.SelectedIndex)
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
            
            FuzzySet fs = (FuzzySet)tn.Tag;
            DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.Value = fs;
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

            FuzzySet fs = (FuzzySet)tn.Tag;
            DataGridViewCell cell = dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.Value = fs;
        }

        FuzzySet inferenceResult;
        private void btnInferencing_Click(object sender, EventArgs e)
        {
            if (inferenceResult != null)
            {
                chtMainChart.Series.Remove(inferenceResult.TheSeries);
                inferenceResult.TheNode.Remove();
            }

            // Construct rules
            List<MamdaniRule> rules = new List<MamdaniRule>();
            foreach ( DataGridViewRow row in dgvRules.Rows)
            {
                List<FuzzySet> ant = new List<FuzzySet>();
                for (int i = 0; i < dgvRules.ColumnCount - 1; i++)
                {
                    ant.Add((FuzzySet)row.Cells[i].Value);
                }
                FuzzySet conclusion = (FuzzySet)row.Cells[dgvRules.ColumnCount - 1].Value;
                MamdaniRule rule = new MamdaniRule(ant, conclusion);
                rules.Add(rule);
            }

            // Prepare conditions
            List<FuzzySet> cond = new List<FuzzySet>();
            for (int i = 0; i < dgvConditions.ColumnCount; i++)
            {
                cond.Add((FuzzySet)dgvConditions.Rows[0].Cells[i].Value);
            }

            // Infer
            inferenceResult = rules[0].FuzzyInFuzzyOutInferencing(cond, ckbCut.Checked);

            for (int i = 1; i < rules.Count; i++)
            {
                inferenceResult |= rules[i].FuzzyInFuzzyOutInferencing(cond, ckbCut.Checked);
            }

            // Enable visual display of the final result
            inferenceResult.VisualDisplay = true;
            inferenceResult.TheSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            inferenceResult.TheSeries.Color = Color.FromArgb(127, Color.Red);
            chtMainChart.Series.Add(inferenceResult.TheSeries);
        }
    }
}
