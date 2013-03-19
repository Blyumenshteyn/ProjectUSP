using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Katalog2005.Algorithm;


namespace Katalog2005
{
    public partial class ConnectBD 
    {
        /// <summary>
        /// �������� ������ � SQL �����
        /// </summary>     
        /// <returns></returns>         
        void connectAction()
        {
            if ((!SpecialFunctions.IsEmpty(textBox1)) && (!SpecialFunctions.IsEmpty(textBox2)) && (!SpecialFunctions.IsEmpty(textBox3)))
            {                
                SQLOracle.BuildConnectionString(this.textBox1.Text.ToString(), this.textBox2.Text.ToString(), this.textBox3.Text.ToString());

                if (SQLOracle.CheckConnection())
                {
                    this.Visible = false;
                    //����������� ���������� �� �����
                    ((Katalog)this.Owner).ViewInform();
                }
                 
            }
            else
            {
                MessageBox.Show("�� ��� ������ ���������.");
            }
            
        }

        /// <summary>
        /// ��������� ������� Enter
        /// </summary>
        /// <param name="e">       
        /// �������</param>
        /// <returns>true - ������ ��������
        /// false - �� ������ ��������</returns> 
        static bool EnterDownFilter(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return true;
            }
            else {

                return false;
            }
        }

    }
}