using System;
using System.Collections.Generic;
using System.Text;
using NXOpen;

/// <summary>
/// ����� �������������� ����������.
/// </summary>
public class Platan
{
    /// <summary>
    /// ���������� ������ ������������� A, B, C, D ��� ����������� ��������� ��������� -
    /// Ax + By + Cz + D = 0.
    /// </summary>
    public double[] Equation
    {
        get
        {
            return this.equation;
        }
    }
    /// <summary>
    /// ���������� ����������� ��� ��������� X �� ����������� ��������� ���������.
    /// </summary>
    public double X
    {
        get
        {
            return this.equation[0];
        }
    }
    /// <summary>
    /// ���������� ����������� ��� ��������� Y �� ����������� ��������� ���������.
    /// </summary>
    public double Y
    {
        get
        {
            return this.equation[1];
        }
    }
    /// <summary>
    /// ���������� ����������� ��� ��������� Z �� ����������� ��������� ���������.
    /// </summary>
    public double Z
    {
        get
        {
            return this.equation[2];
        }
    }
    /// <summary>
    /// ���������� ��������� �������� �� ����������� ��������� ���������.
    /// </summary>
    public double FreeArg
    {
        get
        {
            return this.equation[3];
        }
    }
    

    double[] equation;

    /// <summary>
    /// �������������� ����� ��������� ������ ��� ���������, ���������� ����� �������� ����� �
    /// ���������������� �������� ������
    /// </summary>
    /// <param name="point">�����, ����� ������� ������ ��������� ���������.</param>
    /// <param name="normalStraight">������, ��������������� ������� ������ ���������
    /// ���������</param>
    public Platan(Point3d point, Straight normalStraight)
    {
        double xArg = normalStraight.DenX;
        double yArg = normalStraight.DenY;
        double zArg = normalStraight.DenZ;

        double xFreeArg = normalStraight.DenX * -point.X;
        double yFreeArg = normalStraight.DenY * -point.Y;
        double zFreeArg = normalStraight.DenZ * -point.Z;

        double freeArg = xFreeArg + yFreeArg + zFreeArg;

        this.equation = new double[4] { xArg, yArg, zArg, freeArg };
    }
    /// <summary>
    /// �������������� ����� ��������� ������ ��� ���������, �������� ���������� ����������
    /// (Ax + By + Cz + D = 0).
    /// </summary>
    /// <param name="xArg">����������� ��� ��������� �.</param>
    /// <param name="yArg">����������� ��� ��������� Y.</param>
    /// <param name="zArg">����������� ��� ��������� Z.</param>
    /// <param name="freeArg">C�������� ��������.</param>
    public Platan(double xArg, double yArg, double zArg, double freeArg)
    {
        this.equation = new double[4] { xArg, yArg, zArg, freeArg };
    }
    /// <summary>
    /// �������������� ����� ��������� ������ ��� ���������, �������� ���������� ����������
    /// (Ax + By + Cz + D = 0).
    /// </summary>
    /// <param name="equation">������ c �������������� �, B, C, D</param>
    public Platan(double[] equation)
    {
        this.equation = equation;
    }

    public double getDistanceToPoint(Point3d point)
    {
        return 0.0;
    }
}
