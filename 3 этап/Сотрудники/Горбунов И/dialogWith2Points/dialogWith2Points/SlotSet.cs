using System;
using System.Collections.Generic;
using System.Text;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.BlockStyler;

/// <summary>
/// ����� ���������� ����� �����, ������� ���� ����� ������ ���������.
/// </summary>
public class SlotSet
{
    /// <summary>
    /// ���������� ���������, �� ������� ������������� ������ ����� �����
    /// </summary>
    public Component ParentComponent
    {
        get
        {
            return this.element.ElementComponent;
        }
    }

    //public Face BottomFace
    //{
    //    get
    //    {
    //        return this.bottomFace;
    //    }
    //}

    public List<Edge> TouchEdges
    {
        get
        {
            return this.touchEdges;
        }
    }

    public Point3d SelectPoint
    {
        get
        {
            return selectPoint;
        }
    }

    UspElement element;

    Body body;

    Face bottomFace;

    List<Edge> touchEdges;
    Edge[] edges;
    Dictionary<Edge, double> nearestEdges;

    Point3d selectPoint;


    
    /// <summary>
    /// �������������� ����� ��������� ������ ��� ��������� �������� ���.
    /// </summary>
    /// <param name="element">������� ���, �� ������� ���������� ����� �����.</param>
    public SlotSet(UspElement element)
    {
        this.element = element;
    }


    public void setPoint(UIBlock block)
    {
        PropertyList propertyList = block.GetProperties();
        this.selectPoint = propertyList.GetPoint("Point");
    }

    /*public void setBottomFace()
    {
        Face someFace = null;
        for (int j = 1; j < magic_number; j++)
        {
            try
            {
                someFace = (Face)this.component.FindObject("PROTO#.Features|UNPARAMETERIZED_FEATURE(0)|FACE " + j);
                break;
            }
            catch (NXException Ex)
            {
                if (Ex.ErrorCode == 3520016) //No object found exeption
                {
                    
                }
                else
                {
                    UI.GetUI().NXMessageBox.Show("������!", NXMessageBox.DialogType.Error, "������!");
                }
            }
        }
        this.body = someFace.GetBody();
        Face[] faces = this.body.GetFaces();

        this.bottomFaces = new List<Face>();
        //int nMaxEdgesBottom = 0;
        for (int j = 0; j < faces.Length; j++)
        {
            try
            {
                //Edge[] edges;
                //List<Edge> slot_edges;

                Face face = faces[j];

                if (face.Name != null)
                {
                    //Config.theUI.NXMessageBox.Show("tst", NXMessageBox.DialogType.Error, face.ToString());
                    string[] split = face.Name.Split(Config.FACE_NAME_SPLITTER);

                    if (split[0] == Config.SLOT_SYMBOL && split[1] == Config.SLOT_BOTTOM_SYMBOL)
                    {
                        this.bottomFaces.Add(face);
                    }
                }
                
                //int newNEdges = this.checkBottom(face, nMaxEdgesBottom, out edges, out slot_edges);
                //if (newNEdges != 0)
                //{
                //    this.bottomFace = face;
                //    this.edges = edges;
                //    this.touchEdges = slot_edges;

                //    nMaxEdgesBottom = newNEdges;
                //}
            }
            catch (NXException Ex)
            {
                if (Ex.ErrorCode == 3520016) //No object found exeption
                {

                }
                else
                {
                    UI.GetUI().NXMessageBox.Show("������!", NXMessageBox.DialogType.Error, "������!");
                }
            }
        }



    }*/

    public void setNearestBottomFace()
    {
        
    }

    public void setNearestEdges()
    {
        Dictionary<Edge, double> Edges = new Dictionary<Edge, double>();

        foreach (Edge Edge in this.edges)
        {
            if (Edge.SolidEdgeType == Edge.EdgeType.Linear)
            {
                Point3d FirstPoint, SecondPoint;
                Edge.GetVertices(out FirstPoint, out  SecondPoint);

                Vector Vec1 = new Vector(this.selectPoint, FirstPoint);
                Vector Vec2 = new Vector(this.selectPoint, SecondPoint);

                double len1 = Vec1.getLength();
                double len2 = Vec2.getLength();

                double min_len;
                if (len1 < len2)
                {
                    min_len = len1;
                }
                else
                {
                    min_len = len2;
                }

                this.addInDictMinValue(Edges, Edge, min_len);
            }
        }
        this.nearestEdges = Edges;
    }

