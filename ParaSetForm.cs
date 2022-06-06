using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TobaccoExe;

namespace TobaccoApp
{
    
    public partial class ParaSetForm : Form
    {
        DateTime Nowtime = DateTime.Now;
        string defaultOperator = "123456";//默认操作员
     
        public ParaSetForm()
        {
            InitializeComponent();

            //从数据库中取出数据 用于显示 和 下发初始数据
            //常规参数
            this.txt_roll_angle.Text = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 0, "SP_SET_VALUE").ToString();
            this.txt_roll_turnFreq.Text = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 1, "SP_SET_VALUE").ToString();
            float tempSet_1 = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 2, "SP_SET_VALUE");
            float tempSet_2 = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 3, "SP_SET_VALUE");
            float tempSet_3 = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 4, "SP_SET_VALUE");
            float tempSet_4 = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 5, "SP_SET_VALUE");
            float blowback_stop_time = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 9, "SP_SET_VALUE");
            float blowback_work_time = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 8, "SP_SET_VALUE");
            float hotair_temp = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 6, "SP_SET_VALUE");
            float MoistureContent = selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 7, "SP_SET_VALUE");
            FatherForm.setPara[0] = (int)tempSet_1;
            FatherForm.setPara[1] = (int)tempSet_2;
            FatherForm.setPara[2] = (int)tempSet_3;
            FatherForm.setPara[3] = (int)tempSet_4;
            FatherForm.setPara[4] = (int)hotair_temp;
            FatherForm.setPara[5] = (int)MoistureContent;

             FatherForm.blowbackTIME[0] = (short)blowback_work_time;
             FatherForm.blowbackTIME[1] = (short)blowback_stop_time;


            this.txt_roll_tempSet_1.Text = (tempSet_1 / 100).ToString();
            this.txt_roll_tempSet_2.Text = (tempSet_2 / 100).ToString();
            this.txt_roll_tempSet_3.Text = (tempSet_3 / 100).ToString();
            this.txt_roll_tempSet_4.Text = (tempSet_4 / 100).ToString();
            this.txt_blowback_stop_time.Text = blowback_stop_time.ToString();
            this.txt_blowback_work_time.Text = blowback_work_time.ToString();
            this.txt_hotair_temp.Text = (hotair_temp / 100).ToString();
            this.txt_MoistureContent.Text = (MoistureContent / 100).ToString();

            //极限参数
            float roll_tempSet_limit_1 = selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 0, "LP_VALUE");
            float roll_tempSet_limit_2 = selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 1, "LP_VALUE");
            float roll_tempSet_limit_3 = selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 2, "LP_VALUE");
            float roll_tempSet_limit_4 = selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 3, "LP_VALUE");
            float hotair_limit_tem = selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 4, "LP_VALUE");
            
            FatherForm.limitPara[0] = (int)roll_tempSet_limit_1;
            FatherForm.limitPara[1] = (int)roll_tempSet_limit_2;
            FatherForm.limitPara[2] = (int)roll_tempSet_limit_3;
            FatherForm.limitPara[3] = (int)roll_tempSet_limit_4;
            FatherForm.limitPara[4] = (int)hotair_limit_tem;


            this.txt_roll_tempSet_limit_1.Text = (roll_tempSet_limit_1 / 100).ToString();
            this.txt_roll_tempSet_limit_2.Text = (roll_tempSet_limit_2 / 100).ToString();
            this.txt_roll_tempSet_limit_3.Text = (roll_tempSet_limit_3 / 100).ToString();
            this.txt_roll_tempSet_limit_4.Text = (roll_tempSet_limit_4 / 100).ToString();
            this.txt_hotair_limit_temp.Text = (hotair_limit_tem / 100).ToString();

 
        }
        private void ParaSetForm_Load(object sender, EventArgs e)
        {            
 
        }
        private void btn_paraSet_Click(object sender, EventArgs e)
        {

            if (this.txt_roll_angle.Text != selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 0, "SP_SET_VALUE").ToString())
            {
                int rollAngle = Convert.ToInt32(this.txt_roll_angle.Text);               
                inerstParaToDatabase("TBL_SET_PARA", 0, rollAngle);
                
            }
            if(this.txt_roll_turnFreq.Text != selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 1, "SP_SET_VALUE").ToString())
            {
                int rollTurnFreq = Convert.ToInt32(this.txt_roll_turnFreq.Text);
                inerstParaToDatabase("TBL_SET_PARA", 1, rollTurnFreq);
            }
            if(this.txt_roll_tempSet_1.Text != (selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 2, "SP_SET_VALUE") / 100).ToString())
            {
                int rollTempSet_1 = Convert.ToInt32(this.txt_roll_tempSet_1.Text)*100;
                FatherForm.setPara[0] = (int)rollTempSet_1; 
                inerstParaToDatabase("TBL_SET_PARA", 2, rollTempSet_1);
            }            
            if(this.txt_roll_tempSet_2.Text != (selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 3, "SP_SET_VALUE") / 100).ToString())
            {
                int rollTempSet_2 = Convert.ToInt32(this.txt_roll_tempSet_2.Text)*100;
                FatherForm.setPara[1] = (int)rollTempSet_2;
                inerstParaToDatabase("TBL_SET_PARA", 3, rollTempSet_2);
            }
            if(this.txt_roll_tempSet_3.Text != (selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 4, "SP_SET_VALUE") / 100).ToString())
            {
                int rollTempSet_3 = Convert.ToInt32(this.txt_roll_tempSet_3.Text)*100;
                FatherForm.setPara[2] = (int)rollTempSet_3;
                inerstParaToDatabase("TBL_SET_PARA", 2, rollTempSet_3);
            }            
            if(this.txt_roll_tempSet_4.Text != (selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 5, "SP_SET_VALUE") / 100).ToString())
            {
                int rollTempSet_4 = Convert.ToInt32(this.txt_roll_tempSet_4.Text)*100;
                FatherForm.setPara[3] = (int)rollTempSet_4;
                inerstParaToDatabase("TBL_SET_PARA", 3, rollTempSet_4);
            }           
            if(this.txt_hotair_temp.Text != (selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 6, "SP_SET_VALUE") / 100).ToString())
            {
                int hotairTemp = Convert.ToInt32(this.txt_hotair_temp.Text)*100;
                FatherForm.setPara[4] = (int)hotairTemp;
                inerstParaToDatabase("TBL_SET_PARA", 6, hotairTemp);
            }            
            if(this.txt_MoistureContent.Text != (selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 7, "SP_SET_VALUE") / 100).ToString())
            {
                int moistureContent = Convert.ToInt32(this.txt_MoistureContent.Text)*100;
                FatherForm.setPara[5] = (int)moistureContent;
                inerstParaToDatabase("TBL_SET_PARA", 7, moistureContent);
            }
            if (this.txt_blowback_work_time.Text != ((int)selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 8, "SP_SET_VALUE")).ToString())
            {
                int blowbackWorkTime = Convert.ToInt32(this.txt_blowback_work_time.Text);
                FatherForm.blowbackTIME[0] = (short)blowbackWorkTime;
                inerstParaToDatabase("TBL_SET_PARA", 8, blowbackWorkTime);
            }
            if (this.txt_blowback_stop_time.Text != ((int)selectParaFromDatabase("TBL_SET_PARA", "SP_ID", "SP_SET_TYPE", 9, "SP_SET_VALUE")).ToString())
            {
                int blowbackStopTime = Convert.ToInt32(this.txt_blowback_stop_time.Text);
                FatherForm.blowbackTIME[1] = (short) blowbackStopTime;
                inerstParaToDatabase("TBL_SET_PARA", 9, blowbackStopTime);
            }
            if (this.txt_roll_tempSet_limit_1.Text != (selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 0, "LP_VALUE") / 100).ToString())
            {
                int rollTempSetLimit_1 = Convert.ToInt32(this.txt_roll_tempSet_limit_1.Text)*100;
                FatherForm.limitPara[0] = rollTempSetLimit_1;
                inerstParaToDatabase("TBL_LIMIT_PARA", 0, rollTempSetLimit_1);
            }            
            if (this.txt_roll_tempSet_limit_2.Text != (selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 1, "LP_VALUE") / 100).ToString())
            {
                int rollTempSetLimit_2 = Convert.ToInt32(this.txt_roll_tempSet_limit_2.Text)*100;
                FatherForm.limitPara[1] = rollTempSetLimit_2;
                inerstParaToDatabase("TBL_LIMIT_PARA", 1, rollTempSetLimit_2);
            }            
            if (this.txt_roll_tempSet_limit_3.Text != (selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 2, "LP_VALUE") / 100).ToString())
            {
                int rollTempSetLimit_3 = Convert.ToInt32(this.txt_roll_tempSet_limit_3.Text)*100;
                FatherForm.limitPara[2] = rollTempSetLimit_3;
                inerstParaToDatabase("TBL_LIMIT_PARA", 2, rollTempSetLimit_3);
            }            
            if (this.txt_roll_tempSet_limit_4.Text != (selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 3, "LP_VALUE") / 100).ToString())
            {
                int rollTempSetLimit_4 = Convert.ToInt32(this.txt_roll_tempSet_limit_4.Text)*100;
                FatherForm.limitPara[3] = rollTempSetLimit_4;
                inerstParaToDatabase("TBL_LIMIT_PARA", 3, rollTempSetLimit_4);
            }
            if (this.txt_hotair_limit_temp.Text != (selectParaFromDatabase("TBL_LIMIT_PARA", "LP_ID", "LP_TYPE", 4, "LP_VALUE") / 100).ToString())
            {
                int hotairLimitTemp = Convert.ToInt32(this.txt_hotair_limit_temp.Text) * 100;
                FatherForm.limitPara[4] = hotairLimitTemp;
                inerstParaToDatabase("TBL_LIMIT_PARA", 4, hotairLimitTemp);
            }
        }
        private float selectParaFromDatabase(string tableName, string idType, string filedSetType, int setType, string needType)
        {
            float setValue = -1;
            string strSQL;
            strSQL = "select " + needType + " from " + tableName + " where " + idType + " in (select max(" + idType + ") from " + tableName + " where  " + filedSetType + " = " + setType + ")";
            setValue = Convert.ToSingle(DataOperator.GetSetPara(strSQL));
            return setValue;
        }
        private void inerstParaToDatabase(string tableName,int setType,int setValue)
        {

            string strSQL, strTemp;
            if(tableName == "TBL_SET_PARA")
            {
                strSQL = "insert into TBL_SET_PARA(SP_TIME,SP_SET_TYPE,SP_SET_VALUE,SP_OPER_NUMBER)";
                strTemp = string.Format("{0} values('{1}',{2},{3},{4})",
                        strSQL,
                        string.Format("{0:yyyy-MM-dd HH:mm:ss}", Nowtime),
                      setType,
                      setValue,
                      defaultOperator
                    );
            }
            else
            {
                strSQL = "insert into TBL_LIMIT_PARA(LP_MODIFY_TIME,LP_TYPE,LP_VALUE,LP_OPER_NUMBER)";
                strTemp = string.Format("{0} values('{1}',{2},{3},{4})",
                        strSQL,
                        string.Format("{0:yyyy-MM-dd HH:mm:ss}", Nowtime),
                      setType,
                      setValue,
                      defaultOperator
                    );
            }

            strSQL = strTemp;
            DataOperator.ExecSQL(strSQL);
        }
    }
}
