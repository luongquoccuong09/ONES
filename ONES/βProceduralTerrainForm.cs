using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using View = Autodesk.Revit.DB.View;

namespace ONES
{
	// Token: 0x0200001A RID: 26
	public partial class βProceduralTerrainForm : System.Windows.Forms.Form
	{
		// Token: 0x0600007F RID: 127 RVA: 0x0000C889 File Offset: 0x0000AA89
		public βProceduralTerrainForm(UIDocument _uidoc)
		{
			this.InitializeComponent();
			this.uidoc = _uidoc;
			this.doc = _uidoc.Document;
			base.MaximizeBox = false;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000C8B4 File Offset: 0x0000AAB4
		private void βProceduralTerrainForm_Load(object sender, EventArgs e)
		{
			this.textBoxOctaves.Text = GlobVars.nOctaves.ToString();
			this.textBoxAmplitude.Text = GlobVars.amplitude.ToString();
			this.textBoxSpeed.Text = GlobVars.speed.ToString();
			this.textBoxDensity.Text = GlobVars.density.ToString();
			this.textBoxMinThickness.Text = "";
			this.textBoxPredefined.Text = GlobVars.randomvals.ToString();
			this.topoId = this.uidoc.Selection.GetElementIds().First<ElementId>();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000C958 File Offset: 0x0000AB58
		private void buttonTerrain_Click(object sender, EventArgs e)
		{
			this.RefreshNoise();
			View activeView = this.doc.ActiveView;
			Element element = this.doc.GetElement(this.topoId);
			TopographySurface topographySurface = element as TopographySurface;
			BoundingBoxXYZ boundingBoxXYZ = topographySurface.get_BoundingBox(activeView);
			XYZ max = boundingBoxXYZ.Max;
			XYZ min = boundingBoxXYZ.Min;
			double x3 = max.X;
			double y = max.Y;
			double x2 = min.X;
			double y2 = min.Y;
			XYZ xyz = new XYZ(x2, y, 0.0);
			XYZ xyz2 = new XYZ(x3, y2, 0.0);
			double num = max.DistanceTo(xyz);
			double num2 = min.DistanceTo(xyz);
			int num3 = Convert.ToInt32(Math.Ceiling(num * 10.0 / (GlobVars.density / 30.0)));
			int num4 = Convert.ToInt32(Math.Ceiling(num2 * 10.0 / (GlobVars.density / 30.0)));
			double num5 = num / (double)num3;
			double num6 = num2 / (double)num4;
			int[] array;
			if (GlobVars.randomvals == 0)
			{
				array = GlobVars.permutation;
			}
			else
			{
				Random rand = new Random();
				IEnumerable<int> source = Enumerable.Range(0, 256);
				array = (from x in source
				orderby rand.Next()
				select x).ToArray<int>();
			}
			int[] array2 = new int[512];
			for (int i = 0; i < 256; i++)
			{
				array2[i] = array[i];
				array2[256 + i] = array[i];
			}
			double[] array3 = new double[(num3 + 1) * (num4 + 1)];
			List<XYZ> list = new List<XYZ>();
			for (double num7 = 1.0; num7 < (double)(GlobVars.nOctaves + 1); num7 += 1.0)
			{
				for (double num8 = 1.0; num8 < (double)(num4 + 2); num8 += 1.0)
				{
					for (double num9 = 1.0; num9 < (double)(num3 + 2); num9 += 1.0)
					{
						double num10 = this.perlin_noise(num9 / (GlobVars.speed / (2.0 * num7)), num8 / (GlobVars.speed / (2.0 * num7)), array2);
						int num11 = ((int)num8 - 1) * (num3 + 1) + (int)num9 - 1;
						array3[num11] += num10 * (GlobVars.amplitude / 330.0 / (2.0 * num7));
						if ((int)num7 == GlobVars.nOctaves)
						{
							double num12 = x2 + num5 * (double)((int)num9 - 1);
							double num13 = y2 + num6 * (double)((int)num8 - 1);
							XYZ item = new XYZ(num12, num13, array3[num11]);
							list.Add(item);
						}
					}
				}
			}
			IList<XYZ> points = topographySurface.GetPoints();
			using (Transaction transaction = new Transaction(this.doc, "Procedural Terrain"))
			{
				transaction.Start();
				Plane plane = Plane.CreateByNormalAndOrigin(min.CrossProduct(max), max);
				SketchPlane sketchPlane = SketchPlane.Create(this.doc, plane);
				TopographySurface topographySurface2 = TopographySurface.Create(this.doc, list);
				ICollection<ElementId> collection = this.doc.Delete(this.topoId);
				transaction.Commit();
				this.topoId = topographySurface2.Id;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000CCD0 File Offset: 0x0000AED0
		private void buttonCity_Click(object sender, EventArgs e)
		{
			this.RefreshNoise();
			View activeView = this.doc.ActiveView;
			Element element = this.doc.GetElement(this.topoId);
			TopographySurface topographySurface = element as TopographySurface;
			BoundingBoxXYZ boundingBoxXYZ = topographySurface.get_BoundingBox(activeView);
			XYZ max = boundingBoxXYZ.Max;
			XYZ min = boundingBoxXYZ.Min;
			double x3 = max.X;
			double y = max.Y;
			double x2 = min.X;
			double y2 = min.Y;
			XYZ xyz = new XYZ(x2, y, 0.0);
			XYZ xyz2 = new XYZ(x3, y2, 0.0);
			double num = max.DistanceTo(xyz);
			double num2 = min.DistanceTo(xyz);
			int num3 = Convert.ToInt32(Math.Ceiling(num * 10.0 / (GlobVars.density / 30.0)));
			int num4 = Convert.ToInt32(Math.Ceiling(num2 * 10.0 / (GlobVars.density / 30.0)));
			double num5 = num / (double)num3;
			double num6 = num2 / (double)num4;
			int[] array;
			if (GlobVars.randomvals == 0)
			{
				array = GlobVars.permutation;
			}
			else
			{
				Random rand = new Random();
				IEnumerable<int> source = Enumerable.Range(0, 256);
				array = (from x in source
				orderby rand.Next()
				select x).ToArray<int>();
			}
			int[] array2 = new int[512];
			for (int i = 0; i < 256; i++)
			{
				array2[i] = array[i];
				array2[256 + i] = array[i];
			}
			double[] array3 = new double[(num3 + 1) * (num4 + 1)];
			List<XYZ> list = new List<XYZ>();
			using (Transaction transaction = new Transaction(this.doc, "Procedural City"))
			{
				transaction.Start();
				for (double num7 = 1.0; num7 < (double)(GlobVars.nOctaves + 1); num7 += 1.0)
				{
					for (double num8 = 1.0; num8 < (double)(num4 + 2); num8 += 1.0)
					{
						for (double num9 = 1.0; num9 < (double)(num3 + 2); num9 += 1.0)
						{
							double num10 = this.perlin_noise(num9 / (GlobVars.speed / (2.0 * num7)), num8 / (GlobVars.speed / (2.0 * num7)), array2);
							int num11 = ((int)num8 - 1) * (num3 + 1) + (int)num9 - 1;
							array3[num11] += num10 * (GlobVars.amplitude / 330.0 / (2.0 * num7));
							if ((int)num7 == GlobVars.nOctaves)
							{
								double num12 = x2 + num5 * (double)((int)num9 - 1);
								double num13 = y2 + num6 * (double)((int)num8 - 1);
								XYZ xyz3 = new XYZ(num12, num13, array3[num11]);
								double value = Math.Abs(array3[num11]) + 2.0;
								Solid solid = this.BlockSolid(new XYZ(num12, num13, 0.0), 3, Convert.ToInt32(value), 30);
								try
								{
									if (solid != null)
									{
										this.BlockDS(this.doc, solid);
									}
								}
								catch (Exception)
								{
								}
							}
						}
					}
				}
				transaction.Commit();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000D068 File Offset: 0x0000B268
		public double perlin_noise(double x, double y, int[] p)
		{
			int num = (int)x & 255;
			int num2 = (int)y & 255;
			x -= (double)((int)x);
			y -= (double)((int)y);
			double t = this.fade(x);
			double t2 = this.fade(y);
			int num3 = p[num] + num2;
			int num4 = p[num + 1] + num2;
			return this.lerp(t2, this.lerp(t, this.grad(p[num3], x, y), this.grad(p[num4], x - 1.0, y)), this.lerp(t, this.grad(p[num3 + 1], x, y - 1.0), this.grad(p[num4 + 1], x - 1.0, y - 1.0)));
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000D126 File Offset: 0x0000B326
		public double fade(double t)
		{
			return t * t * t * (t * (t * 6.0 - 15.0) + 10.0);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000D14F File Offset: 0x0000B34F
		public double lerp(double t, double a, double b)
		{
			return a + t * (b - a);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000D158 File Offset: 0x0000B358
		public double grad(int hash, double x, double y)
		{
			int num = hash & 15;
			double num2 = (num < 8) ? x : y;
			double num3 = (num < 4) ? y : ((num == 12 || num == 14) ? x : 0.0);
			return (((num & 1) == 0) ? num2 : (-num2)) + (((num & 2) == 0) ? num3 : (-num3));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000D1A8 File Offset: 0x0000B3A8
		private void RefreshNoise()
		{
			try
			{
				GlobVars.nOctaves = Convert.ToInt32(this.textBoxOctaves.Text);
				GlobVars.amplitude = Convert.ToDouble(this.textBoxAmplitude.Text);
				GlobVars.speed = Convert.ToDouble(this.textBoxSpeed.Text);
				GlobVars.density = Convert.ToDouble(this.textBoxDensity.Text);
				GlobVars.randomvals = Convert.ToInt32(this.textBoxPredefined.Text);
			}
			catch
			{
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000D234 File Offset: 0x0000B434
		private Solid BlockSolid(XYZ xyzCenter, int maxSize, int maxH, int maxOff)
		{
			Solid solid = null;
			Random random = new Random();
			int num = random.Next(1, 10);
			for (int i = 0; i < num; i++)
			{
				Thread.Sleep(5);
				int num2 = random.Next(1, maxSize);
				int num3 = random.Next(0, maxOff);
				int num4 = random.Next(0, maxOff);
				XYZ xyz = xyzCenter + new XYZ((double)(num3 / 10), (double)(num4 / 10), 0.0);
				List<Curve> list = Utils.SquareCurves(xyz, (double)num2);
				CurveLoop item = CurveLoop.Create(list);
				List<CurveLoop> list2 = new List<CurveLoop>
				{
					item
				};
				Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(list2, new XYZ(0.0, 0.0, 1.0), (double)random.Next(2, maxH));
				if (null == solid)
				{
					solid = solid2;
				}
				else
				{
					try
					{
						solid = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid2, 0);
					}
					catch (Exception)
					{
					}
				}
			}
			return solid;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000D334 File Offset: 0x0000B534
		private DirectShape BlockDS(Document doc, Solid solidUnion)
		{
			List<GeometryObject> list = new List<GeometryObject>();
			list.Add(solidUnion);
			DirectShape directShape = DirectShape.CreateElement(doc, new ElementId(-2000151));
			directShape.ApplicationId = "Application id";
			directShape.ApplicationDataId = "Geometry object id";
			directShape.SetShape(list);
			return directShape;
		}

		// Token: 0x04000066 RID: 102
		private UIDocument uidoc;

		// Token: 0x04000067 RID: 103
		private Document doc;

		// Token: 0x04000068 RID: 104
		private ElementId topoId;
	}
}

