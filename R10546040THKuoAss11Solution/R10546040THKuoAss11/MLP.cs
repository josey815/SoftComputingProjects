using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace R10546040THKuoAss11
{
    internal class MLP
    {

        #region DATA FIELDS
        float[][] x; // neuron values
        float[][][] w; // weights
        float[][] e; // epsilon; partial derivative of error with respect to net value.

        int[] n; // numbers of neuron on layers
        int inputDimension; // dimension of input vector
        int inputNumber; // number of instances on the data set
        float trainingRatio = 0.66f;
        int numberOfTrainingVectors; // number of instances that are serving as training data
        float[,] originalInputs; // original instances of input vectors (without normalization)
        float[,] inputs; // normalized input vectors
        float[] inputMax; // upper bounds on all components of input vectors
        float[] inputMin; // lower bounds on all components of input vectors
        int inputWidth; // dimension in width for a two-dimensional input vector

        int targetDimension; // dimension of target vector
        float[,] originalTargets; // original instances of target vectors (without normalization)
        float[,] targets; // normalized target vectors
        float[] targetMax; // upper bounds on all components of target vectors
        float[] targetMin; // lower bounds on all components of target vectors.
        
        int[] vectorIndices; // array of shuffled indices of data instances; the front portion is training vectors;
        //the rear portion is testing vectors
        float rootMeanSquareError = 0.0f; // root mean square of error for an epoch of data training
        int layerNumber; // number of neuron layer (including the input layer)
        int epochLimit = 500;
        int epochCount = 0;
        
        Random randomizer = new Random();
        
        float learningRate = 0.999f; // learning rate, specified by the user
        /// <summary>
        /// The factor of reducing the eta epoch by epoch. That is
        /// eta <-- LearningRate * eta
        /// </summary>
        /// 
        float eta; // step size that specify the update amount on each weight
        float initialEta = 0.7f; // initial step size, specified by the user
        #endregion

        #region PROPERTIES
        [Category("Training Setting")]
        public float LearningRate
        {
            get { return learningRate; }
            set 
            {
                if (value < 1.0 && value > 0.95) learningRate = value; 
            }
        }
        [Category("Training Setting")]
        /// <summary>
        /// Initialize variable of the eta (can be regarded as step size).
        /// </summary>
        public float InitialEta
        {            
            get { return initialEta; }
            set 
            { 
                if (value > 0.1 && value < 1.0) initialEta = value; 
            }
        }
        [Category("Training Setting")]
        [Browsable(false)]
        /// <summary>
        /// Current root mean square after an epoch training.
        /// </summary>
        /// 
        public float RootMeanSquareError
        {
            get { return rootMeanSquareError; } //set { rootMeanSquare = value; }
        }
        [Category("Training Setting")]
        public float TrainingRatio 
        {
            get => trainingRatio; 
            set => trainingRatio = value; 
        }
        [Category("Training Setting")]
        public int EpochLimit 
        { 
            get => epochLimit;
            set
            {
                if (value > 0) epochLimit = value;
            }
        }
        [Category("Training Setting")]
        [Browsable (false)]
        public int EpochCount { get => epochCount; set => epochCount = value; }
        #endregion

        #region FUNCTIONS
        public void DrawTheMLP(Graphics g, Rectangle bound)
        {
            if (n == null) return;
            int deltaX, deltaY;
            deltaX = bound.Width / n.Length;
            int radius = bound.Height / 10;
            Rectangle box = new Rectangle(0, 0, radius, radius);
            Rectangle dot = new Rectangle(0, 0, radius / 5, radius / 5);
            StringFormat sf = new StringFormat();
            sf.Alignment = sf.LineAlignment = StringAlignment.Center;
            Font myFont = new Font("微軟正黑體", bound.Height / 50.0f);
            Pen myPen = new Pen(Color.FromArgb(127, Color.Black));
            myPen.Width = 0.5f;
            double[] dotX = new double[n.Length];
            double[] dotY = new double[n.Length];
            double[] boxX = new double[n.Length];
            double[] boxY;

            // draw lines first
            for (int l = 0; l < n.Length; l++)
            {
                deltaY = bound.Height / n[l];
                int xxx = deltaX / 2 + l * deltaX; // center of each layer
                box.X = xxx - radius / 2; // left-side of each box
                boxX[l] = xxx; // store the center x of each box
                dotX[l] = xxx; // store the center x of each dot
                for (int r = 0; r < n[l]; r++)
                {
                    if (r == 0)
                    {
                        dot.X = xxx - dot.Width / 2; // left-side of dot
                        dot.Y = deltaY / 2 + r * deltaY - dot.Width / 2; // up-side of dot
                        dotY[l] = dot.Y + dot.Width / 2; // center of dot
                    }
                    else
                    {
                        box.Y = deltaY / 2 + r * deltaY - radius / 2; // up-side of box
                        boxY = new double[n[l]];
                        boxY[r] = box.Y + radius / 2; // center of box
                        if (l > 0)
                        {
                            for (int k = 0; k < n[l-1]; k++)
                            {
                                if (k == 0)
                                {
                                    Point p1 = new Point((int)dotX[l - 1], (int)dotY[l - 1]);
                                    Point p2 = new Point((int)boxX[l], (int)boxY[r]);
                                    g.DrawLine(myPen, p1, p2);
                                }
                                else
                                {
                                    Point p1 = new Point((int)dotX[l - 1], (int)dotY[l - 1]+ k * (bound.Height / n[l-1]));
                                    Point p2 = new Point((int)boxX[l], (int)boxY[r]);
                                    g.DrawLine(myPen, p1, p2);
                                }
                            }
                        }
                    }
                }
            }
            // draw neurons
            for (int l = 0; l < n.Length; l++)
            {
                deltaY = bound.Height / n[l];
                int xxx = deltaX / 2 + l * deltaX; // center of each layer
                box.X = xxx - radius / 2; // left-side of each box
                boxX[l] = xxx; // store the center x of each box
                dotX[l] = xxx; // store the center x of each dot
                for (int r = 0; r < n[l]; r++)
                {
                    if (r == 0)
                    {
                        dot.X = xxx - dot.Width / 2; // left-side of dot
                        dot.Y = deltaY / 2 + r * deltaY - dot.Width / 2; // up-side of dot
                        dotY[l] = dot.Y + dot.Width / 2; // center of dot
                        g.FillEllipse(Brushes.Red, dot);
                        g.DrawEllipse(Pens.DarkBlue, dot);
                    }
                    else
                    {
                        box.Y = deltaY / 2 + r * deltaY - radius / 2; // up-side of box
                        boxY = new double[n[l]];
                        boxY[r] = box.Y + radius / 2; // center of box
                        g.FillEllipse(Brushes.LightYellow, box);
                        g.DrawEllipse(Pens.DarkBlue, box);
                        g.DrawString(x[l][r].ToString("0.00"), myFont, Brushes.Black, box, sf);
                    }
                }
            }
            // write weight numbers
            for (int l = 0; l < n.Length; l++)
            {
                deltaY = bound.Height / n[l];
                int xxx = deltaX / 2 + l * deltaX; // center of each layer
                for (int r = 1; r < n[l]; r++)
                {
                    if ( l > 0)
                    {
                        for (int j = 0; j < w[l][r].Length; j++)
                        {
                            Point p = new Point();
                            p.X = xxx - (bound.Width / 10);
                            p.Y = deltaY / 2 + r * deltaY - (myFont.Height) * w[l][r].Length/2 + j * (myFont.Height);
                            g.DrawString(w[l][r][j].ToString("0.00"), myFont, Brushes.Black, p);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Read in the data set from the given file stream. Configure the portions of training 
        /// and testing data subsets. Original data are stored, bounds on each component of 
        /// input vector and target vector are founds, and normalized data set is prepared.
        /// </summary>
        /// <param name="sr">file stream</param>
        /// <param name="trainingRatio">portion of training data</param>
        public void ReadInDataSet(StreamReader sr, float trainingRatio)
        {
            char[] separators = new char[] { ',', ' ' };
            string s;
            string[] items;
            s = sr.ReadLine();
            items = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            inputNumber = Convert.ToInt32(items[0]);
            inputDimension = Convert.ToInt32(items[1]);
            targetDimension = Convert.ToInt32(items[2]);
            inputWidth = Convert.ToInt32(items[3]);

            originalInputs = new float[inputNumber,inputDimension];
            originalTargets = new float[inputNumber,targetDimension];

            inputs = new float[inputNumber, inputDimension];
            inputMin = new float[inputDimension];
            inputMax = new float[inputDimension];
            for (int i = 0; i < inputDimension; i++)
            {
                inputMin[i] = float.MaxValue;
                inputMax[i] = float.MinValue;
            }

            targets = new float[inputNumber, targetDimension];
            targetMax = new float[targetDimension];
            targetMin = new float[targetDimension];
            for (int i = 0; i < targetDimension; i++)
            {
                targetMin[i] = float.MaxValue;
                targetMax[i] = float.MinValue;
            }

            // read in original vectors and targets
            for (int n = 0; n < inputNumber; n++)
            {
                s = sr.ReadLine();
                items = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < inputDimension; i++)
                {
                    originalInputs[n,i] = (float)Convert.ToDouble(items[i]);
                    if (originalInputs[n, i] > inputMax[i])
                    {
                        inputMax[i] = originalInputs[n, i];
                    }else if (originalInputs[n, i] < inputMin[i])
                    {
                        inputMin[i] = originalInputs[n, i];
                    }
                }
                for (int i = 0; i < targetDimension; i++)
                {
                    originalTargets[n,i] = (float)Convert.ToDouble(items[i + inputDimension]);
                    if (originalTargets[n, i] > targetMax[i])
                    {
                        targetMax[i] = originalTargets[n, i];
                    }else if (originalTargets[n, i] < targetMin[i])
                    {
                        targetMin[i] = originalTargets[n, i];
                    }
                }
            }
           
            // normalize input vectors
            for (int n = 0; n < inputNumber; n++)
            {
                for (int j = 0; j < inputDimension; j++)
                {
                    inputs[n, j] = (originalInputs[n, j] - inputMin[j]) / (inputMax[j] - inputMin[j]);
                }

            }

            // normalize target vectors
            for (int n = 0; n < inputNumber; n++)
            {
                for (int j = 0; j < targetDimension; j++)
                {
                    targets[n, j] = (originalTargets[n, j] - targetMin[j]) / (targetMax[j] - targetMin[j]);
                }
            }
        }
        /// <summary>
        /// Configure the topology of the NN with the user specified numbers of hidden 
        /// neuorns and layers.
        /// </summary>
        /// <param name="hiddenNeuronNumbers">list of numbers of neurons of hidden layers</param>
        public void ConfigureNeuralNetwork(int[] hiddenNeuronNumbers)
        {
            epochCount = 0;
            layerNumber = hiddenNeuronNumbers.Length + 2;
            n = new int[layerNumber];
            n[0] = inputDimension + 1;
            n[layerNumber - 1] = targetDimension + 1;
            for (int h = 0; h < hiddenNeuronNumbers.Length; h++)
            {
                n[1 + h] = hiddenNeuronNumbers[h] + 1;
            }

            // arrange neuron value and epsilon
            e = new float[layerNumber][];
            x = new float[layerNumber][];
            for (int i = 0; i < layerNumber; i++)
            {
                x[i] = new float[n[i]];
                if (i > 0)
                {
                    e[i] = new float[n[i]];
                }
            }

            // arrange weight
            w = new float[layerNumber][][];
            for (int i = 0; i < layerNumber; i++)
            {
                if (i > 0)
                {
                    w[i] = new float[n[i]][];
                    for (int j = 1; j < n[i]; j++)
                    {
                        w[i][j] = new float[n[i - 1]];
                    }
                }
            }

            ResetWeightsAndInitialCondition();
        }
        /// <summary>
        /// Randomly shuffle the orders of the data in the data set.
        /// </summary>
        private void RandomizeIndices()
        {
            vectorIndices = new int[inputNumber];
            for (int i = 0; i < inputNumber; i++)
            {
                vectorIndices[i] = i;
            }
            for (int i = 0; i < inputNumber; i++)
            {
                int pos1 = randomizer.Next(inputNumber);
                int pos2 = randomizer.Next(inputNumber);
                int temp = vectorIndices[pos1];
                vectorIndices[pos1] = vectorIndices[pos2];
                vectorIndices[pos2] = temp;
            }
        }
        /// <summary>
        /// Randomly set values of weights between [-1,1] and randomly shuffle the orders of all
        /// the datum in the data set. Reset value of initial eta and root mean square to 0.0.
        /// </summary>
        public void ResetWeightsAndInitialCondition()
        {
            // initialize weights randomly
            for (int i = 0; i < layerNumber; i++)
            {
                if (i > 0)
                {
                    for (int j = 1; j < n[i]; j++)
                    {
                        for (int k = 0; k < n[i-1]; k++)
                        {
                            w[i][j][k] = (float)(-1 + randomizer.NextDouble() * 2); // between -1 and 1
                        }
                    }
                }
            }
            // reset value of initial eta and rms to 0.0
            initialEta = 0.7f;
            eta = initialEta;
            rootMeanSquareError = 0.0f;
        }
        /// <summary>
        /// Sequentially loop through each training datum of the training data whose indices are
        /// randomly shuffled in vectorIndices[] array, to perform on-line training of the NN.
        /// </summary>
        public void TrainAnEpoch()
        {
            float v = 0.0f;
            float errorSquareSum = 0.0f;
            float sumation = 0.0f;
            int layerNumberMinusOne = layerNumber - 1;
            /// forward computing for all neuron values.
            /// compute the epsilon values for neurons on the output layer
            /// backward computing for the epsilon values
            /// update weights for all weights by using epsilon and neuron values.
            /// update step size of the updating amount
            /// 

            RandomizeIndices();

            numberOfTrainingVectors = (int)(inputNumber * trainingRatio);
            for (int num = 0; num < inputNumber; num++)
            {
                // forward computing for all neuron values
                // x for first-layer
                x[0][0] = 1;
                for (int j = 1; j < n[0]; j++)
                {
                    x[0][j] = inputs[vectorIndices[num], j - 1];
                }
                // x for remaining layers
                for (int i = 1; i < layerNumber; i++)
                {
                    x[i][0] = 1;
                    for (int j = 1; j < n[i]; j++)
                    {
                        v = 0.0f;
                        for (int k = 0; k < n[i - 1]; k++)
                        {
                            v += w[i][j][k] * x[i-1][k];
                        }
                        x[i][j] = (float)(1 / (1 + Math.Exp(-v)));
                    }
                }
                // compute the epsilon values for neurons on the output layer
                for (int j = 1; j < n[layerNumber-1]; j++)
                {
                    e[layerNumber - 1][j] = -2 * (targets[vectorIndices[num], j - 1] - x[layerNumber-1][j]) * x[layerNumber-1][j] * (1 - x[layerNumber - 1][j]);
                    errorSquareSum += (targets[vectorIndices[num], j - 1] - x[layerNumber - 1][j]) * (targets[vectorIndices[num], j - 1] - x[layerNumber - 1][j]);
                }

                // backward compute for all epsilon values
                for (int i = layerNumber - 2; i > 0; i--)
                {
                    for (int j = 1; j < n[i]; j++)
                    {
                        sumation = 0.0f;
                        for (int k = 1; k < n[i + 1]; k++)
                        {
                            sumation += e[i + 1][k] * w[i + 1][k][j];
                        }
                        e[i][j] = x[i][j] * (1 - x[i][j]) * sumation;
                    }
                }

                // update weights for all weights by using epsilon and neuron values
                for (int l = 1; l < layerNumber; l++)
                {
                    for (int k = 1; k < n[l]; k++)
                    {
                        for (int i = 0; i < n[l-1]; i++)
                        {
                            w[l][k][i] += - eta * e[l][k] * x[l-1][i];
                        }
                    }
                }
            }            
            // update step size of the updating amount
            eta = (float)(learningRate * eta);
            rootMeanSquareError = (float)Math.Sqrt(errorSquareSum / inputNumber);
            epochCount++;
        }
        /// <summary>
        /// Compute the output vector for an input vector. Both vectors are in the raw
        /// format. The input vector is subject to scaling first before forward computing.
        /// Output vector is then scaled back to raw format for recognition. 
        /// </summary>
        /// <param name="input">input vector in raw format</param>
        /// <returns>output vector in raw format</returns>
        public float[] ComputeResults(float[] input)
        {
            float[] results = null;
            float v;
            results = new float[targetDimension];

            return results;
        }
        /// <summary>
        /// If the data set is a classification data set, test the data to generate confusing table.
        /// The index of the largest component of the target vector is the targeted class id.
        /// The index of the largest component of the computed output vector is the resulting class id.
        /// If both the targeted class id and the resulting class id are the same, then the test 
        /// data is correctly classified.
        /// </summary>
        /// <param name="confusingTable">generated confusing table</param>
        /// <returns>the ratio between the number of correctly classified testing data and the total number of testing data.</returns>
        public float TestingClassification(out int[,] confusingTable)
        {
            confusingTable = new int[targetDimension, targetDimension];
            int successedCount = 0;
            float v;

            return (float)successedCount / (float)(inputNumber - numberOfTrainingVectors);
        }
        #endregion
    }
}

