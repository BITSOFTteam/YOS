using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.IO;

namespace YOS.Pages.Inputs
{
	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	public partial class Insert: UserControl
	{
        static DataTable idt = new DataTable();
        static DataSet ids = new DataSet();
        static StringBuilder isb = new StringBuilder();
        static StringWriter istream = new StringWriter(isb);
        static DataTable iCloneDT;

        public Insert()
		{
			InitializeComponent();
            CSampleClient.Program.SrvrConn();
            CSampleClient.Program.SendMessage("SELECT * FROM LECTURER2"); // 1test
            System.Threading.Thread.Sleep(1000);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            #region DB접속 및 DT 호출 하여 화면에 출력(WriteXml/ReadXml 테스트-성공)
            //string strConn = "User Id=scott;Password=tiger;Data Source=ORCL"; --> 서버쪽에서 디비랑 접근

            //OracleDataAdapter oraDA = new OracleDataAdapter("SELECT * FROM LECTURER2", strConn);
            ////DataTable dt = new DataTable();
            //oraDA.Fill(dt);

            //ds = new DataSet("XMLTABLE");

            //CloneDT = dt.Copy();
            //CloneDT.TableName = "XMLTABLE";
            //ds.Tables.Add(CloneDT);

            //sb = new StringBuilder();
            //stream = new StringWriter(sb);
            //ds.WriteXml(stream, XmlWriteMode.WriteSchema);

            ////dt.WriteXmlSchema(stream);
            //ds2 = new DataSet();

            //string xmlData = stream.ToString();

            //System.IO.StringReader xmlSR = new System.IO.StringReader(xmlData);

            ////dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);


            //ds2.ReadXml(xmlSR, XmlReadMode.ReadSchema);
            //dt2 = ds2.Tables["XMLTABLE"];

            //dataGrid.ItemsSource = dt2.DefaultView;

            //oraDA.Update(dt); 
            #endregion


            #region 메인에서 수신한 후 이쪽으로 분기 후 실행코드(CMD - 1)

            


            /// string 데이터를 ReadXml 메쏘드를 사용하여 xml다시 생성
            /// xml 을 다시 dt 로 변환
            /// WPF 화면에 출력
            /// 
            #endregion
        }

        private void btnINSERT_Copy_Click(object sender, RoutedEventArgs e)
        {
            DataRow testClick = idt.NewRow();

            testClick["ENAME"] = "수이홧팅";

            idt.Rows.InsertAt(testClick, (idt.Rows.Count) + 1);
            dataGrid.ItemsSource = idt.DefaultView;
            ids = new DataSet("XMLTABLE");

            iCloneDT = idt.Copy();
            iCloneDT.TableName = "XMLTABLE";
            ids.Tables.Add(iCloneDT);

            ids.WriteXml(istream, XmlWriteMode.WriteSchema);
            CSampleClient.Program.SendMessage2(istream.ToString());

            MessageBox.Show("전송 성공");
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            idt = CAccessDB.getdt();
            dataGrid.ItemsSource = idt.DefaultView;

        }
    }
}
