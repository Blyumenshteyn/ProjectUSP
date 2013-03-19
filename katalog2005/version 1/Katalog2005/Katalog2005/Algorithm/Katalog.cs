using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Katalog2005.Algorithm;

namespace Katalog2005
{
    public partial class Katalog
    {

        /// <summary>
        /// ��������� �������� �����
        /// </summary>   
        /// <returns></returns>
         void setFormSize()
        {
            this.panel1.Width = Convert.ToInt32(this.Width * 0.3);
            this.panel2.Height = Convert.ToInt32(this.panel1.Height * 0.6);

            /*
            if ((dataGrid2.Width / 2) > 1)
                dataGrid2.PreferredColumnWidth = (dataGrid2.Width / 2);
            else
                dataGrid2.PreferredColumnWidth = 1;*/
        }

        /// <summary>
        /// ������ ����� �����������
        /// </summary>   
        /// <returns></returns>
        void authorization()
        {
            ConnectBD AuthForm = new ConnectBD();

            AuthForm.StartPosition = FormStartPosition.CenterScreen;

            AuthForm.ShowDialog(this);
        }

        /// <summary>
        /// ����������� ���������� � dgv
        /// </summary>   
        /// <returns></returns>
        public  void ViewInform()
        {
               
            dataGridView1.DataSource = SQLOracle.getDS("SELECT NAME, OBOZN, GOST, L, B, B1, H, D, D1, D_SM_DB, D1_SM_DB, A, S, B_SM_DB, H" +
                         "0, H_SM_DB, T, N, MASSA, NALICHI, TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE KATALOG_USP = 0").Tables[0];
            
            renameDGVColumns();
            
            SpecialFunctions.hideUnusefulColumn(dataGridView1);

            dataGridView1.Refresh();

            CreateTreeView();

        }

        /// <summary>
        /// �������������� �������
        /// </summary>   
        /// <returns></returns>
        public void renameDGVColumns()
        {
            dataGridView1.Columns[0].HeaderText = "������������";
            dataGridView1.Columns[1].HeaderText = "�����������";
            dataGridView1.Columns[2].HeaderText = "����";
            dataGridView1.Columns[9].HeaderText = "d";
            dataGridView1.Columns[10].HeaderText = "d1";
            dataGridView1.Columns[11].HeaderText = "�����";
            dataGridView1.Columns[13].HeaderText = "b";
            dataGridView1.Columns[15].HeaderText = "h";
            dataGridView1.Columns[16].HeaderText = "t";
            dataGridView1.Columns[18].HeaderText = "�����";
            dataGridView1.Columns[19].HeaderText = "�������";
            dataGridView1.Columns[26].HeaderText = "�����������������";
        }

       
        /// <summary>
        /// �������� ����� ������
        /// </summary>   
        /// <returns></returns>
        public  void CreateTreeView()
        {
                   
                treeView1.BeginUpdate();

                treeView1.Nodes.Clear();

                treeView1.Nodes.Add("���-8");

                CreateSecondNode(0, treeView1);

                treeView1.Nodes.Add("���-12");

                CreateSecondNode(1, treeView1);

                treeView1.Nodes.Add("����. ������");

                CreateSecondNode(2, treeView1);

                CreateThirdNode(treeView1);

                treeView1.EndUpdate();           

        }

        /// <summary>
        /// �������� ����� ������� ������ � ������
        /// </summary>   
        /// <returns></returns>
        public static void CreateSecondNode(int nodePosition, System.Windows.Forms.TreeView MainTree)
        {

            MainTree.Nodes[nodePosition].Nodes.Add("������� ������");

            MainTree.Nodes[nodePosition].Nodes.Add("��������� ������");

            MainTree.Nodes[nodePosition].Nodes.Add("������������ ������");

            MainTree.Nodes[nodePosition].Nodes.Add("������������ ������");

            MainTree.Nodes[nodePosition].Nodes.Add("��������� ������");

            MainTree.Nodes[nodePosition].Nodes.Add("��������� ������");

            MainTree.Nodes[nodePosition].Nodes.Add("������ ������");

            MainTree.Nodes[nodePosition].Nodes.Add("��������� �������");

        }

        /// <summary>
        /// �������� ����� �������� ������ � ������
        /// </summary>   
        /// <returns></returns>
        public static void CreateThirdNode(System.Windows.Forms.TreeView MainTree)
        {         
            System.Data.DataTable ConfigurationDataForTree;
           
            ConfigurationDataForTree = SQLOracle.getDS("SELECT DISTINCT NAME, GROUP_USP, KATALOG_USP FROM DB_DATA").Tables[0];

            for (int position = 0; position < ConfigurationDataForTree.Rows.Count; position++)
            {

                MainTree.Nodes[Convert.ToInt32(ConfigurationDataForTree.Rows[position][2].ToString())].Nodes[Convert.ToInt32(ConfigurationDataForTree.Rows[position][1].ToString())].Nodes.Add(ConfigurationDataForTree.Rows[position][0].ToString());
                                            
            }

            ConfigurationDataForTree.Dispose();        
        }



