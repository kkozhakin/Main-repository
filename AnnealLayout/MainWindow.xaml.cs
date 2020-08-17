//
// Copyright (c) 2016, MindFusion LLC - Bulgaria.
//

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;


namespace MindFusion.Diagramming.Wpf.Samples.CS.AnnealLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            diagram.DefaultShape = Shapes.Ellipse;
            diagram.Bounds = new Rect(0, 0, 2000, 2000);

            try
            {
				diagram.LoadFromXml("AnnealLayout");
            }
            catch (FileLoadException exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

			Style shapeNodeStyle = new Style();
			shapeNodeStyle.Setters.Add(new Setter(ShapeNode.BrushProperty,
				new LinearGradientBrush(Colors.White, Color.FromRgb(135, 206, 250), 5)));
			diagram.ShapeNodeStyle = shapeNodeStyle;
		}

        // open
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
                diagram.LoadFromXml(dlg.FileName);
        }

        // save
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
                diagram.SaveToXml(dlg.FileName);
        }

        // arrange
        private void button1_Click(object sender, RoutedEventArgs e)
        {
			var layout = new Layout.AnnealLayout();
            int initIter;
            int initStages;
            double initTemp;
            double initTempScale;
            double arrowLengthFactor;
            double crossingArrowsCost;
            double distributionFactor;
            double nodeArrowDistFactor;
            double boundaryFactor;

            String errorValue = "";

            try
            {
                errorValue = iterationTxB.Text;
                initIter = Int32.Parse(iterationTxB.Text);
                errorValue = stageTxB.Text;
                initStages = Int32.Parse(stageTxB.Text);
                errorValue = initialTxB.Text;
                initTemp = Double.Parse(initialTxB.Text);
                errorValue = tempScaleTxB.Text;
                initTempScale = Double.Parse(tempScaleTxB.Text);

                errorValue = linkLengthFactorTxB.Text;
                arrowLengthFactor = Double.Parse(linkLengthFactorTxB.Text);
                errorValue = crossingArrowsCostTxB.Text;
                crossingArrowsCost = Double.Parse(crossingArrowsCostTxB.Text);
                errorValue = distributionFactorTxB.Text;
                distributionFactor = Double.Parse(distributionFactorTxB.Text);
                errorValue = nodeArrowDistFactorTxB.Text;
                nodeArrowDistFactor = Double.Parse(nodeArrowDistFactorTxB.Text);
                errorValue = boundaryFactorTxB.Text;
                boundaryFactor = Double.Parse(boundaryFactorTxB.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Error! Incorrect input: " + errorValue);
                return;
            }

            layout.IterationsPerStage = Math.Max(1, initIter);
            layout.Stages = initStages;
            layout.InitialTemperature = initTemp;
            layout.TemperatureScale = initTempScale;

            layout.LinkLengthFactor = arrowLengthFactor;
            layout.CrossingLinksCost = crossingArrowsCost;
            layout.DistributionFactor = distributionFactor;
            layout.NodeLinkDistFactor = nodeArrowDistFactor;
            layout.BoundaryFactor = boundaryFactor;

            layout.Arrange(diagram);
            diagram.ResizeToFitItems(50, true);
        }
        private void diagram_NodeClicked(object sender, NodeEventArgs e)
        {
        }
        private void diagram_LinkClicked(object sender, LinkEventArgs e)
        {
            e.Link.AutoRoute = true;
        }
    }
}