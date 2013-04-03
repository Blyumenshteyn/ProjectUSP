using System;
using System.Collections.Generic;
using System.Text;
using NXOpen;
using NXOpen.Assemblies;

/// <summary>
/// ����� ���������� ������� ���.
/// </summary>
public class UspElement
{
    /// <summary>
    /// ���������� ��������� ��������.
    /// </summary>
    public Component ElementComponent
    {
        get
        {
            return this.component;
        }
    }
    /// <summary>
    /// ���������� ������ ���� ������ ���������� ����� ��� ������� ��������.
    /// </summary>
    public List<Face> SlotFaces
    {
        get
        {
            return this.bottomFaces;
        }
    }


    Component component;
    Body body;

    List<Face> bottomFaces;

    int magic_number = 1680;//TODO


    /// <summary>
    /// �������������� ����� ��������� ������ �������� ��� ��� ��������� ����������.
    /// </summary>
    /// <param name="component">��������� �� ������ NX.</param>
    public UspElement(Component component)
    {
        this.component = component;

        this.setBottomFace();
    }

    //refactor
    void setBottomFace()
    {
        Face someFace = null;
        for (int j = 1; j < magic_number; j++)
        {
            try
            {
                someFace = (Face)this.component.FindObject(
                    "PROTO#.Features|UNPARAMETERIZED_FEATURE(0)|FACE " + j);
                break;
            }
            catch (NXException Ex)
            {
                if (Ex.ErrorCode == 3520016) //No object found exeption
                {

                }
                else
                {
                    UI.GetUI().NXMessageBox.Show("������!", 
                                                 NXMessageBox.DialogType.Error, 
                                                 "������!");
                }
            }
        }
        this.body = someFace.GetBody();
        Face[] faces = this.body.GetFaces();

        this.bottomFaces = new List<Face>();
        for (int j = 0; j < faces.Length; j++)
        {
            try
            {
                Face face = faces[j];

                if (face.Name != null)
                {
                    string[] split = face.Name.Split(Config.FACE_NAME_SPLITTER);

                    if (split[0] == Config.SLOT_SYMBOL && 
                        split[1] == Config.SLOT_BOTTOM_SYMBOL)
                    {
                        this.bottomFaces.Add(face);

                        int tag;
                        double d;
                        double[] dd = new double[3];
                        double[] dds = new double[3];
                        double[] ddd = new double[6];
                        Config.theUFSession.Modl.AskFaceData(face.Tag, out tag, dd, dds, ddd, out d, out d, out tag);

                        Config.theUI.NXMessageBox.Show("tst", NXMessageBox.DialogType.Error, dds[0] + " " + dds[1] + " " + dds[2]);
                    }
                }
            }
            catch (NXException Ex)
            {
                if (Ex.ErrorCode == 3520016) //No object found exeption
                {

                }
                else
                {
                    UI.GetUI().NXMessageBox.Show("������!", 
                                                 NXMessageBox.DialogType.Error, 
                                                 "������!");
                }
            }
        }
    }
}