        static private System.Windows.Forms.DataGridView.HitTestInfo hitTest;

        /// <summary>
        /// �������� �������� � PictureBox
        /// </summary>   
        /// <returns></returns>
        public void loadPictureInPictureBox(System.Windows.Forms.MouseEventArgs e)
        {
                hitTest =  dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0)
                {
                    pictureBox1.Image = SQLOracle.getBlobImageWithBuffer("SELECT DET FROM DB_DATA WHERE NAME = :NAME AND GOST = :GOST AND OBOZN = :OBOZN ", dataGridView1[0, hitTest.RowIndex].Value.ToString(), dataGridView1[2, hitTest.RowIndex].Value.ToString(), dataGridView1[1, hitTest.RowIndex].Value.ToString());
                                      
                }            
        }

        /// <summary>
        /// �������� �������� � PictureBox (��� ������������ �����-����)
        /// </summary>   
        /// <returns></returns>
        public void loadPictureInPictureBoxWithKeyEvent(int RowIndex)
        {
            if (pictureBox1.Image != null)
            { 
                pictureBox1.Image.Dispose();
            }
               
            pictureBox1.Image = SQLOracle.getBlobImageWithBuffer("SELECT DET FROM DB_DATA WHERE NAME = :NAME AND GOST = :GOST AND OBOZN = :OBOZN ", dataGridView1[0, RowIndex].Value.ToString(), dataGridView1[2, RowIndex].Value.ToString(), dataGridView1[1, RowIndex].Value.ToString());

                      
        }


        /// <summary>
        /// ���������� ������ �� ������
        /// </summary>   
        /// <returns></returns>
        public  void sortInformWithTree(System.Windows.Forms.TreeViewEventArgs e)
        {

            if (((e.Node.Parent) != null) && e.Node.Parent.GetType() == typeof(System.Windows.Forms.TreeNode))
            {
                if (((e.Node.Parent.Parent) != null) && e.Node.Parent.Parent.GetType() == typeof(System.Windows.Forms.TreeNode))
                {

                    dataGridView1.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                        " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                        " A,  S, B_SM_DB ,  H0,  T,  N,H_SM_DB, MASSA" +
                                        " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE NAME = '" + e.Node.Text.ToString() + "' AND KATALOG_USP = '" + Convert.ToString(e.Node.Parent.Parent.Index) + "' AND GROUP_USP = '" + Convert.ToString(e.Node.Parent.Index) + "' ").Tables[0];

                    SpecialFunctions.hideEmptyColumn(dataGridView1);
                }
                else
                {

                    dataGridView1.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                        " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                        " A,  S, B_SM_DB ,  H0,  T,  N, H_SM_DB,MASSA" +
                                        " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE KATALOG_USP = '" + Convert.ToString(e.Node.Parent.Index) + "' AND GROUP_USP = '" + Convert.ToString(e.Node.Index) + "'").Tables[0];

                    SpecialFunctions.hideEmptyColumn(dataGridView1);
                }
            }
            else
            {
                    dataGridView1.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                           " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                           " A,  S, B_SM_DB ,  H0,  T,  N,H_SM_DB, MASSA" +
                                           " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM  DB_DATA WHERE KATALOG_USP = '" + Convert.ToString(e.Node.Index) + "' ").Tables[0];

                    SpecialFunctions.hideEmptyColumn(dataGridView1);
            }

        }


        ///<summary>
        /// ����������� ���������� �� ��������
        /// </summary>   
        /// <returns></returns>
        public void ViewInformationAboutElement(int i)
        {

            using (Katalog2005.WinFroms.search.InformAboutElement DispInform = new Katalog2005.WinFroms.search.InformAboutElement())
            {


                for (int j = 0; j < 19; j++)
                {
                    if (String.Compare(dataGridView1[j, i].Value.ToString(), "0") != 0)
                        DispInform.AddRowToDataGrid(dataGridView1.Columns[dataGridView1[j, i].ColumnIndex].HeaderText, dataGridView1[j, i].Value.ToString());
                }

                DispInform.AddRowToDataGrid("����������� ����������", dataGridView1[20, i].Value.ToString());
                DispInform.AddRowToDataGrid("��������", dataGridView1[21, i].Value.ToString());
                DispInform.AddRowToDataGrid("��������", dataGridView1[22, i].Value.ToString());
                DispInform.AddRowToDataGrid("����������", dataGridView1[23, i].Value.ToString());
                DispInform.AddRowToDataGrid("�����������������", dataGridView1[26, i].Value.ToString());

                DispInform.ShowDialog();


            }

        }

    }
}
