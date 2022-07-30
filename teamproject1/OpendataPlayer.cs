using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRISMPLAYERLib;

namespace teamproject1
{
    public partial class OpendataPlayer : Form
    {
        /*--------------------------------------------------------------------------------
         * 変数
         *--------------------------------------------------------------------------------*/
        private PrismPlayer m_pplayer = null;
        private bool m_bTakeFlag = false;
        private bool CoronaFlag = true;
        private System.Threading.Thread m_TakeThread = null;    //Take実行スレッド生成用


        /*--------------------------------------------------------------------------------
         * コンストラクタ
         *--------------------------------------------------------------------------------*/
        public OpendataPlayer()
        {
            InitializeComponent();
        }
        /*--------------------------------------------------------------------------------
         * 読み込み時に呼ばれます。
         *--------------------------------------------------------------------------------*/
        private void OpendataPlayer_Load(object sender, EventArgs e)
        {
            m_pplayer = new PrismPlayer();
            int ret = m_pplayer.initialize();
            Console.WriteLine(ret);
            if (ret == -1)
            {
                m_pplayer = null;
                MessageBox.Show(this, "Prismの初期化に失敗しました", "caption", MessageBoxButtons.OK);
                Close();
                return;
            }
            // OAStateのイベントハンドラ設定
            m_pplayer.onChangeOAState += new _IPrismEvents_onChangeOAStateEventHandler(IsWaitingtoTake_onChangeOAState);

            //送出デバイスの設定
            m_pplayer.execute("GetDevice WinGL HD SendTo -1 0");
            //m_pplayer.execute("Control WinGL Resize 80%");
            string strScenePath = Application.StartupPath.Replace("\\", "\\\\");
            strScenePath = strScenePath.Substring(0, strScenePath.IndexOf("bin"));

            m_pplayer.execute("Load '" + strScenePath + "\\\\シーン\\\\Scn\\\\TeamDevelopment.scm'");
            //m_pplayer.execute("Control WinGL SetBackImage 'C:\\\\Users\\\\miyamoto\\\\Desktop\\\\a.png'");
            //今日の日付を現地時刻で取得する
            System.Console.WriteLine(System.DateTime.Today);
            MonthCalendar.MaxDate = System.DateTime.Today;
        }
        /*--------------------------------------------------------------------------------
         * 終了時に呼ばれます。
         *--------------------------------------------------------------------------------*/
        private void OpendataPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_pplayer != null)
            {
                m_pplayer.execute("Abort B");

                m_pplayer.execute("Unload");
                m_pplayer = null;
            }
        }
        private static System.Threading.Timer MyTimer;
        int n = 0;
        private void Play_Click(object sender, EventArgs e)
        {
            //再生停止ボタンの切り替え
            Play.Visible = false;
            Stop.Visible = true;
            // 指定秒数間隔で呼び出される処理
            TimerCallback callback = state =>
            {
                if (CoronaFlag)
                {//コロナ表示
                    switch (n)
                    {
                        case 0:
                            m_pplayer.execute("Play '北海道'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 1:
                            m_pplayer.execute("Play '東北'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 2:
                            m_pplayer.execute("Play '関東'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 3:
                            m_pplayer.execute("Play '中部'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 4:
                            m_pplayer.execute("Play '近畿'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 5:
                            m_pplayer.execute("Play '中国'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 6:
                            m_pplayer.execute("Play '四国'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        case 7:
                            m_pplayer.execute("Play '九州'");
                            // Takeを別スレッドで実行
                            m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                            m_TakeThread.Start();
                            n++;
                            break;
                        default:
                            n = 0;
                            break;
                    }
                }
                else
                {
                    //天気予報表示
                }
            };
            // タイマー起動(0.5秒後に処理実行、1秒おきに繰り返し)
            MyTimer = new System.Threading.Timer(callback, null, 500, 1000);  
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            Play.Visible = true;
            Stop.Visible = false;
            //タイマー停止
            MyTimer.Dispose();
        }

        /*--------------------------------------------------------------------------------
         * OAStateのイベント時に呼ばれます。
         * Take待ち状態ならTakeスレッドのフラグを立てる。
         *--------------------------------------------------------------------------------*/
        private void IsWaitingtoTake_onChangeOAState(String bstrDevice, int lOAState, int lOAType)
        {
            //テイクできるかどうか
            m_bTakeFlag = (lOAState == 1) ? true : false;
        }

        /*--------------------------------------------------------------------------------
        * Takeができるまで実行するスレッド。
        * システム変数操作ボタン押下時に呼ばれます。
        *--------------------------------------------------------------------------------*/
        private async void TakeThread()
        {
            //テイク待ちになるまで
            while (!m_bTakeFlag)
            {
                System.Diagnostics.Debug.WriteLine("ログテスト\n");
                await Task.Delay(10);
            }
            // 送出
            m_pplayer.execute("Take");
            return;
        }
        private string selectDate;
        /*--------------------------------------------------------------------------------
        * 指定した日付・都道府県のコロナ感染者を表示
        *--------------------------------------------------------------------------------*/
        private void NihonMethod(object sender, EventArgs e)
        {
            if (CoronaFlag)
            {//コロナ表示
                string strSenderName = ((Button)sender).Name;
                m_pplayer.execute("Set V0 " + strSenderName.Substring(2));
                Console.WriteLine(strSenderName);
                Console.WriteLine(strSenderName.Substring(2));
                m_pplayer.execute("Set V1 '" + selectDate + "'");
                m_pplayer.execute("Play '日本地図'");
                // Takeを別スレッドで実行
                m_TakeThread = new System.Threading.Thread(new System.Threading.ThreadStart(TakeThread));
                m_TakeThread.Start();
            }
            else
            {//天気予報表示

            }
            
        }
        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            //選択した日付を出力
            selectDate = MonthCalendar.SelectionStart.ToShortDateString();
            Console.WriteLine(MonthCalendar.SelectionStart.ToShortDateString());
        }

        private void Weather_Click(object sender, EventArgs e)
        {
            CoronaFlag = false;
            MonthCalendar.Visible = false;
        }

        private void Corona_Click(object sender, EventArgs e)
        {
            CoronaFlag = true;
            MonthCalendar.Visible = true;
        }
    }
}