    public bool hasSlot(out Slot slot)
    {
        slot = null;
        double min_len = -1;
        double slotWidth = 0;
        double minSlotWidth = 0;
        Edge edge1 = null, edge2 = null;

        List<Edge> Edges = new List<Edge>(nearestEdges.Keys);
        bool isFound = false;
        for (int i = 0; i < Edges.Count; i++)
        {
            for (int j = i + 1; j < Edges.Count; j++)
            {
                Vector vec1 = new Vector(Edges[i]);
                Vector vec2 = new Vector(Edges[j]);

                if (this.isSlot(vec1, vec2, out slotWidth))
                {
                    Edge edgeLong1 = Edges[i];
                    
                    Point3d start, end;
                    edgeLong1.GetVertices(out start, out end);

                    Straight firstLongStraight = new Straight(start, end);
                    //double[,] straight_equation = Geom.getStraitEquation(start, end);
                    Point3d intersection1 = Geom.getIntersectionPointStraight(this.selectPoint, firstLongStraight);
                    

                    double len1 = -1;
                    if (Geom.isOnSegment(intersection1, edgeLong1))
                    {
                        Vector vecN1 = new Vector(this.selectPoint, intersection1);
                        len1 = vecN1.getLength();
                    }
                    else
                    {
                        Vector Vec1S = new Vector(this.selectPoint, start);
                        Vector Vec1L = new Vector(this.selectPoint, end);

                        double lenS = Vec1S.getLength();
                        double lenL = Vec1L.getLength();

                        if (lenS < lenL)
                        {
                            len1 = lenS;
                        }
                        else
                        {
                            len1 = lenL;
                        }
                    }

                    Edge edgeLong2 = Edges[j];

                    edgeLong2.GetVertices(out start, out end);

                    Straight secondLongStraight = new Straight(start, end);
                    //straight_equation = Geom.getStraitEquation(start, end);
                    Point3d intersection2 = Geom.getIntersectionPointStraight(this.selectPoint, secondLongStraight);

                    double len2 = -1;
                    if (Geom.isOnSegment(intersection2, edgeLong2))
                    {
                        Vector vecN2 = new Vector(this.selectPoint, intersection2);
                        len2 = vecN2.getLength();
                    }
                    else
                    {
                        Vector Vec2S = new Vector(this.selectPoint, start);
                        Vector Vec2L = new Vector(this.selectPoint, end);

                        double lenS = Vec2S.getLength();
                        double lenL = Vec2L.getLength();

                        if (lenS < lenL)
                        {
                            len2 = lenS;
                        }
                        else
                        {
                            len2 = lenL;
                        }
                    }

                    double min;
                    if (len1 < len2)
                    {
                        min = len1;
                    }
                    else
	                {
                        min = len2;
	                }

                    if (min_len == -1 || min < min_len)
                    {
                        min_len = min;
                        edge1 = edgeLong1;
                        edge2 = edgeLong2;
                        minSlotWidth = slotWidth;
                        
                        isFound = true;
                    }
                }
            }
        }

        if (isFound)
        {
            slot = new Slot(this, edge1, edge2, Config.getSlotType(minSlotWidth));
            return true;
        }
        else
        {
            return false;
        }
    }


    int checkBottom(Face f, int max, out Edge[] edges, out List<Edge> slot_edges)
    {
        edges = f.GetEdges();
        slot_edges = new List<Edge>();

        int counter = 0;
        foreach (Edge e in edges)
        {
            if (e.GetLength().ToString() == Config.T_SLOT_WIDTH.ToString())
            {
                slot_edges.Add(e);
                counter++;
            }
        }

        if (counter > max)
        {
            return counter;
        }
        else
        {
            return 0;
        }
    }

    List<Edge> getSlotEdges(Face f)
    {
        List<Edge> slotWidthEdges = new List<Edge>();

        foreach (Edge e in edges)
        {
            if (Config.doub(e.GetLength()) == Config.T_SLOT_WIDTH || Config.doub(e.GetLength()) == Config.P_SLOT_WIDTH)
            {
                slotWidthEdges.Add(e);
            }
        }

        return slotWidthEdges;
    }

