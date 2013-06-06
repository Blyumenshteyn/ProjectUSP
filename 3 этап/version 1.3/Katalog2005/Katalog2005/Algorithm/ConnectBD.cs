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


        /// <summary>
        /// �������������� ����������
        /// </summary>     
        /// <returns></returns> 
        private void automatConnection()
        {
            String connectionString = "";
            
             //��������� ������ ����������
            SQLOracle.BuildConnectionString(System.Environment.GetEnvironmentVariable("KTPP_DB_USER"),
                                System.Environment.GetEnvironmentVariable("KTPP_DB_PASSWORD") ,
                                findCorrectServerName(System.Environment.GetEnvironmentVariable("KTPP_DB_SERVER")));

            if (SQLOracle.CheckConnection())
            {
                this.Visible = false;
                //����������� ���������� �� �����
                ((Katalog)this.Owner).ViewInform();
            }else{

                            
                this.textBox1.Text =  System.Environment.GetEnvironmentVariable("KTPP_DB_USER");
                this.textBox2.Text = System.Environment.GetEnvironmentVariable("KTPP_DB_PASSWORD");
                this.textBox3.Text = findCorrectServerName(System.Environment.GetEnvironmentVariable("KTPP_DB_SERVER"));
                           
            }
                       
           
        }


        /// <summary>
        /// ��������� ����� �������
        /// </summary>    
        /// <param name="serverString">       
        /// ������ �������</param>
        /// <returns>��� �������</returns>
        private string findCorrectServerName(String serverString)
        {
            int positionOfSym = 0, i = 0;

            String correctServerString = "";

            foreach (char findSym in serverString)
            {
                if (String.Compare((Convert.ToString(findSym)), "/") == 0)
                {
                    positionOfSym = i;
                }

                i++;

            }

            if (positionOfSym == 0)
            {
                return serverString;
            }

            i = 0;


            foreach (char findSym in serverString)
            {

                if (i > positionOfSym)
                {
                    correctServerString += findSym;
                }

                i++;

            }

            return correctServerString;

        }

    }
}