    void addInDictMinValue(Dictionary<Edge, double> Dictionary, Edge key, double value)
    {
        Edge min_key = null;
        double min_value = value;

        if (Dictionary.Count < Config.NUMBER_OF_NEAREST_EDGES)
        {
            Dictionary.Add(key, value);
        }
        else
        {
            foreach (KeyValuePair<Edge, double> P in Dictionary)
            {
                if (P.Value > min_value)
                {
                    min_key = P.Key;
                    min_value = P.Value;
                }
            }
        }

        if (min_key != null)
        {
            Dictionary.Remove(min_key);
            Dictionary.Add(key, value);
        }
    }

    bool isSlot(Vector vec1, Vector vec2, out double distance)
    {
        distance = 0;
        if (vec1.isParallel(vec2))
        {
            int nPerpendicular = 0;
            int nPointsInEdge = 2;
            int nVectors = 2;

            Point3d[] points = new Point3d[nPointsInEdge * nVectors];
            points[0] = vec1.start;
            points[1] = vec1.end;
            points[2] = vec2.start;
            points[3] = vec2.end;

            for (int i = 1; i <= nPointsInEdge; i++)
            {
                for (int j = nPointsInEdge + 1; j <= nPointsInEdge * 2; j++)
                {

                    Vector temp_vec = new Vector(points[i - 1], points[j - 1]);

                    if (vec1.isNormal(temp_vec))
                    {
                        double length = Config.doub(temp_vec.getLength());
                        if (length == Config.P_SLOT_WIDTH || length == Config.T_SLOT_WIDTH)
                        {
                            distance = length;
                            nPerpendicular++;
                        }
                    }
                }
            }

            if (nPerpendicular > 0 && this.haveNormals(vec1, vec2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    /*bool isPslot(Vector vec1, Vector vec2)
    {

    }*/

    bool haveNormals(Vector vec1, Vector vec2)
    {
        //��� ������� �������
        Point3d[] points1 = new Point3d[Config.N_POINTS_IN_EDGE];
        points1[0] = vec1.start;
        points1[1] = vec1.end;
        //double[,] straight1 = Geom.getStraitEquation(points1[0], points1[1]);
        Straight straight1 = new Straight(vec1);

        //��� ������� �������
        Point3d[] points2 = new Point3d[Config.N_POINTS_IN_EDGE];
        points2[0] = vec2.start;
        points2[1] = vec2.end;
        //double[,] straight2 = Geom.getStraitEquation(points2[0], points2[1]);
        Straight straight2 = new Straight(vec2);

        int alignment = 0;

        //������ �����
        bool onPoint = false;
        for (int i = 0; i < Config.N_POINTS_IN_EDGE; i++)
        {
            Point3d intersect1 = Geom.getIntersectionPointStraight(points1[i], straight2);
            for (int j = 0; j < Config.N_POINTS_IN_EDGE; j++)
            {
                if (Geom.isEqual(intersect1, points2[j]))
                {
                    alignment++;
                    onPoint = true;
                    break;
                }
            }


            if (!onPoint && Geom.isOnSegment(intersect1, vec2))
            {
                return true;
            }
        }

        //������ �����
        onPoint = false;
        for (int i = 0; i < Config.N_POINTS_IN_EDGE; i++)
        {
            Point3d intersect1 = Geom.getIntersectionPointStraight(points2[i], straight1);
            for (int j = 0; j < Config.N_POINTS_IN_EDGE; j++)
            {
                if (Geom.isEqual(intersect1, points1[j]))
                {
                    alignment++;
                    onPoint = true;
                    break;
                }
            }

            if (!onPoint && Geom.isOnSegment(intersect1, vec1))
            {
                return true;
            }
        }

        if (alignment > 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�� ������������
    /*bool hasCommonEdge(Vector v1, Vector v2, out Edge edge, out int k, out int n)
    {
        Point3d[] points1, points2;
        points1[0] = v1.start;
        points1[1] = v1.end;
        points2[0] = v2.start;
        points2[1] = v2.end;

        foreach (Edge edg in this.bottomFace.GetEdges())
        {
            Point3d start, end;
            edg.GetVertices(start, end);

            for (int i = 0; i < points1.Length; i++)
            {
                for (int j = 0; j < points2.Length; j++)
                {
                    if ((start == points1[i] && end == points2[j]) || (start == points2[j] && end == points1[i]))
                    {
                        edge = edg;
                        k = i;
                        n = j;
                        return true;
                    }
                }
            }
  
        }

        return false;
    }*/
}

